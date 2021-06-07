namespace DLDBussinesLayer.Models
{
    public class Word
    {
        public int Id { get; set; }
        public int PositionOnPage { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int PageId { get; set; }
        public virtual Page Page { get; set; }
    }
}
