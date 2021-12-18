using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FINALPROJ.Models.Entities;

namespace FINALPROJ.Models.Helpers
{
    public class GameHelper
    {
        public static Game CreateGame(string name, string genre, string console, DateTime dateAdded, List<Developer> developers, List<Publisher> publishers){
            var game = new Game{
                Name = name,
                Genre = genre,
                Console = console,
                DateAdded = dateAdded,
                Developers = developers,
                Publishers = publishers
            };
            return (game);

        }
        public static string GetGameByName(List<Game> games, string name){
            var gameResult = games.Where(game=>game.Name == name);
            return($"{gameResult}");
        }
        public static string GetGameByGenre(List<Game> games, string genre){
            var gameResult = games.Where(game => game.Genre == genre).ToList();
            return ($"{gameResult}");
        }
        public static string GetGameByConsole(List<Game> games, string console){
            var gameResult = games.Where(game => game.Console == console).ToList();
            return ($"{gameResult}");
        }
        public static string GetGameByDeveloper(List<Developer> developers, string developer){
            var developerResult = developers.Where(dev => dev.Name == developer).ToList();
            return ($"{developerResult}");
        }
        public static string GetGameByPublisher(List<Publisher> publishers, string publisher){
            var publisherResult = publishers.Where(pub => pub.Name == publisher).ToList();
            return ($"{publisherResult}");
        }

    }
}