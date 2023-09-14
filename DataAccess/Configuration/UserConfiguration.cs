using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
    internal class UserConfiguration : EntityConfiguration<User>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Username)
                .IsRequired().HasMaxLength(25);

            builder.HasIndex(x => x.Username).IsUnique();
            builder.HasOne(x => x.Role).WithMany(x => x.Users)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
