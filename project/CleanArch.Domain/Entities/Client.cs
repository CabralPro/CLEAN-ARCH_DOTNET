
using CleanArch.Domain.DomainObjects;
using FluentValidation;

namespace CleanArch.Domain.Entities
{
    public class Client : EntityBase
    {
        public string Name { get; private set; }
        public virtual Address Address { get; private set; }
        public virtual IList<BankAccount> BankAccounts { get; private set; }

        protected Client()
        { }

        public Client(string name, Address address, IList<BankAccount> bankAccounts)
        {
            Name = name;
            Address = address;
            BankAccounts = bankAccounts;
            Validate();
        }

        public override void Validate()
        {
            new ClientValidator().ValidateAndThrow(this);
        }
    }

    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }

}
