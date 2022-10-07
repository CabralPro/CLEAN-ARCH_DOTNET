
using CleanArch.Domain.DomainObjects;

namespace CleanArch.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }

        protected Product()
        { }

        public Product(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;

            Validate();
        }

        public override void Validate()
        {
            Validations.IsNullOrEmpty(Name, "Name invalid");
        }

    }
}
