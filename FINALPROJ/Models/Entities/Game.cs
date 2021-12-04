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
        public DateTime dateAdded { get; set; }
        public List<Developer> Developer { get; set; }
        public Publisher Publisher { get; set; }
    }
}