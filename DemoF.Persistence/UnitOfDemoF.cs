using DemoF.Core.Repositories;
using DemoF.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace DemoF.Persistence
{
    public class UnitOfDemof : UnitOfWork<DemofContext>, IUnitOfDemof
    {
        private readonly DemofContext context;

        public IUserRepositoryDapper Users { get; private set; }
        //public IUserRepository Users { get; private set; }

        public UnitOfDemof(DemofContext context, IServiceProvider serviceProvider) : base (context)
        {
            this.context = context;
            Users = (IUserRepositoryDapper)serviceProvider.GetService(typeof(IUserRepositoryDapper));
            //Users = new UserRepository(this.context);
        }

        public int Complete()
        {
            return context.SaveChanges();
        }
    }
}
