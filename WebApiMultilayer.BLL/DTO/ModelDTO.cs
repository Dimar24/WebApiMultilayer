using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiMultilayer.BLL.DTO
{
    public class ModelDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int MarkId { get; set; }
        public MarkDTO Mark { get; set; }

        public List<AutoDTO> Autos { get; set; }
    }
}
