using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using DLDBussinesLayer.Interfaces;
using Tesseract;

namespace DLD.BussinesLayer.Services
{
    public class OcrService : IOcrService
    {
        public List<Rectangle> GetRectanglesOfPage(Bitmap image)
        {
            using (var engine = new TesseractEngine($@"{HttpContext.Current.Server.MapPath("\\Content")}\tessdata", "rus", EngineMode.Default))
            {
                var stream = new MemoryStream();
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Tiff);
                using (var img = Pix.LoadFromMemory(stream.GetBuffer()))
                {
                    using (var page = engine.Process(img))
                    {
                        return page.GetSegmentedRegions(PageIteratorLevel.Word).OrderBy(x=>x.Y).ThenBy(x=>x.X).ToList();
                    }
                }
            }
        }
    }
}
