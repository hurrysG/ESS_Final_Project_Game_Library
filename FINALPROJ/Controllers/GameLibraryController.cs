using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FINALPROJ.Models;
using FINALPROJ.Models.DTOs;
using FINALPROJ.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FINALPROJ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameLibraryController : ControllerBase
    {
        private readonly DataContext _context;

        public GameLibraryController(DataContext context)
        {
            this._context = context;
        }

        // Todo: Created by Yuanfu
        // Todo: Delete this method when finish
        // Method for testing.
        [HttpGet]
        [Route("guid")]
        public IActionResult GetNewGUID()
        {
            return Ok(Guid.NewGuid());
        }

        // Todo: Created by Yuanfu
        // Todo: Delete this method when finish
        // Method for testing
        [HttpDelete]
        [Route("deleteall")]
        public async Task<IActionResult> DeleteAll()
        {
            foreach (var g in _context.Games)
            {
                _context.Games.Remove(g);
            }
            await _context.SaveChangesAsync();


            foreach (var p in _context.Publishers)
            {
                _context.Publishers.Remove(p);
            }
            await _context.SaveChangesAsync();

            foreach (var d in _context.Developers)
            {
                _context.Developers.Remove(d);
            }
            await _context.SaveChangesAsync();


            return Ok("Deleted All");
        }

        // Todo: Created by Yuanfu
        // Todo: Delete this method when finish
        // Method for testing
        [HttpPost]
        [Route("PostTestData")]
        public async Task<IActionResult> PostTestData()
        {
            Publisher valve = new Publisher
            {
                Id = new Guid("61a0c2b0-d545-4812-b5e0-157035224500"),
                Name = "Valve Corporation"
            };

            Publisher blizzard = new Publisher
            {
                Id = new Guid("384b3825-ee09-4696-b496-3c090abc611e"),
                Name = "Activision Blizzard"
            };

            Publisher ea = new Publisher
            {
                Id = new Guid("b8674213-f83d-4286-a6fe-d603949a9cc9"),
                Name = "Electronic Arts (EA)"
            };

            _context.Publishers.Add(valve);
            _context.Publishers.Add(blizzard);
            _context.Publishers.Add(ea);
            await _context.SaveChangesAsync();


            Developer james = new Developer
            {
                Id = new Guid("a1214900-c844-4104-b154-f37bcb714508"),
                Name = "James"
            };

            Developer john = new Developer
            {
                Id = new Guid("692c8916-0847-4b2b-830b-4f9ac2455f9c"),
                Name = "John"
            };

            Developer emma = new Developer
            {
                Id = new Guid("b98b5844-bd8f-4ba2-aced-37dbf8ec9fe5"),
                Name = "Emma"
            };

            Developer mia = new Developer
            {
                Id = new Guid("6aa1a115-66bc-41f9-8d75-9cebe817a516"),
                Name = "Mia"
            };

            _context.Developers.Add(james);
            _context.Developers.Add(john);
            _context.Developers.Add(emma);
            _context.Developers.Add(mia);
            await _context.SaveChangesAsync();

            valve = _context.Publishers.FirstOrDefault(p => p.Name.Equals("Valve Corporation"));
            blizzard = _context.Publishers.FirstOrDefault(p => p.Name.Equals("Activision Blizzard"));
            ea = _context.Publishers.FirstOrDefault(p => p.Name.Equals("Electronic Arts (EA)"));

            james = _context.Developers.FirstOrDefault(d => d.Name.Equals("James"));
            john = _context.Developers.FirstOrDefault(d => d.Name.Equals("John"));
            emma = _context.Developers.FirstOrDefault(d => d.Name.Equals("Emma"));
            mia = _context.Developers.FirstOrDefault(d => d.Name.Equals("Mia"));

            Game starcraft = new Game
            {
                Id = new Guid("53db5512-5961-4aa2-a783-9a3f51082dc6"),
                Name = "Starcraft",
                Genre = "Strategy",
                Console = "PC",
                dateAdded = new DateTime(2005, 5, 1),
                Developer = new List<Developer>()
                {
                    james,
                    emma
                },
                Publisher = blizzard
            };

            Game footballManager = new Game
            {
                Id = new Guid("8ab7a83b-9893-4574-9793-f7769ba00894"),
                Name = "Football Manager",
                Genre = "Sport",
                Console = "PC",
                dateAdded = new DateTime(2010, 7, 1),
                Developer = new List<Developer>()
                {
                    james,
                    mia
                },
                Publisher = ea
            };

            Game hearthstone = new Game
            {
                Id = new Guid("ece4060e-e8db-493d-9a64-b8326bcd43bf"),
                Name = "Hearthstone",
                Genre = "Sport",
                Console = "iOS",
                dateAdded = new DateTime(2014, 10, 1),
                Developer = new List<Developer>()
                {
                    john,
                    mia
                },
                Publisher = blizzard
            };

            await _context.Games.AddAsync(starcraft);
            await _context.Games.AddAsync(footballManager);
            await _context.Games.AddAsync(hearthstone);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetGame(string id)
        {
            Guid guid;
            try
            {
                guid = new Guid(id);
            }
            catch (Exception)
            {
                dynamic res = new
                {
                    message = "Invalid id"
                };
                return BadRequest(res);
            }
            var game = _context.Games.Include(g => g.Developer).Include(g => g.Publisher).FirstOrDefault(g => g.Id.Equals(guid));

            if (game != null)
            {
                return Ok(GameDTO.ParseFrom(game));
            }
            else
            {
                return NotFound(new
                {
                    message = "Game not found"
                });
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteGame(string id)
        {
            Guid guid;
            try
            {
                guid = new Guid(id);
            }
            catch (Exception)
            {
                dynamic res = new
                {
                    message = "Invalid id"
                };
                return BadRequest(res);
            }
            var game = _context.Games.FirstOrDefault(g => g.Id.Equals(guid));

            if (game != null)
            {
                _context.Games.Remove(game);
                await _context.SaveChangesAsync();
                dynamic res = new
                {
                    messsage = "Successfully deleted"
                };
                return Ok(res);
            }
            else
            {
                dynamic res = new
                {
                    message = "Game not found"
                };
                return NotFound(res);
            }
        }

        [HttpGet]
        [Route("compare/{id1}/{id2}")]
        public IActionResult CompareTwoGames(string id1, string id2)
        {
            Guid guid1;
            Guid guid2;
            try
            {
                guid1 = new Guid(id1);
                guid2 = new Guid(id2);
            }
            catch (Exception)
            {
                dynamic res = new
                {
                    message = "Invalid Id"
                };
                return BadRequest(res);
            }

            Game game1 = _context.Games.Include(g => g.Developer).Include(g => g.Publisher).FirstOrDefault(g => g.Id.Equals(guid1));
            Game game2 = _context.Games.Include(g => g.Developer).Include(g => g.Publisher).FirstOrDefault(g => g.Id.Equals(guid2));

            if (game1 != null && game2 != null)
            {
                List<GameDTO> list = new List<GameDTO>(){
                    GameDTO.ParseFrom(game1),
                    GameDTO.ParseFrom(game2)
                };

                return Ok(list);
            }
            else
            {
                dynamic res = new
                {
                    message = "Game not found"
                };
                return NotFound(res);
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateGame([FromBody] GameDTO gameDto)
        {
            Guid gameId;
            try
            {
                gameId = new Guid(gameDto.Id);
            }
            catch (Exception)
            {
                dynamic res = new
                {
                    message = "Invalid Id"
                };
                return BadRequest(res);
            }

            Game game = _context.Games.Include(g => g.Developer).Include(g => g.Publisher).FirstOrDefault(g => g.Id.Equals(gameId));

            if (game != null)
            {
                return NotFound(new
                {
                    message = "Game not found"
                });
            }
            else
            {
                game.Name = gameDto.Name;
                game.Genre = gameDto.Genre;
                game.Console = gameDto.Console;
                game.dateAdded = gameDto.DateAdded;
                game.Developer = new List<Developer>();
                foreach (var d in game.Developer)
                {
                    game.Developer.Remove(d);
                }

                foreach (var d in gameDto.Developers)
                {
                    var dev = _context.Developers.FirstOrDefault(developer => developer.Id.Equals(new Guid(d.Id)));
                    if (dev != null)
                    {
                        game.Developer.Add(dev);
                    }
                }

                var pub = _context.Publishers.FirstOrDefault(p => p.Id.Equals(new Guid(gameDto.Publisher.Id)));
                game.Publisher = pub;

                await _context.SaveChangesAsync();

                return Ok(GameDTO.ParseFrom(game));
            }
        }

    }
}