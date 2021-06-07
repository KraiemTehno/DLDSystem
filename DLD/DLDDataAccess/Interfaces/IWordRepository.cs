using DLDBussinesLayer.Models;
using System.Collections.Generic;

namespace DLD.DataAccess.Interfaces
{
    public interface IWordRepository
    {
        IEnumerable<Word> GetAll();
        Word GetById(int id);
        int Save(Word model);
        int Update(Word model);
        int Delete(int id);
    }
}
