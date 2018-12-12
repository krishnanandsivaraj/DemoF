using DemoF.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoF.Core.Contracts
{
    public interface IUserService
    {
        Task<List<User>> AllAsync();
        Task<User> GetUserAsync(int id);
        Task AddAsync(User user);
        Task<User> UpdateAsync(int id, User user);
        Task RemoveAsync(int id);
    }
}
