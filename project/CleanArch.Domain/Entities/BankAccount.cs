
using CleanArch.Domain.DomainObjects;
using FluentValidation;

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
            Validate();
        }

        public override void Validate()
        {
            new BankAccountValidator().ValidateAndThrow(this);
        }

    }

    public class BankAccountValidator : AbstractValidator<BankAccount>
    {
        public BankAccountValidator()
        {
            RuleFor(x => x.AccountData).NotEmpty();
        }
    }

}
