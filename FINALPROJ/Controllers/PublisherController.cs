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
    public class PublisherController : ControllerBase
    {
        private readonly DataContext _context;

        public PublisherController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult GetAllPublishers()
        {
            List<PublisherDTO> res = new List<PublisherDTO>();
            foreach (var publisher in _context.Publishers)
            {
                res.Add(PublisherDTO.ParseFrom(publisher));
            }
            return Ok(res);
        }

        [HttpPost]
        [Route("{name}")]
        public async Task<IActionResult> AddPublisher(string name)
        {
            System.Console.WriteLine(name);
            Publisher newPublisher = new Publisher()
            {
                Name = name
            };
            _context.Publishers.Add(newPublisher);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}