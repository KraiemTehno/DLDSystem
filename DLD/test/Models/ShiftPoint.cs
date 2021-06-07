using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.Enums;

namespace test.Models
{
    public class ShiftPoint
    {
        public int Id { get; set; }
        public int Page { get; set; }
        public int Word { get; set; }
        public ShiftDirection Direction { get; set; }
        public Credential Credential { get; set; }
        public int CredentialId { get; set; }
    }
}
