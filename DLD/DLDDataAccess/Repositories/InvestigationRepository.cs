using DLD.DataAccess.Interfaces;
using DLDBussinesLayer.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DLD.DataAccess.Repositories
{
    public class InvestigationRepository : IInvestigationRepository
    {
        private DataContext context;

        public InvestigationRepository(IDBConnetcion context)
        {
            this.context = context.GetContext();
        }

        public IEnumerable<Investigation> GetAll()
        {
            return context.Investigations.ToList();
        }

        public Investigation GetById(int id)
        {
            return context.Investigations
                .Include(x=>x.Document)
                .Include(x=>x.Page)
                .Include(x=>x.ReportItems)
                .FirstOrDefault(x => x.Id == id);
        }

        public int Save(Investigation model)
        {
            context.Investigations.Add(model);
            context.SaveChanges();
            return model.Id;
        }
    }
}