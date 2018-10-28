using Microsoft.EntityFrameworkCore;

namespace xysim_moviedb.Models
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options) : base(options)
        {

        }
        public DbSet<xysim_moviedb.Models.Movie> Movie { get; set; }
        
    }
}