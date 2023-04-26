using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChordsAPI.Models;

namespace MyFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FingeringController : ControllerBase
    {
        private readonly ChordsAPIDBContext _context;

        public FingeringController(ChordsAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/fingering
        [HttpGet]
        public async Task<ActionResult<Response>> GetFingerings()
        {
            var fingerings = await _context.Fingerings.ToListAsync();
            var response = new Response();
            response.statusCode = 400;
            response.statusDescription = "BadRequest: no fingerings found.";
            if (fingerings != null && fingerings.Count != 0)
            {
                response.statusCode = 200;
                response.statusDescription = "OK: fingerings found.";
                response.fingerings = fingerings;
            }

            return response;
        }

        // GET: api/fingering/A
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetFingering(string id)
        {
            var fingering = await _context.Fingerings.Where(x => x.ChordName == id).ToListAsync();
            if (id == "random")
            {
                Random rnd = new Random();
                int rand = 1 + rnd.Next(13);
                fingering = await _context.Fingerings.Where(x => x.FingeringId == rand).ToListAsync();
            }
            if (id == "easy")
            {
                fingering = await _context.Fingerings.Where(x => x.Difficulty == "Easy").ToListAsync();
            }

            if (id == "intermediate")
            {
                fingering = await _context.Fingerings.Where(x => x.Difficulty == "Intermediate").ToListAsync();
            }
            if (id == "hard")
            {
                fingering = await _context.Fingerings.Where(x => x.Difficulty == "Hard").ToListAsync();
            }

            var response = new Response();
            response.statusCode = 400;
            response.statusDescription = "BadRequest: " + id + " not found. Make sure to use an available chord name (example: 'Am') or " +
                "one of the following: 'random', 'easy', 'intermediate', 'hard'";
            if (fingering != null && fingering.Count != 0)
            {
                response.statusCode = 200;
                response.statusDescription = "OK: " + id + " was found.";
                response.fingerings = fingering;
            }

            return response;
        }

        private bool FingeringExists(int id)
        {
            return (_context.Fingerings?.Any(e => e.FingeringId == id)).GetValueOrDefault();
        }
    }
}
