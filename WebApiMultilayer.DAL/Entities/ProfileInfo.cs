using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiMultilayer.DAL.Entities
{
    public class ProfileInfo
    {
        public int Id { get; set; }

        public string NumberPhone { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
