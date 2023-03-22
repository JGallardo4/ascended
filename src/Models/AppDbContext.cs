using AscendedGuild.Models.Recruitement;
using AscendedGuild.Models.About;
using AscendedGuild.Models.Streams;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AscendedGuild.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<PlayerClass> PlayerClasses { get; set; }
        public DbSet<Spec> Specs { get; set; }
        public DbSet<TwitchStreamer> TwitchStreamers { get; set; }
        public DbSet<TextBlock> TextBlocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
