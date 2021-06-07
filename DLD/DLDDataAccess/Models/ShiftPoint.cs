using DLD.BussinesLayer.Enums;
 
namespace DLDBussinesLayer.Models
{
    public class ShiftPoint
    {
        public int Id { get; set; }
        public int PageId { get; set; }
        public virtual Page Page { get; set; }
        public int WordId { get; set; }
        public virtual Word Word { get; set; }
        public ShiftDirection Direction { get; set; }
        public virtual Credential Credential { get; set; }
        public int CredentialId { get; set; }
    }
}
