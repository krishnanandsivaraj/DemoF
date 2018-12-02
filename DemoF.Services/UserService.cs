using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DemoF.Core.Contracts;
using DemoF.Core.Domain;
using DemoF.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace DemoF.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfDemof _context;

        public UserService(IUnitOfDemof context)
        {
            _context = context;
        }

        public List<User> All()
        {
            return _context.Users.GetAll().ToList();
        }

        public async Task<IPagedList<User>> GetPagedListAsync(Expression<Func<User, bool>> predicate = null, Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null, Func<IQueryable<User>, IIncludableQueryable<User, object>> include = null, int pageIndex = 0, int pageSize = 20, bool disableTracking = true)
        {
            return await _context.Users.GetPagedListAsync(predicate, orderBy, include, pageIndex, pageSize, disableTracking);
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _context.Users.FindBy(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<User> GetUserAsync(string name)
        {
            return await _context.Users.FindBy(x => x.FirstName == name || x.MiddleName == name || x.LastName == name).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
