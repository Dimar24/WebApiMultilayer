using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiMultilayer.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }

        public int Login { get; set; }
        public int Email { get; set; }
        public int Password { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public List<Auto> Autos { get; set; }

        public ProfileInfo Profile { get; set; }
    }
}
