using System;
using Microsoft.EntityFrameworkCore;

namespace DemoF.Core.Repositories
{
    public interface IUnitOfDemof : IUnitOfWork, IDisposable
    {
        IUserRepository Users { get; }
        int Complete();
    }
}
