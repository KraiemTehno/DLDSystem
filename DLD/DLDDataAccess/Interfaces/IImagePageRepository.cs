using DLDBussinesLayer.Models;
using System.Collections.Generic;

namespace DLD.DataAccess.Interfaces
{
    public interface IImagePageRepository
    {
        IEnumerable<ImagePage> GetAll();
        ImagePage GetById(int id);
        int Save(ImagePage model);
        int Update(ImagePage model);
        int Delete(int id);
    }
}
