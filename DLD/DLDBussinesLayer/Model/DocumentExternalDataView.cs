using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLDBussinesLayer.Model
{
    public class DocumentExternalDataView
    {
        [DisplayName("Наименование документа")]
        public string DocName { get; set; }
        [DisplayName("Дата создания копии")]
        public string Date { get; set; }
        [DisplayName("Основание для выдачи")]
        public string Description { get; set; }
    }
}
