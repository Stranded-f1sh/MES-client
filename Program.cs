using System;
using System.Windows.Forms;
using ManufacturingExecutionSystem.MES.Client.UI;
using OpenCvSharp;
using TensorFlow;
using Numpy;
using ObjectDetectionProgram.ImageIdentification;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using ManufacturingExecutionSystem.MES.Client.Model;
using System.Threading;

namespace ManufacturingExecutionSystem
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());

            //Mat img = Cv2.ImRead("C:\\Users\\Jinyu\\Desktop\\tra\\000049.bmp");
            //Cv2.Resize(img, img, new OpenCvSharp.Size(600, 600), interpolation: InterpolationFlags.Area);
            //gaussian_filter(img);


        }



        public static unsafe void gaussian_filter(Mat img)
        {

            
            /*            Mat blur = new Mat();
                        Cv2.Blur(img, blur, new Size(5,5));
                        Cv2.ImShow("blur",blur);
                        Cv2.WaitKey();*/

            /*            // 中值滤波
                        Mat median = new Mat();
                        Cv2.MedianBlur(img, median, 3);
                        Cv2.ImShow("median", median);
                        Cv2.WaitKey();*/

            /*            // 高斯滤波
                        Mat gaussian = new Mat();
                        Cv2.GaussianBlur(img, gaussian, new Size(3, 3), 0);// 第三个参数 必须为正奇数，x，y可以不同
                        Cv2.ImShow("gaussian", gaussian);
                        Cv2.WaitKey();*/


            /*            // 盒式滤波
                        Mat box = new Mat();
                        Cv2.BoxFilter(img, box, MatType.CV_8UC3, new Size(5, 5));
                        Cv2.ImShow("box", box);
                        Cv2.WaitKey();*/

            /*            // 形态学 Open
            Mat morphotoOpen = new Mat();
            Cv2.MorphologyEx(img, morphotoOpen, MorphTypes.Open, new Mat());
            Cv2.ImShow("morphotoOpen", morphotoOpen);
            Cv2.WaitKey();*/

            Mat img2 = Cv2.ImRead("C:\\Users\\Jinyu\\Desktop\\tra\\000045.bmp");
            // Cv2.ImShow("bdb", img2);
            Mat img3 = new Mat();


            // Cv2.BitwiseNot(img2, img2, new Mat());

            Cv2.Resize(img2, img2, new OpenCvSharp.Size(1000, 700), interpolation: InterpolationFlags.Area);

            Cv2.GaussianBlur(img2, img2, new OpenCvSharp.Size(3, 3), 15);


            // Cv2.Sobel(img2, img2, MatType.CV_8U, 1, 0);

            Cv2.CvtColor(img2, img2, ColorConversionCodes.BGR2GRAY);

            Cv2.Dilate(img2, img2, new Mat()); // peng zhang
            Cv2.Erode(img2, img2, new Mat()); // fu shi


            Cv2.MedianBlur(img2, img2, 1);


            // Cv2.Threshold(img2, img2, 125, 255.0, ThresholdTypes.BinaryInv);
            // Cv2.Canny(img2, img2, 3, 3, 7);
            
            Mat warp_mat = Cv2.GetRotationMatrix2D(new Point2f(img2.Rows / 3, img2.Cols / 2), 50, 0.5);

            Mat dst_img = new Mat();

            OpenCvSharp.Size imgSize = new OpenCvSharp.Size(700, 700);

            Cv2.WarpAffine(img2, dst_img, warp_mat, imgSize);

            

            // Cv2.ImShow("dst_img", dst_img);

            Bitmap bitmap = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(dst_img);

            ObjectDetection.imgInput = bitmap;

            /*            Cv2.CvtColor(img2, img3, ColorConversionCodes.BGR2GRAY);

                        Cv2.ImShow("4521", img3);


                        Cv2.Dilate(img3, img3, new Mat()); // peng zhang
                        Cv2.Erode(img3, img3, new Mat()); // fu shi
                        Cv2.Threshold(img3, img3, 120, 255.0, ThresholdTypes.Binary);
                        Cv2.Canny(img3, img3, 3, 3, 7);*/




            /*            Point[][] coutours;
                        HierarchyIndex[] hierarchy;

                        Cv2.MedianBlur(img3, img3, 1);
                        Cv2.FindContours(img3, out coutours, out hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxNone);


                        Cv2.DrawContours(img2, coutours, -1, new Scalar(0, 255, 0), 3, hierarchy:hierarchy);
                        Cv2.ImShow("aa", img3);
                        Cv2.ImShow("bb", img2);*/
            //Cv2.ImShow("substr1", img2);

            // 中值滤波
            //Cv2.MedianBlur(img2, img2, 3);

            // Cv2.ImShow("substr2", img2);
            // Cv2.WaitKey();
/*            CatalogItemList catalogItemList = null;
            new Thread(() => 
            {
                while (true)
                {
                    Thread.Sleep(500);
                    if (catalogItemList == null) continue;
                    var items = catalogItemList.list.GetEnumerator();
                    while (items.MoveNext())
                    {
                        Console.WriteLine("id:" + items.Current.id);
                        Console.WriteLine("name:" + items.Current.Name);
                        Console.WriteLine("score:" + items.Current.Score);
                    }
                    break;
                }
                


            }).Start();

            ObjectDetection.Run(out catalogItemList);*/

            
        }
    }
}
