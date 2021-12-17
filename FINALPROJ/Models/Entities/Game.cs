using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FINALPROJ.Models.Entities
{
    public class Game
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Genre { get; set; }
        public String Console { get; set; }
        public DateTime DateAdded { get; set; }
        public List<Developer> Developers { get; set; }
        public List<Publisher> Publishers { get; set; }
    }
}