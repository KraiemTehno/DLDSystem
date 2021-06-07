using System;
using System.Collections.Generic;

namespace DLDBussinesLayer.Models
{
    public class Investigation
    {
        public int Id { get; set; }
        public DateTime DateInvestigation { get; set; }
        public int DocumentId { get; set; }
        public int PageId { get; set; }
        public virtual Document Document { get; set; }
        public virtual Page Page { get; set; }
        public virtual ICollection<ReportItem> ReportItems { get; set; }
    }
}
