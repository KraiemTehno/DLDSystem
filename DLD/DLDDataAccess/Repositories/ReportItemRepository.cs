using DLD.DataAccess.Interfaces;
using DLDBussinesLayer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace DLD.DataAccess.Repositories
{
    public class ReportItemRepository : IReportItemRepository
    {
        private DataContext context;

        public ReportItemRepository(IDBConnetcion context)
        {
            this.context = context.GetContext();
        }

        public IEnumerable<ReportItem> GetAll()
        {
            return context.ReportItems.ToList();
        }

        public void Save(IEnumerable<ReportItem> model)
        {
            context.ReportItems.AddRange(model);
            context.SaveChanges();
        }
    }
}

