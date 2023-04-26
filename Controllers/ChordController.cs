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
    public class ChordController : ControllerBase
    {
        private readonly ChordsAPIDBContext _context;

        public ChordController(ChordsAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/chord
        [HttpGet]
        public async Task<ActionResult<Response>> GetChords()
        {
            var chords = await _context.Chords.ToListAsync();
            var response = new Response();
            response.statusCode = 400;
            response.statusDescription = "BadRequest: no chords found.";
            if (chords != null && chords.Count != 0)
            {
                response.statusCode= 200;
                response.statusDescription = "OK: chords found.";
                response.chords = chords;
            }

            return response;
        }

        // GET: api/chord/A
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetChord(string id)
        {
            var chord = await _context.Chords.Where(x => x.ChordName == id).ToListAsync();
            if (id == "random")
            {
                Random rnd = new Random();
                int rand = 1 + rnd.Next(13);
                chord = await _context.Chords.Where(x => x.ChordId == rand).ToListAsync();
            }
            if (id == "major")
            {
                chord = await _context.Chords.Where(x => x.ChordType == "Major").ToListAsync();
            }

            if (id == "minor")
            {
                chord = await _context.Chords.Where(x => x.ChordType == "Minor").ToListAsync();
            }
            var response = new Response();
            response.statusCode = 400;
            response.statusDescription = "BadRequest: " + id + " not found. Make sure to use an available chord name (example: 'Am') or " +
                "one of the following: 'random', 'major', 'minor'";
            if (chord != null && chord.Count != 0)
            {
                response.statusCode = 200;
                response.statusDescription = "OK: " + id + " was found.";
                response.chords = chord;
            }

            return response;
        }

        // POST: api/chord
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Response>> PostChord(Chords chord)
        {
            var response = new Response();
            response.statusCode = 400;
            response.statusDescription = "BadRequest: invalid chord.";
            if (_context.Chords == null)
            {
                response.statusDescription = "BadRequest: chord is null.";
                return response;
            }
            if (chord.Fingering == null)
            {
                response.statusDescription = "BadRequest: fingering cannot be null.";
                return response;
            }
            if (chord.ChordName == null || chord.Fingering.ChordName == null)
            {
                response.statusDescription = "BadRequest: chord name cannot be null.";
                return response;
            }
            if (chord.ChordName != chord.Fingering.ChordName)
            {
                response.statusDescription = "BadRequest: chord names do not match.";
                return response;
            }
            var lookup = await _context.Chords.Where(x => x.ChordName == chord.ChordName).ToListAsync();
            if (lookup != null && lookup.Count != 0)
            {
                response.statusDescription = "BadRequest: chord name already exists. Please use another chord name.";
                return response;
            }
            if (chord.ChordName.Length == 0)
            {
                response.statusDescription = "BadRequest: chord name cannot be blank.";
                return response;
            }
            _context.Chords.Add(chord);
            await _context.SaveChangesAsync();
            response.statusCode = 200;
            response.statusDescription = "OK: chord and its corresponding fingering was successfully added";

            return response;
        }

        // DELETE: api/chord/A
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> DeleteChord(string id)
        {
            var response = new Response();
            response.statusCode = 400;
            response.statusDescription = "BadRequest: invalid chord.";
            if (_context.Chords == null)
            {
                response.statusDescription = "BadRequest: chord is null.";
                return response;
            }
            var chord = await _context.Chords.Where(x => x.ChordName == id).ToListAsync();
            if (chord == null || chord.Count == 0)
            {
                response.statusDescription = "BadRequest: " + id + " chord not found.";
                return response;
            }
            var fingering = await _context.Fingerings.Where(x => x.FingeringId == chord[0].FingeringId).ToListAsync();
            _context.Fingerings.Remove(fingering[0]);
            _context.Chords.Remove(chord[0]);
            await _context.SaveChangesAsync();
            response.statusCode = 200;
            response.statusDescription = "OK: " + id + " chord and its corresponding fingering was successfully removed";

            return response;
        }

        private bool ChordExists(int id)
        {
            return (_context.Chords?.Any(e => e.ChordId == id)).GetValueOrDefault();
        }
    }
}
