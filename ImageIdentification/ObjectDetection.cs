using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using ManufacturingExecutionSystem.MES.Client.Model;
using ObjectDetectionProgram.Common;
using ObjectDetectionProgram.ImageIdentification;
using OpenCvSharp;
using TensorFlow;

namespace ManufacturingExecutionSystem.ImageIdentification
{
    public class ObjectDetection
    {
        public static Bitmap imgInput;
        private static IEnumerable<CatalogItem> _catalog;
        private static readonly Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        private static readonly string CurrentDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private static readonly string ModelPath = Path.Combine(CurrentDir ?? string.Empty, config.AppSettings.Settings["ModelPath"].Value);
        private static readonly string CatalogPath = Path.Combine(CurrentDir ?? string.Empty, config.AppSettings.Settings["CatalogPath"].Value);
        private static readonly string ImgOutput = Path.Combine(CurrentDir ?? string.Empty, config.AppSettings.Settings["OutputPath"].Value);

        private static readonly double MIN_SCORE_FOR_OBJECT_HIGHLIGHTING = double.Parse(config.AppSettings.Settings["MIN_SCORE_FOR_OBJECT_HIGHLIGHTING"].Value);

        public static void Run(out CatalogItemList catalogItemList)
        {
            // 解析pbtxt
            _catalog = CatalogUtil.ReadCatalogItems(CatalogPath ?? string.Empty);

            using (TFGraph graph = new TFGraph())
            {
                // 将模型文件内容读入字节数组
                byte[] model = File.ReadAllBytes(ModelPath ?? string.Empty);

                // 加载模型
                // Initializes a new instance of the TensorFlow.TFBuffer by making a copy of the provided byte array.
                graph.Import(new TFBuffer(model));
                
                TFSessionOptions TFOptions = new TFSessionOptions();

                // This code helps with using the GPU version of tensorflowlib on Windows to avoid eating all of your RAM 
                // unsafe
                // {
                    // These bytes represent the following settings:
                    // config.gpu_options.allow_growth = True
                    // config.gpu_options.per_process_gpu_memory_fraction = 0.3
                //    byte[] GPUConfig = new byte[] { 0x32, 0x0b, 0x09, 0x33, 0x33, 0x33, 0x33, 0x33, 0x33, 0xd3, 0x3f, 0x20, 0x01 };

                //    fixed (void* ptr = &GPUConfig[0])
                //    {
                //        TFOptions.SetConfig(new IntPtr(ptr), GPUConfig.Length);
                //    }
                // }

                // 开启会话
                using (TFSession session = new TFSession(graph, TFOptions))
                {
                    while (true)
                    {
                        Thread.Sleep(200);
                        if (imgInput == null)
                        {
                            continue;
                        }

                        var inputImg = imgInput;

                        imgInput = null;
                        // 将输入的图片调整参数，处理为符合要求的形式，并转换为张量
                        float[,,] boxes;
                        float[,] scores;
                        float[,] classes;
                        using (TFTensor tensor = ImageUtil.CreateTensorFromImageFileAlt(inputImg, TFDataType.UInt8))
                        {
                            var runner = session.GetRunner();

                            runner?
                                .AddInput(graph["image_tensor"][0], tensor)
                                .Fetch(
                                    graph["detection_boxes"][0],
                                    graph["detection_scores"][0],
                                    graph["detection_classes"][0],
                                    graph["num_detections"][0]);

                            // 开始检测
                            TFTensor[] output = runner?.Run();
                        
                            boxes = (float[,,]) output?[0].GetValue(jagged: false);
                            scores = (float[,]) output?[1].GetValue(jagged: false);
                            classes = (float[,]) output?[2].GetValue(jagged: false);
                            // 绘制识别框和准确度并输出
                            catalogItemList = ImageEditor.DrawBoxes(boxes, scores, classes, inputImg, ImgOutput, MIN_SCORE_FOR_OBJECT_HIGHLIGHTING, _catalog);
                            tensor.Dispose();
                        }
                        
                        Mat img = Cv2.ImRead(ImgOutput, ImreadModes.AnyColor);
                        OpenCvSharp.Size size = new OpenCvSharp.Size(1000, 800);
                        // Cv2.Resize(img, img, size, 0, 0);
                        Cv2.NamedWindow("目标检测", WindowFlags.Normal);
                        Cv2.SetWindowProperty("目标检测", WindowPropertyFlags.Fullscreen, 1);
                        Cv2.ImShow("目标检测", img);
                        Cv2.WaitKey(3000);
                        Cv2.DestroyAllWindows();
                    }
                }
            }
        }
    }
}
