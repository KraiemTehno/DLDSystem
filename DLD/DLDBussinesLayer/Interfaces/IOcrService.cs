using System.Collections.Generic;
using System.Drawing;

namespace DLDBussinesLayer.Interfaces
{
    public interface IOcrService
    {
        List<Rectangle> GetRectanglesOfPage(Bitmap image);
    }
}
