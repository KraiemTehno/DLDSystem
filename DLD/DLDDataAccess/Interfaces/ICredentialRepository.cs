using DLDBussinesLayer.Models;
using System.Collections.Generic;

namespace DLD.DataAccess.Interfaces
{
    public interface ICredentialRepository
    {
        IEnumerable<Credential> GetAll();
        Credential GetById(int id);
        int Save(Credential model);
    }
}
