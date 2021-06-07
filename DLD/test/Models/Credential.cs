using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Models
{
    public class Credential
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DocumentId { get; set; }
        public DateTime Create { get; set; }
    }
}
