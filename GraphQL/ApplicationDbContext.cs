using Microsoft.EntityFrameworkCore;

namespace demo.GraphQL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Users> Users { get; set; }
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionBuilder.UseSqlServer("Data Source=legion-5-pro;Initial Catalog=demo;Integrated Security=True;Pooling=False");
            return new ApplicationDbContext(optionBuilder.Options);
        }
    }
}
