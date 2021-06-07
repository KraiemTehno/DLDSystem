using DLD.DataAccess.Interfaces;
using DLDBussinesLayer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace DLD.DataAccess.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private DataContext context;

        public DocumentRepository(IDBConnetcion context)
        {
            this.context = context.GetContext();
        }

        public IEnumerable<Document> GetAll()
        {
            return context.Documents.ToList();
        }

        public Document GetByDocumentId(int documentId)
        {
            return context.Documents.FirstOrDefault(x => x.DocumentId == documentId);
        }

        public int Save(Document model)
        {
            context.Documents.Add(model);
            context.SaveChanges();
            return model.DocumentId;
        }

        public int Update(Document model)
        {
            var doc = context.Documents.FirstOrDefault(x => x.DocumentId == model.DocumentId);
            doc.Name = model.Name;
            doc.DocumentId = model.DocumentId;
            doc.PageSize = model.PageSize;
            doc.FileName = model.FileName;
            return context.SaveChanges();
        }

        public int Delete(int DocumentId)
        {
            var model = context.Documents.FirstOrDefault(x => x.DocumentId == DocumentId);
            context.Documents.Remove(model);
            return context.SaveChanges();
        }
    }
}
