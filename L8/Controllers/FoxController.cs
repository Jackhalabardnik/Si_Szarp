using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using L8.Data;
using L8.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace L8.Controllers
{
    [Route("api/fox")]
    [ApiController]
    public class FoxController : ControllerBase
    {
        private readonly ILogger<FoxController> _logger;
        private readonly IFoxesRepository _repo;
        
        public FoxController(ILogger<FoxController> logger, IFoxesRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            return CreatedAtAction(nameof(Get), _repo.GetAll().OrderByDescending(fox => fox.Loves).ThenBy(fox => fox.Hates));
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var fox = _repo.Get(id);

            if (fox == null)
                return NotFound();
            
            return CreatedAtAction(nameof(Get), _repo.Get(id));
        }
        
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] Fox fox)
        {
            _repo.Add(fox);

            return CreatedAtAction(nameof(Get), new { id = fox.Id }, fox);
        }
        
        [HttpPut("love/{id}")]
        [Authorize]
        public IActionResult Love(int id)
        {
            var fox = _repo.Get(id);

            if (fox == null)
                return NotFound();

            fox.Loves++;
            _repo.Update(id, fox);

            return Ok(fox);
        }
        
        [HttpPut("hate/{id}")]
        [Authorize]
        public IActionResult Hate(int id)
        {
            var fox = _repo.Get(id);

            if (fox == null)
                return NotFound();

            fox.Hates++;
            _repo.Update(id, fox);

            return Ok(fox);
        }


    }
}
