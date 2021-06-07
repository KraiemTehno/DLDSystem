using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DLDBussinesLayer.Models
{
    public class Document
    {
        [Key]
        public int DocumentId { get; set; }
        public string FileName { get; set; }
        public DateTime CreateDate { get; set; }
        public string Name { get; set; }
        public int PageSize { get; set; }
        public virtual List<Page> Pages { get; set; }
    }
}
