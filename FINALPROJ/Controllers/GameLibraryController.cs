using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FINALPROJ.Models;
using FINALPROJ.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using FINALPROJ.Models.Helpers;

namespace FINALPROJ.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameLibraryController : ControllerBase
    {
        private readonly DataContext _context;

        public GameLibraryController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IActionResult GetAllGames(){
            return Ok(_context.Games);

        }

        [HttpPost]
        public async Task<IActionResult> CreateGame(
                Game game
        ){
            if(string.IsNullOrEmpty(game.Name))
                return BadRequest();

                

            // var game = new Game{
            //     Name = name,
            //     Genre = genre,
            //     Console = console,
            //     DateAdded = dateAdded,
            //     Developers = developers,
            //     Publishers = publishers
            // };
            //Neccessary?
            // game.Developers.AddRange(developers);
            // game.Publishers.AddRange(publishers);
            await _context.AddAsync(game);
            await _context.SaveChangesAsync();
            return Ok(game);
        }


        [HttpGet("{name}")]
        public async Task<IActionResult> SearchGame(string name){
            var gameList = await _context.Games.ToListAsync();
            try{
                var searchResult = gameList.FirstOrDefault(x=> x.Name == name);
            
                if (searchResult == null)
                    return NotFound(searchResult);
                return Ok($"This works : {searchResult.Name}");
            }catch (SystemException){
                return BadRequest();
            }
        }

        [HttpGet("genre/{genre}")]
        public async Task<IActionResult> GetGameGenre(string genre){
            var gameList = await _context.Games.ToListAsync();
            try{
                var result = GameHelper.GetGameByGenre(gameList,genre);

                return Ok(result);
                
            }catch (SystemException){
                return BadRequest();
            }
        }

        [HttpGet("console/{console}")]
        public async Task<IActionResult> GetGameConsole(string console){
            var gameList = await _context.Games.ToListAsync();
            try{
                var result = GameHelper.GetGameByConsole(gameList,console);
                return Ok(result);
            }catch (SystemException){
                return BadRequest();
            }
        }

        [HttpGet("developers/{developer}")]
        public async Task<IActionResult> GetGameDeveloper(string developer){
            var developerList = await _context.Developers.ToListAsync();
            var result = GameHelper.GetGameByDeveloper(developerList, developer);
            return Ok(result);

        }

        // [HttpGet("publishers")]
        // public async Task<IActionResult> GetGamePublisher(string publisher){
        //     var publisherList = await _context.Publishers.ToListAsync();
        //     var result = GameHelper.GetGameByPublisher(publisherList, publisher);
        //     return Ok(result);
        // }

  

        
    }
}