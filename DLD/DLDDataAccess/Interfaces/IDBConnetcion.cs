using System;
using System.Collections.Generic;
using System.Text;

namespace DLD.DataAccess.Interfaces
{
    public interface IDBConnetcion
    {
        DataContext GetContext();
    }
}
