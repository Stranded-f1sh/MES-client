using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using OpenCvSharp;
using TensorFlow;
using System.IO;
using System.Configuration;
using System.Drawing;
using ObjectDetectionProgram.Common;
using System.Threading;
using ManufacturingExecutionSystem.MES.Client.Model;

namespace ObjectDetectionProgram.ImageIdentification
{
    public class ObjectDetection
    {
        public static Bitmap imgInput;
        private static IEnumerable<CatalogItem> _catalog;
        private static Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        private static readonly string CurrentDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private static readonly string ModelPath = Path.Combine(CurrentDir ?? string.Empty, config.AppSettings.Settings["ModelPath"].Value);
        private static readonly string CatalogPath = Path.Combine(CurrentDir ?? string.Empty, config.AppSettings.Settings["CatalogPath"].Value);
        private static readonly string ImgOutput = Path.Combine(CurrentDir ?? string.Empty, config.AppSettings.Settings["OutputPath"].Value);
        // private static readonly double MIN_SCORE_FOR_OBJECT_HIGHLIGHTING = double.Parse(Path.Combine(CurrentDir ?? string.Empty, config.AppSettings.Settings["MIN_SCORE_FOR_OBJECT_HIGHLIGHTING"].Value));

        public static void Run( out CatalogItemList catalogItemList)
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

                // 开启会话
                using (TFSession session = new TFSession(graph))
                {
                    while (true)
                    {
                        Thread.Sleep(1000);
                        if (imgInput == null) continue;
                        Bitmap inputImg = imgInput;
                        imgInput = null;
                        // 将输入的图片调整参数，处理为符合要求的形式，并转换为张量
                        TFTensor tensor = ImageUtil.CreateTensorFromImageFileAlt(inputImg, TFDataType.UInt8);

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

                        float[,,] boxes = (float[,,])output[0].GetValue(jagged: false);
                        float[,] scores = (float[,])output[1].GetValue(jagged: false);
                        float[,] classes = (float[,])output[2].GetValue(jagged: false);
                        float[] num = (float[])output[3].GetValue(jagged: false);

                        // 绘制识别框和准确度并输出
                        catalogItemList = ImageEditor.DrawBoxes(boxes, scores, classes, inputImg, ImgOutput, 0.1, _catalog);
                        inputImg = null;
                    }
                }
            }
        }
    }
}
