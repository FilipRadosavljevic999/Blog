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
    public class PostConfiguration : EntityConfiguration<Post>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Post> builder)
        {
            ;


            builder.HasOne(x => x.Author)
                   .WithMany(x => x.Posts)
                   .HasForeignKey(x => x.AuthorId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
