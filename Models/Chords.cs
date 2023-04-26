using System;
using System.ComponentModel.DataAnnotations;

namespace ChordsAPI.Models
{
    public class Chords
    {
        [Key]
        public int ChordId { get; set; }
        public string? ChordName { get; set; }
        public string? Notes { get; set; }
        public string? ChordRoot { get; set; }
        public string? ChordType { get; set; }
        public string? ChordBass { get; set; }
        public int FingeringId { get; set; }
        public Fingerings? Fingering { get; set; }
    }
}
