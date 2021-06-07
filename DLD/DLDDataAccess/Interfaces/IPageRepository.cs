using DLDBussinesLayer.Models;
using System.Collections.Generic;

namespace DLD.DataAccess.Interfaces
{
    public interface IPageRepository
    {
        IEnumerable<Page> GetAll();
        Page GetById(int id);
        int Save(Page model);
        int Update(Page model);
        int Delete(int id);
    }
}
