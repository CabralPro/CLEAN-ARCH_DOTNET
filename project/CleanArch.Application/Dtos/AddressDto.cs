
using CleanArch.Domain.DomainObjects;
using FluentValidation;
using System.Text.Json.Serialization;

namespace CleanArch.Application.Dtos
{
    public class AddressDto : DtoBase
    {
        [JsonPropertyName("street")]
        public string Street { get; set; }

        [JsonPropertyName("number")]
        public string Number { get; set; }

        public AddressDto(string street, string number)
        {
            Street = street;
            Number = number;
            Validate();
        }

        public override void Validate()
        {
            new AddressDtoValidator().ValidateAndThrow(this);
        }

    }

    public class AddressDtoValidator : AbstractValidator<AddressDto>
    {
        public AddressDtoValidator()
        {
            RuleFor(x => x.Street).NotEmpty();
            RuleFor(x => x.Number).NotEmpty();
        }
    }
}
