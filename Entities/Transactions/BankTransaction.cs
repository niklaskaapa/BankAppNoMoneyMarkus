using Entities.Base;

namespace Entities.Transactions;

public class BankTransaction
{

    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime TransactionalDate { get; set; }

    public Guid AccountBaseId { get; set; }
    public AccountBase? AccountBase { get; set; }
}
