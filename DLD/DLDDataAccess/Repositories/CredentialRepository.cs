using DLD.DataAccess.Interfaces;
using DLDBussinesLayer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace DLD.DataAccess.Repositories
{
    public class CredentialRepository : ICredentialRepository
    {
        private DataContext context;

        public CredentialRepository(IDBConnetcion context)
        {
            this.context = context.GetContext();
        }

        public IEnumerable<Credential> GetAll()
        {
            return context.Credentials
                .Include(x => x.Points)
                .ToList();
        }

        public Credential GetById(int id)
        {
            return context.Credentials
                .Include(x => x.Points)
                .FirstOrDefault(x => x.Id == id);
        }

        public int Save(Credential model)
        {
            context.Credentials.Add(model);
            context.SaveChanges();
            return model.Id;
        }
    }
}
