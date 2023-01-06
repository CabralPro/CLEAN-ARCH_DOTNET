
using CleanArch.Domain.DomainObjects;

namespace CleanArch.Domain.Entities
{
    public class BankAccount : EntityBase
    {
        public string AccountData { get; private set; }

        public Guid ClientId { get; private set; }
        protected virtual Client? Client { get; private set; }

        protected BankAccount()
        { }

        public BankAccount(string accountData)
        {
            AccountData = accountData;
        }

    }

}
