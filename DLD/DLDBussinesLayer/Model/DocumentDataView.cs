using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLDBussinesLayer.Model
{
    public class DocumentDataView
    {
        [DisplayName("Наименование документа")]
        public string DocName { get; set; }
        [DisplayName("Дата создания документа")]
        public string Date { get; set; }
        public int DocumentId { get; set; }
        public int PageSize { get; set; }
    }
}
