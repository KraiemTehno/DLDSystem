using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.Models;

namespace test.Managers
{
    public class RenderManager
    {
        private PdfManager pdfManager;
        private SQLManager sqlManager;
        private Credential credential;
        private Random rand;
        private DraggedFragment draggedFragment;

        public RenderManager(Credential credential, SQLManager sqlManager)
        {
            pdfManager = new PdfManager();
            this.credential = credential;
            this.sqlManager = sqlManager;
            rand = new Random();
        }

        public byte[] Engine(byte[] pdfDocument)
        {
            var pages = pdfManager.GetImagesFromPdf(pdfDocument);

            for (int i = 0; i < pages.Count; i++)
            {
                //var rectangles = ocrManager.GetCertanglesOfPage(pages[i]);
                //pages[i] = Convert(pages[i], rectangles, i);
            }

            return pdfManager.GetPdfFromImages(pages);
        }

        private Bitmap Convert(Bitmap image, List<Rectangle> rectangles, int indexPage)
        {
            var points = new List<ShiftPoint>();
            var randRectabgles = new int[(int)(rectangles.Count * 0.25)].Select(x=> rand.Next(5,rectangles.Count-10)).Distinct().ToArray();

            for (int i = 0; i < randRectabgles.Length; i++)
            {
                points.Add(new ShiftPoint
                {
                    Word = randRectabgles[i],
                    Direction = (Enums.ShiftDirection)rand.Next(1,4),
                    Page = indexPage,
                    Credential = credential,
                    CredentialId = credential.Id
                });
            }
            
            foreach (var item in points)
            {
                sqlManager.WriteShiftPoint(item);
                draggedFragment = new DraggedFragment() { SourceRect = rectangles[item.Word], Location = rectangles[item.Word].Location };

                var left = item.Direction == Enums.ShiftDirection.Left
                    ? -1
                    : item.Direction == Enums.ShiftDirection.Right
                    ? 1 : 0;
                var top = item.Direction == Enums.ShiftDirection.Top
                    ? -1
                    : item.Direction == Enums.ShiftDirection.Bottom
                    ? 1 : 0;
                draggedFragment.Location.Offset(left, top);
                image = draggedFragment.Fix(image);
            }

            return image;
        }
    }
}
