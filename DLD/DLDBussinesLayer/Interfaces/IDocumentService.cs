using DLDBussinesLayer.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLDBussinesLayer.Interfaces
{
    public interface IDocumentService
    {
        string GetDocumentName(int documentId);
        IEnumerable<DocumentDataView> GetDocuments(string documentName);
        IEnumerable<DocumentExternalDataView> GetExternalDocuments(string documentName);
        void CreateNewDataOfDocument(string path, int documentId, string name, string fileName);
        Image GetImageOrigin(int documenId, int pageNumber);
        int GetDocumentPageSize(int documentId);
        IEnumerable<WordViewModel> GetImageRectanglesOrigin(int documenId, int pageNumber);
        IEnumerable<WordViewModel> GetImageRectanglesFragment(string fileName);
    }
}
