using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiMultilayer.DAL.Entities
{
    public class Auto
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
        public Model Model { get; set; }
        public string OwnerId { get; set; }
        public ClientProfile clientProfile { get; set; }

        public List<Attachment> Attachments { get; set; }
    }
}
