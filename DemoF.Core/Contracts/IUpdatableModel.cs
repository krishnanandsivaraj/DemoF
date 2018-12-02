using System;
using System.Collections.Generic;
using System.Text;

namespace DemoF.Core.Contracts
{
    public interface IUpdatableModel
    {
        IDictionary<string, object> GetUpdatableProperties();
    }
}
