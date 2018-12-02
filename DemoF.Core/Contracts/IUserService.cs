using DemoF.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DemoF.Core.Contracts
{
    public interface IUserService
    {
        List<User> All();
        Task<IPagedList<User>> GetPagedListAsync(Expression<Func<User, bool>> predicate = null, Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null, Func<IQueryable<User>, IIncludableQueryable<User, object>> include = null, int pageIndex = 0, int pageSize = 20, bool disableTracking = true);
        Task<User> GetUserAsync(int id);
        Task<User> GetUserAsync(string name);
    }
}
