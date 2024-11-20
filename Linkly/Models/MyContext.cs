using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Linkly.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        { }

        public DbSet<UrlModel> Urls { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        { }
    }
}
