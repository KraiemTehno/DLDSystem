using DLDBussinesLayer.Models;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace DLDBussinesLayer.Interfaces
{
    public interface IAnalizeService
    {
        Investigation Engine(int documentId, int pageNumber, Rectangle rectangleOrigin, Rectangle rectangleFragment, Bitmap inside);
        Investigation GetInvestigation(int id);
        IEnumerable<Investigation> GetInvestigations(DateTime date, int documentId);
        int GetRatioBlack(Bitmap image);
    }
}
