using DLD.DataAccess.Interfaces;
using DLDBussinesLayer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace DLD.DataAccess.Repositories
{
    public class ShiftPointRepository : IShiftPointRepository
    {
        private DataContext context;

        public ShiftPointRepository(IDBConnetcion context)
        {
            this.context = context.GetContext();
        }

        public IEnumerable<ShiftPoint> GetAll()
        {
            return context.ShiftPoints.ToList();
        }

        public ShiftPoint Save(ShiftPoint model)
        {
            context.ShiftPoints.Add(model);
            context.SaveChanges(); 
            var savedPoint = context.ShiftPoints.FirstOrDefault(x => x.Id == model.Id);
            context.Entry(savedPoint).Reference(x => x.Word).Load();
            return savedPoint;
        }
    }
}
