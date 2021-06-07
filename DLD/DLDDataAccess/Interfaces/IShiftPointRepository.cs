using DLDBussinesLayer.Models;
using System.Collections.Generic;

namespace DLD.DataAccess.Interfaces
{
    public interface IShiftPointRepository
    {
        IEnumerable<ShiftPoint> GetAll();
        ShiftPoint Save(ShiftPoint model);
    }
}
