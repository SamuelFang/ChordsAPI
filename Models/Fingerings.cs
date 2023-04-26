using System;
using System.ComponentModel.DataAnnotations;
namespace ChordsAPI.Models
{
    public class Fingerings
    {
        [Key]
        public int FingeringId { get; set; }
        public string? ChordName { get; set; }
        public string? StringPositions { get; set; }
        public string? Fingering { get; set; }
        public string? Difficulty { get; set; }
    }
}
