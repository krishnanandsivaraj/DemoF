using System.Collections.Generic;
using System.Threading.Tasks;
using DemoF.Core.Domain;

namespace DemoF.Core.Repositories
{
    /// <summary>
    /// // Specific methods for domain model
    /// </summary>
    public interface IUserRepositoryDapper : IGenericRepositoryDapper<User>
    {
        
    }
}
