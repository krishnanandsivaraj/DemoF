using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoF.Core.Domain;
using DemoF.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DemoF.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DemofContext context) : base(context) {}

        public IEnumerable<User> GetAll()
        {
            return _context.Users.AsNoTracking().ToList();
        }

        public async Task<User> GetUserAsync(int id) => await FindAsync(match: x => x.Id == id);
    }
}
