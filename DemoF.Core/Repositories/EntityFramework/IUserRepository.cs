using System.Collections.Generic;
using System.Threading.Tasks;
using DemoF.Core.Domain;

namespace DemoF.Core.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        IEnumerable<User> GetAll();

        Task<User> GetUserAsync(int id);
    }
}
