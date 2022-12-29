
using CleanArch.Domain.DomainObjects;

namespace CleanArch.Domain.Entities
{
    public class BankAccount : Entity
    {
        public string AccountData { get; private set; }
    }
}
