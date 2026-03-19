using Entities.Base;

namespace Entities.Security;

public class Stock : SecurityBase
{

    public Stock()
    {
        
    }

    public Stock(string symbol, string name) : base(symbol, name)
    {
    }
}
