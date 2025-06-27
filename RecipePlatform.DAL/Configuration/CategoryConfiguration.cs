using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipePlatform.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipePlatform.DAL.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.CategoriesId);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Description).HasMaxLength(500);
            builder.Property(c => c.CretedDate).HasDefaultValueSql("GETDATE()");
            builder.Property(c => c.IsActive).HasDefaultValue(true);
            // Configure the one-to-many relationship with Recipe
            builder.HasMany(c => c.Recipes)
                   .WithOne(r => r.Category)
                   .HasForeignKey(r => r.CategoriesId);
        }

        
    }
}
