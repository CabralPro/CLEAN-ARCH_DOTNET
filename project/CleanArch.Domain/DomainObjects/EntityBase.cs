
namespace CleanArch.Domain.DomainObjects
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public abstract void Validate();
    }
}
