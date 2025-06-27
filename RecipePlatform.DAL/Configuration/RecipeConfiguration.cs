using Microsoft.EntityFrameworkCore;
using RecipePlatform.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipePlatform.DAL.Configuration
{
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {


        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Recipe> builder)
        {
            builder.HasKey(r => r.RecipesId);
          
            builder.Property(r => r.Description).HasMaxLength(1000);
            builder.Property(r => r.Instructions).IsRequired();
           
            builder.Property(r => r.CreatedDate).HasDefaultValueSql("GETDATE()");
            builder.Property(r => r.IsActive).HasDefaultValue(true);
            // Configure the many-to-one relationship with User
            builder.HasOne(r => r.User)
                   .WithMany(u => u.Recipes)
                   .HasForeignKey(r => r.UserId);
            // Configure the many-to-one relationship with Category
            builder.HasOne(r => r.Category)
                   .WithMany(c => c.Recipes)
                   .HasForeignKey(r => r.CategoriesId);
        }
    }
}
