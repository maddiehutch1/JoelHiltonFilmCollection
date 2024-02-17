using Microsoft.EntityFrameworkCore;

namespace Mission06_MadHutchings.Models
{
    public class MovieEntryContext : DbContext
    {
        public MovieEntryContext(DbContextOptions<MovieEntryContext> options) : base(options)
        {

        }

        public DbSet<MovieEntry> Movies { get; set; } // hey! this is the table in Sqlite! connects our form to dataset
    }
}
