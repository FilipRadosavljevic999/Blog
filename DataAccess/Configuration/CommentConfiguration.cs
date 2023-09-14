using Domain.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
    public class CommentConfiguration : EntityConfiguration<Comment>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(x => x.Text)
                .IsRequired();


            builder.HasOne(x => x.Author)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            builder.HasOne(x => x.Post)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.PostId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

        }
    }
}
