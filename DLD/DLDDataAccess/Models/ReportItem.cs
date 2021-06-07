using DLDBussinesLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLDBussinesLayer.Models
{
    public class ReportItem
    {
        public int Id { get; set; }
        public int CredentialId { get; set; }
        public int PageId { get; set; }
        public int InvestigationId { get; set; }
        public virtual Credential Credential { get; set; }
        public virtual Page Page { get; set; }
        public virtual Investigation Investigation { get; set; }
        public double Ratio { get; set; }
    }
}
