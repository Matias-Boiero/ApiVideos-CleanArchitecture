using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure
{
    public class StreamerDbContext : DbContext
    {
        public StreamerDbContext()
        {

        }
        public DbSet<Streamer>? Streamers { get; set; }
        public DbSet<Video>? Videos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MATIAS;Database=Streamer;" +
                "Trusted_Connection=True;TrustServerCertificate=True").LogTo(Console.WriteLine, new[]
                {
                    DbLoggerCategory.Database.Command.Name
                },
                Microsoft.Extensions.Logging.LogLevel.Information).EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Streamer tendrá muchas instancias de Video (1 a muchos)
            modelBuilder.Entity<Streamer>().HasMany(m => m.Videos)
                .WithOne(m => m.Streamer)
                .HasForeignKey(m => m.StreamerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            //Relacion muchos a muchos Actor-Videos
            modelBuilder.Entity<Video>().HasMany(a => a.Actores)
                 .WithMany(v => v.Videos)
                 .UsingEntity<VideoActor>(va => va.HasKey(e =>
                 new { e.ActorId, e.VideoId }));
        }

    }
}
