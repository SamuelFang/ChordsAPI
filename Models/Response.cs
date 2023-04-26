using System;
namespace ChordsAPI.Models
{
    public class Response
    {
        public int statusCode { get; set; }
        public string? statusDescription { get; set; }
        public List<Chords> chords { get; set; } = new();
        public List<Fingerings> fingerings { get; set; } = new();
    }
}
