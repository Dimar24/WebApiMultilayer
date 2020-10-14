using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiMultilayer.DAL.Entities
{
    public class ClientProfile
    {
        [Key]
        [ForeignKey("User")]
        public string Id { get; set; }

        public string NumberPhone { get; set; }

        public List<Auto> Autos { get; set; }
        public User User { get; set; }
    }
}
