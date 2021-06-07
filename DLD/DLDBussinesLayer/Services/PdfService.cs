using DLDBussinesLayer.Interfaces;
using DLDBussinesLayer.Services;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace DLD.BussinesLayer.Services
{
    public class PdfService : IPdfService
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
    }
}
