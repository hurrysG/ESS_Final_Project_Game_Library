using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FINALPROJ.Models.Entities;

namespace FINALPROJ.Models.DTOs
{
    public class DeveloperDTO
    {
        public string Id { get; set; }

        public string Name { get; set; }


        public static DeveloperDTO ParseFrom(Developer developer)
        {
            return new DeveloperDTO
            {
                Id = developer.Id.ToString(),
                Name = developer.Name
            };
        }
    }
}