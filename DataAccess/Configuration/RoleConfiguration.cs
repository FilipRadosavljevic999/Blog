using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
    public class RoleConfiguration : EntityConfiguration<Role>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Role> builder)
        {
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.IsDefault).HasDefaultValue(false);

            builder.HasMany(x => x.RoleUseCases)
                  .WithOne(x => x.Role)
                  .HasForeignKey(x => x.RoleId)
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
