using System.Collections.Generic;
using System.Drawing;

namespace DLDBussinesLayer.Interfaces
{
    public interface IPdfService
    {
        List<Bitmap> GetImagesFromPdf(byte[] pdfDocument);
        byte[] GetPdfFromImages(List<Bitmap> pages);
    }
}
