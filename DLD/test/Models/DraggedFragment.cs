using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Models
{
    public class DraggedFragment
    {
        public Rectangle SourceRect;
        public Point Location;

        public Rectangle Rect
        {
            get { return new Rectangle(Location, SourceRect.Size); }
        }

        public Bitmap Fix(Bitmap image)
        {
            using (var clone = (Image)image.Clone(SourceRect, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
            using (var gr = Graphics.FromImage(image))
            {
                gr.SetClip(SourceRect);
                gr.Clear(Color.White);

                gr.SetClip(Rect);
                gr.Clear(Color.Red);
                gr.DrawImage(clone, Location.X, Location.Y);
            }

            return image;
        }
    }
}
