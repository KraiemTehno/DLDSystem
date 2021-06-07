using System.Collections.Generic;

namespace DLDBussinesLayer.Models
{
    public class Page
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int DocumentId { get; set; }
        public double Ratio { get; set; }
        public virtual Document Document { get; set; }
        public virtual List<Word> Words { get; set; }
        public virtual ImagePage ImagePage { get; set; }
        public int ImagePageId { get; set; }
    }
}
