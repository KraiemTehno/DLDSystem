
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using test.Models;

namespace test.Managers
{
    public class PdfManager
    {
        private int dpi = 300;

        public List<Bitmap> GetImagesFromPdf(byte[] pdfDocument)
        {
            var list = new List<Bitmap>();
            var fileStream = new MemoryStream(pdfDocument);
            
            using (var doc = PdfiumViewer.PdfDocument.Load(fileStream))
            {
                for (int i = 0; i < doc.PageCount; i++)
                {
                    using (var bitmap = doc.Render(i, dpi, dpi, PdfiumViewer.PdfRenderFlags.CorrectFromDpi))
                    {
                        list.Add((Bitmap)bitmap.Clone());
                        list[list.Count - 1] = ToBlack(list[list.Count - 1]);
                    }
                }
            }

            return list;
        }

        public byte[] GetPdfFromImages(List<Bitmap> pages)
        {
            using (var stream = new MemoryStream())
            using (var document = new PdfDocument())
            {
                for (int i = 0; i < pages.Count; i++)
                {
                    var page = document.AddPage();
                    using (var imageStream = new MemoryStream())
                    {
                        pages[i].Save(imageStream, ImageFormat.Bmp);

                        using (var img = XImage.FromStream(imageStream))
                        {
                            //page.Width = new XUnit {Point = img.PointWidth };
                            //page.Height = new XUnit {Point = img.PointHeight };
                            var gfx = XGraphics.FromPdfPage(page, XGraphicsPdfPageOptions.Replace);
                            gfx.DrawImage(img, 0, 0);
                        }
                    }
                }
                document.Save(stream);
                return stream.ToArray();
            }
        }

        private Bitmap ToBlack(Bitmap image)
        {
            for (int row = 0; row < image.Width; row++) 
            {
                for (int column = 0; column < image.Height; column++) 
                {
                    var colorValue = image.GetPixel(row, column); 
                    var averageValue = ((int)colorValue.R + (int)colorValue.B + (int)colorValue.G) / 3; 
                    image.SetPixel(row, column, Color.FromArgb(averageValue, averageValue, averageValue)); 
                }
            }
            return image;
        }
    }
}
