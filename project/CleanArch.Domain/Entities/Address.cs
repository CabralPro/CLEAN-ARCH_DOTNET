
using CleanArch.Domain.DomainObjects;

namespace CleanArch.Domain.Entities
{
    public class Address : EntityBase
    {
        public string Street { get; private set; }
        public string Number { get; private set; }

        public Guid ClientId { get; private set; }
        protected virtual Client? Client { get; private set; }

        protected Address()
        { }

        public Address(string street, string number)
        {
            Street = street;
            Number = number;
        }

    }

}
