using Entities.Base;

namespace Entities.Security;

public class MutualFund : SecurityBase
{

    public MutualFund()
    {
        
    }

    public MutualFund(string symbol, string name) : base(symbol, name)
    {
    }
}
