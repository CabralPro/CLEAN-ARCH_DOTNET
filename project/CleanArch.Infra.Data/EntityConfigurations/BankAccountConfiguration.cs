using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.Data.EntityConfigurations
{
    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.Property(p => p.Id).HasMaxLength(36).IsRequired().IsUnicode();
            builder.Property(p => p.AccountData).HasMaxLength(100).IsRequired();
        }
    }
}
