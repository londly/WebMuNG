using Microsoft.EntityFrameworkCore;

namespace WebMuNG.Models
{
    public class MuOnline : DbContext
    {

        public MuOnline(DbContextOptions<MuOnline> options) 
            : base(options)
        {
        }

        public virtual DbSet<Character> Characters { get; set; }
    }
}