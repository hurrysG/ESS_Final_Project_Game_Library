using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FINALPROJ.Models;
using FINALPROJ.Models.DTOs;
using FINALPROJ.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FINALPROJ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeveloperController : ControllerBase
    {
        private readonly DataContext _context;

        public DeveloperController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult GetAllDevelopers()
        {
            List<DeveloperDTO> res = new List<DeveloperDTO>();
            foreach (var developer in _context.Developers)
            {
                res.Add(DeveloperDTO.ParseFrom(developer));
            }
            return Ok(res);
        }

        [HttpPost]
        [Route("{name}")]
        public async Task<IActionResult> AddDeveloper(string name)
        {
            System.Console.WriteLine(name);
            Developer newDeveloper = new Developer()
            {
                Name = name
            };
            _context.Developers.Add(newDeveloper);
            await _context.SaveChangesAsync();
            return Ok();
        }




    }
}