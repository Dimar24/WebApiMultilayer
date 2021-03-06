﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiMultilayer.DAL.Entities
{
    public class Model
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int MarkId { get; set; }
        public Mark Mark { get; set; }

        public List<Auto> Autos { get; set; }
    }
}
