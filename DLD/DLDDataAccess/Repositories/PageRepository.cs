using DLD.DataAccess.Interfaces;
using DLDBussinesLayer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace DLD.DataAccess.Repositories
{
    public class PageRepository : IPageRepository
    {
        private DataContext context;

        public PageRepository(IDBConnetcion context)
        {
            this.context = context.GetContext();
        }

        public IEnumerable<Page> GetAll()
        {
            return context.Pages.ToList();
        }

        public Page GetById(int id)
        {
            return context.Pages.FirstOrDefault(x => x.Id == id);
        }

        public int Save(Page model)
        {
            context.Pages.Add(model);
            context.SaveChanges();
            return model.Id;
        }

        public int Update(Page model)
        {
            var doc = context.Pages.FirstOrDefault(x => x.Id == model.Id);
            doc.DocumentId = model.DocumentId;
            doc.ImagePageId = model.ImagePageId;
            doc.Number = model.Number;
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            var model = context.Pages.FirstOrDefault(x => x.Id == id);
            context.Pages.Remove(model);
            return context.SaveChanges();
        }
    }
}
