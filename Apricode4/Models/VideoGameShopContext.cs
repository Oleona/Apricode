using Apricode4.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Apricode4.Models
{

    public class VideoGameShopContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=VideoGameShop;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public VideoGameShopContext(DbContextOptions<VideoGameShopContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public VideoGameShopContext()
        {
        }

        public DbSet<VideoGame> VideoGames { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }

}
