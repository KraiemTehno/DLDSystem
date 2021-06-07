using DLD.DataAccess.Interfaces;
using System;

namespace DLD.DataAccess
{
    public class DBConnetcion : IDBConnetcion
    {
        DataContext context = new DataContext();
        public DataContext GetContext() { return context; }
    }
}
