using DLDBussinesLayer.Models;
using System.Collections.Generic;

namespace DLD.DataAccess.Interfaces
{
    public interface IReportItemRepository
    {
        IEnumerable<ReportItem> GetAll();
        void Save(IEnumerable<ReportItem> model);
    }
}
