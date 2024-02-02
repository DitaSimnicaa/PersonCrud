using Microsoft.EntityFrameworkCore;
using PersonCrud.Model;

namespace PersonCrud.DbConfigFile
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<PersonModel> PersonModel { get; set; }
    }
}
