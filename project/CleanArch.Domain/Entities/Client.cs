
using CleanArch.Domain.DomainObjects;

namespace CleanArch.Domain.Entities
{
    public class Client : Entity
    {
        public string Name { get; private set; }

        public virtual Guid ResidentialAddressId { get; private set; }
        public virtual Address ResidentialAddress { get; private set; }

        public virtual Guid BusinessAddressId { get; private set; }
        public virtual Address BusinessAddress { get; private set; }

        public virtual IList<BankAccount> BankAccounts { get; private set; }

    }
}
