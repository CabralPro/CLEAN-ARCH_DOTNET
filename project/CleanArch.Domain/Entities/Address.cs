
using CleanArch.Domain.DomainObjects;

namespace CleanArch.Domain.Entities
{
    public class Address : Entity
    {
        public string Street { get; private set; }
        public string Number { get; private set; }
    }
}
