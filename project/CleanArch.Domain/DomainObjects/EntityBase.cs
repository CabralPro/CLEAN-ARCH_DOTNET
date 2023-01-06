
namespace CleanArch.Domain.DomainObjects
{
    public abstract class EntityBase
    {
        public Guid Id { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime UpdatedDate { get; private set; }

        //public virtual void Validate()
        //{ }

        public void SetCreatedDate(DateTime createdDate) =>
            CreatedDate = createdDate;

        public void SetUpdatedDate(DateTime updatedDate) =>
            UpdatedDate = updatedDate;
    }
}
