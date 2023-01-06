
using CleanArch.Domain.DomainObjects;
using FluentValidation;
using System.Text.Json.Serialization;

namespace CleanArch.Application.Dtos
{
    public class BankAccountDto : DtoBase
    {
        [JsonPropertyName("accountData")]
        public string AccountData { get; set; }

        public BankAccountDto(string accountData)
        {
            AccountData = accountData;
            Validate();
        }

        public override void Validate()
        {
            new BankAccountDtoValidator().ValidateAndThrow(this);
        }

    }

    public class BankAccountDtoValidator : AbstractValidator<BankAccountDto>
    {
        public BankAccountDtoValidator()
        {
            RuleFor(x => x.AccountData).NotEmpty();
        }
    }
}
