using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoF.Core.Contracts;
using DemoF.Core.Domain;
using DemoF.Core.Repositories;

namespace DemoF.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfDemof _unitOfWork;

        public UserService(IUnitOfDemof unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(User user)
        {
            await _unitOfWork.Users.AddAsyn(user);
        }

        public async Task<List<User>> AllAsync()
        {
            return (await _unitOfWork.Users.GetAllAsync()).ToList();
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _unitOfWork.Users.GetAsync(id);
        }

        public async Task RemoveAsync(int id)
        {
            await _unitOfWork.Users.DeleteAsyn(new User(){ Id = id});
        }

        public async Task<User> UpdateAsync(int id, User user)
        {
            return await _unitOfWork.Users.UpdateAsyn(user, id);
        }
    }
}
