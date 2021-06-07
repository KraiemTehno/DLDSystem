using DLDBussinesLayer.Models;
using System.Drawing;

namespace DLDBussinesLayer.Interfaces
{
    public interface IRenderService
    {
        byte[] Engine(Credential credential);
        Bitmap EnginePageAnalize(Credential credential, int pageNumber, Rectangle rectangle);
    }
}
