namespace CleanArch.Domain.DomainObjects
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public virtual void Validate()
        {
            Validation.IsValidGuid(Id, "Id inválido");
            Validation.IsValidDate(CreatedDate, "Data de criação inválida");
            Validation.IsValidDate(UpdatedDate, "Data de atualização inválida");
        }
    }
}
