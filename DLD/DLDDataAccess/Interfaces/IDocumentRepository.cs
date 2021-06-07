using DLDBussinesLayer.Models;
using System.Collections.Generic;

namespace DLD.DataAccess.Interfaces
{
    public interface IDocumentRepository
    {
        IEnumerable<Document> GetAll();
        Document GetByDocumentId(int documentId);
        int Save(Document model);
        int Update(Document model);
        int Delete(int id);
    }
}
