using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiMultilayer.DAL.Entities
{
    public class Attachment
    {
        public int Id { get; set; }

        public string Path { get; set; }

        public int AutoId { get; set; }
        public Auto Auto { get; set; }
    }
}
