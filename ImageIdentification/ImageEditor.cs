using System;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using ManufacturingExecutionSystem.MES.Client.Model;

namespace ObjectDetectionProgram.ImageIdentification
{
    public class ImageEditor : IDisposable
    {
        private readonly Graphics _graphics;
        private readonly Image _inputImage;
        private readonly string _fontFamily;
        private readonly float _fontSize;
        private readonly string _outputFile;
        private readonly Bitmap _bitmap;


        private ImageEditor(Bitmap inputFile, string outputFile, string fontFamily = "Ariel", float fontSize = 50)
        {
            if (string.IsNullOrEmpty(outputFile))
            {
                throw new ArgumentNullException(nameof(outputFile));
            }

            _fontFamily = fontFamily;
            _fontSize = fontSize;
            _outputFile = outputFile;

            _inputImage = inputFile ?? throw new ArgumentNullException(nameof(inputFile));

            if (IsPixelFormatIndexed(_inputImage.PixelFormat))
            {
                _bitmap = new Bitmap(_inputImage.Width, _inputImage.Height);
                _graphics = Graphics.FromImage(_bitmap);
                var imageRectangle = new Rectangle(new Point(0, 0), new Size(_inputImage.Width, _inputImage.Height));
                _graphics.DrawImage(_inputImage, imageRectangle);
            }
            else
            {
                _bitmap = new Bitmap(_inputImage.Width, _inputImage.Height);
                _graphics = Graphics.FromImage(_bitmap);
                var imageRectangle = new Rectangle(new Point(0, 0), new Size(_inputImage.Width, _inputImage.Height));
                _graphics.DrawImage(_inputImage, imageRectangle);
            }
        }



        /// <summary>
        /// 会产生graphics异常的PixelFormat
        /// </summary>
        private static readonly PixelFormat[] IndexedPixelFormats =
        {
            PixelFormat.Undefined,
            PixelFormat.DontCare,
            PixelFormat.Format16bppArgb1555,
            PixelFormat.Format1bppIndexed,
            PixelFormat.Format4bppIndexed,
            PixelFormat.Format8bppIndexed
        };


        /// <summary>
        /// 判断图片的PixelFormat 是否在 引发异常的 PixelFormat 之中
        /// </summary>
        /// <param name="imgPixelFormat">原图片的PixelFormat</param>
        /// <returns></returns>
        private static bool IsPixelFormatIndexed(PixelFormat imgPixelFormat)
        {
            return IndexedPixelFormats.Contains(imgPixelFormat);
        }



        public static CatalogItemList DrawBoxes(float[,,] boxes, float[,] scores, float[,] classes, Bitmap inputFile, string outputFile, double minScore, IEnumerable<CatalogItem> catalog)
        {
            var x = boxes.GetLength(0);
            var y = boxes.GetLength(1);
            var z = boxes.GetLength(2);

            float yMin = 0, xMin = 0, yMax = 0, xMax = 0;

            using (var editor = new ImageEditor(inputFile, outputFile))
            {
                CatalogItemList catalogItemList = new CatalogItemList();
                catalogItemList.catalogItemList = new List<ObjectDetectionCatalogItem>();
                IEnumerable<CatalogItem> catalogItems = catalog as CatalogItem[] ?? catalog.ToArray();
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        if (scores[i, j] < minScore)
                        {
                            continue;
                        }

                        for (int k = 0; k < z; k++)
                        {
                            var box = boxes[i, j, k];
                            switch (k)
                            {
                                case 0:
                                    yMin = box;
                                    break;
                                case 1:
                                    xMin = box;
                                    break;
                                case 2:
                                    yMax = box;
                                    break;
                                case 3:
                                    xMax = box;
                                    break;
                            }
                        }
                        int value = Convert.ToInt32(classes[i, j]);
                        CatalogItem catalogItem = catalogItems.FirstOrDefault(item => item.Id == value);
                        //if (catalogItem == null) return null;
                        editor.AddBox(xMin, xMax, yMin, yMax, $"{catalogItem?.Name} : {(scores[i, j] * 100):0}%");
                        ObjectDetectionCatalogItem objectDetectionCatalogItem = new ObjectDetectionCatalogItem
                        {
                            id = catalogItem.Id,
                            Name = catalogItem.Name,
                            Score = scores[i, j] * 100,
                            XMin = xMin,
                            XMax = xMax,
                            YMin = yMin,
                            YMax = yMax
                        };
                        catalogItemList.catalogItemList.Add(objectDetectionCatalogItem);
                    }
                }
                return catalogItemList;
            }
        }



        /// <summary>
        /// Adds rectangle with a label in particular position of the image
        /// </summary>
        /// <param name="xmin"></param>
        /// <param name="xmax"></param>
        /// <param name="ymin"></param>
        /// <param name="ymax"></param>
        /// <param name="text"></param>
        public void AddBox(float xmin, float xmax, float ymin, float ymax, string text = "")
        {
            var left = xmin * _bitmap.Width;
            var right = xmax * _bitmap.Width;
            var top = ymin * _bitmap.Height;
            var bottom = ymax * _bitmap.Height;

            Color color = Color.Red;
            Brush brush = new SolidBrush(color);
            Pen pen = new Pen(brush) { Width = 5 };
            _graphics.DrawRectangle(pen, left, top, right - left, bottom - top);
            var font = new Font(_fontFamily, _fontSize);
            SizeF size = _graphics.MeasureString(text, font);
            _graphics.DrawString(text, font, brush, new PointF(left, top + size.Height));
        }



        public void Dispose()
        {
            if (_bitmap == null) return;
            _bitmap.Save(_outputFile);
            _graphics?.Dispose();
            _inputImage.Dispose();
        }

    }
}
