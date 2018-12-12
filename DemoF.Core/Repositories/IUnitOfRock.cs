using System;
using Microsoft.EntityFrameworkCore;

namespace DemoF.Core.Repositories
{
    public interface IUnitOfDemof : IUnitOfWork, IDisposable
    {
        IUserRepositoryDapper Users { get; }
        //IUserRepository Users { get; }
        int Complete();
    }
}
