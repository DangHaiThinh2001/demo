using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace demo.GraphQL
{
    public class Resolver
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public Resolver (IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<Users> create(Users user)
        {
            using (ApplicationDbContext context = _dbContextFactory.CreateDbContext())
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();  

                return user;
            }
        }

        public async Task<Users> update(Users user)
        {
            using (ApplicationDbContext context = _dbContextFactory.CreateDbContext())
            {
                context.Users.Update(user);
                await context.SaveChangesAsync();

                return user;
            }
        }

        public async Task<IEnumerable<Users>> getUsers()
        {
            using (ApplicationDbContext context = _dbContextFactory.CreateDbContext())
            {
                return await context.Users.ToListAsync();
            }
        }

        public async Task<Users> getUserById(Guid id)
        {
            using (ApplicationDbContext context = _dbContextFactory.CreateDbContext())
            {
                Users user = await context.Users.FindAsync(id);
                return user;
            }
        }

        public async Task<Users> delete(Guid id)
        {
            using (ApplicationDbContext context = _dbContextFactory.CreateDbContext())
            {
                Users user = await context.Users.FindAsync(id);
                context.Users.Remove(user);
                await context.SaveChangesAsync();

                return user;
            }
        }
    }
}
