using System.Collections.Generic;

namespace DemoF.Core.Contracts
{
    public interface IUpdatableModel
    {
        IDictionary<string, object> GetUpdatableProperties();
        string GetUpdateQuery();
    }
}
