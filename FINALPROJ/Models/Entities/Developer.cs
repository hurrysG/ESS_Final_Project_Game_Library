using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FINALPROJ.Models.Entities
{
    public class Developer
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<Game> Games { get; set; }

    }
}