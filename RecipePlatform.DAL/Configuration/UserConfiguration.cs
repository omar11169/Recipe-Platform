using Microsoft.EntityFrameworkCore;
using RecipePlatform.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipePlatform.DAL.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>

    {


        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UserId);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(256);
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(100);
            builder.Property(u => u.PasswordHash).IsRequired();
            builder.Property(u => u.SecurityStamp).IsRequired();
            builder.Property(u => u.PhoneNumber).HasMaxLength(15);
            builder.Property(u => u.UserName).IsRequired().HasMaxLength(256);
            builder.Property(u => u.CretedDate).HasDefaultValueSql("GETDATE()");
            builder.Property(u => u.IsActive).HasDefaultValue(true);
            // Configure relationships
            builder.HasMany(u => u.Recipes)
                   .WithOne(r => r.User)
                   .HasForeignKey(r => r.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(u => u.Ratings)
                     .WithOne(r => r.User)
                     .HasForeignKey(r => r.UserId)
                     .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
