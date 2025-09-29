using LMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LMS.Data
{
    public class AppdbContext : DbContext
    {
        public AppdbContext(DbContextOptions<AppdbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }  
        public DbSet<Member> Members { get; set; }
        public DbSet<Borrower> Borrowers { get; set; }

    }
}
