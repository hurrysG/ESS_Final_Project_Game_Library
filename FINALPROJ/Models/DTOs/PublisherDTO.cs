using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FINALPROJ.Models.Entities;

namespace FINALPROJ.Models.DTOs
{
    public class PublisherDTO
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public static PublisherDTO ParseFrom(Publisher publisher)
        {
            return new PublisherDTO
            {
                Id = publisher.Id.ToString(),
                Name = publisher.Name
            };
        }
    }
}