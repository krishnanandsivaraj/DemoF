using DemoF.Core.Domain;
using DemoF.Core.Repositories;
using DemoF.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DemoF.Persistence
{
    public class UnitOfDemof : UnitOfWork<DemofContext>, IUnitOfDemof
    {
        private readonly DemofContext context;

        public IUserRepository Users { get; private set; }

        public UnitOfDemof(DemofContext context) : base (context)
        {
            this.context = context;

            Users = new UserRepository(this.context);
        }

        public int Complete()
        {
            return context.SaveChanges();
        }
    }
}
