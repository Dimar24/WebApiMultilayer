using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiMultilayer.BLL.DTO
{
    public class AttachmentDTO
    {
        public int Id { get; set; }

        public string Path { get; set; }

        public int AutoId { get; set; }
        public AutoDTO Auto { get; set; }
    }
}
