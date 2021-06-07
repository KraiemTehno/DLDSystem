using DLD.DataAccess.Interfaces;
using DLDBussinesLayer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace DLD.DataAccess.Repositories
{
    public class ImagePageRepository: IImagePageRepository
    {
        private DataContext context;

        public ImagePageRepository(IDBConnetcion context)
        {
            this.context = context.GetContext();
        }

        public IEnumerable<ImagePage> GetAll()
        {
            return context.ImagePages.ToList();
        }

        public ImagePage GetById(int id)
        {
            return context.ImagePages.FirstOrDefault(x => x.Id == id);
        }

        public int Save(ImagePage model)
        {
            context.ImagePages.Add(model);
            context.SaveChanges();
            return model.Id;
        }

        public int Update(ImagePage model)
        {
            var doc = context.ImagePages.FirstOrDefault(x => x.Id == model.Id);
            doc.Path = model.Path;
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            var model = context.ImagePages.FirstOrDefault(x => x.Id == id);
            context.ImagePages.Remove(model);
            return context.SaveChanges();
        }
    }
}
