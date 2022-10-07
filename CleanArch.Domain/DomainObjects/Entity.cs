namespace CleanArch.Domain.DomainObjects
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public virtual void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
