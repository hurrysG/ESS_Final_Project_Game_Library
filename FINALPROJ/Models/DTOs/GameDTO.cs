using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FINALPROJ.Models.Entities;

namespace FINALPROJ.Models.DTOs
{
    public class GameDTO
    {
        public string Id { get; set; }
        public String Name { get; set; }
        public String Genre { get; set; }
        public String Console { get; set; }
        public DateTime DateAdded { get; set; }
        public List<DeveloperDTO> Developers { get; set; }
        public PublisherDTO Publisher { get; set; }

        public static GameDTO ParseFrom(Game game)
        {
            return new GameDTO()
            {
                Id = game.Id.ToString(),
                Name = game.Name,
                Genre = game.Genre,
                Console = game.Console,
                DateAdded = game.dateAdded,
                Developers = game.Developer.Select(d => DeveloperDTO.ParseFrom(d)).ToList(),
                Publisher = PublisherDTO.ParseFrom(game.Publisher)
            };
        }
    }
}