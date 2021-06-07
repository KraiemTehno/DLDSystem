using DLDBussinesLayer.Models;
using System.Collections.Generic;

namespace DLD.DataAccess.Interfaces
{
    public interface IInvestigationRepository
    {
        IEnumerable<Investigation> GetAll();
        Investigation GetById(int id);
        int Save(Investigation model);
    }
}
