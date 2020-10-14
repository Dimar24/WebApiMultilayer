using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiMultilayer.BLL.DTO
{
    public class AutoDTO
    {
        public int Id { get; set; }

        public string Color { get; set; }
        public int EnginyCapacity { get; set; }
        public string EnginyType { get; set; }
        public string Transmition { get; set; }
        public string Location { get; set; }
        public int MaxSpeed { get; set; }
        public int Year { get; set; }

        public int ModelId { get; set; }
        public ModelDTO Model { get; set; }
        public int OwnerId { get; set; }
        public UserDTO user { get; set; }

        public List<AttachmentDTO> Attachments { get; set; }
    }
}
