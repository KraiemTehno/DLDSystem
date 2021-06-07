using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLDBussinesLayer.Model
{
    public class InvestigationView
    {
        public int Id { get; set; }
        [DisplayName("Наименование документа")]
        public string DocumentName { get; set; }
        [DisplayName("Дата проведения экспертизы")]
        public string DateInvastigation { get; set; }
        [DisplayName("Номер страницы по которой проводилась экспертиза")]
        public int PageNumber { get; set; }
        public IEnumerable<ReportItemView> ReportItemsView { get; set; }
    }

    public class ReportItemView
    {
        [DisplayName("Идентификатор пользователя")]
        public string UserId { get; set; }
        [DisplayName("Дата создания копии")]
        public string Create { get; set; }
        [DisplayName("Основание для выдачи")]
        public string Description { get; set; }
        [DisplayName("Процент сходства")]
        public double Ratio { get; set; }
        [DisplayName("Рабочее устройство")]
        public string PCName { get; set; }

    }
}
