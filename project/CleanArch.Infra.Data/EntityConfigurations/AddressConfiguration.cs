using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.Data.EntityConfigurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(p => p.Id).HasMaxLength(36).IsRequired().IsUnicode();
            builder.Property(p => p.Number).HasMaxLength(20).IsRequired();
            builder.Property(p => p.Street).HasMaxLength(200).IsRequired();
        }
    }
}
