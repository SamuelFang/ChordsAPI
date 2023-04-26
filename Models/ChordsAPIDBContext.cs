using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using ChordsAPI.Models;

namespace ChordsAPI.Models

{
    public class ChordsAPIDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public ChordsAPIDBContext(DbContextOptions<ChordsAPIDBContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("MusicChords");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Chords> Chords { get; set; } = null!;
        public DbSet<Fingerings> Fingerings { get; set; } = null!;
    }
}
