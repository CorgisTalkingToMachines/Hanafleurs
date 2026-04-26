using API.Domain.Entities;
using API.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Infrastructure.Persistence.EFCore.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        void IEntityTypeConfiguration<User>.Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasIndex(u => u.Username)
                .IsUnique();

            builder
                .HasIndex(u => u.Email)
                .IsUnique();

            builder
                .Property(u => u.Role)
                .HasConversion(
                    role => role.Value,
                    value => Role.FromString(value));
        }
    }
}
