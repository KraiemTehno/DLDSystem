using DLD.DataAccess.Interfaces;
using DLDBussinesLayer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace DLD.DataAccess.Repositories
{
    public class WordRepository : IWordRepository
    {
        private DataContext context;

        public WordRepository(IDBConnetcion context)
        {
            this.context = context.GetContext();
        }

        public IEnumerable<Word> GetAll()
        {
            return context.Words.ToList();
        }

        public Word GetById(int id)
        {
            return context.Words.FirstOrDefault(x => x.Id == id);
        }

        public int Save(Word model)
        {
            context.Words.Add(model);
            context.SaveChanges();
            return model.Id;
        }

        public int Update(Word model)
        {
            var doc = context.Words.FirstOrDefault(x => x.Id == model.Id);
            doc.X = model.X;
            doc.Y = model.Y;
            doc.PageId = model.PageId;
            doc.PositionOnPage = model.PositionOnPage;
            doc.Width = model.Width;
            doc.Height = model.Height;
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            var model = context.Words.FirstOrDefault(x => x.Id == id);
            context.Words.Remove(model);
            return context.SaveChanges();
        }
    }
}
