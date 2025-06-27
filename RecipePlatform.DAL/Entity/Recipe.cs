using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipePlatform.Model.Entity
{
    public class Recipe
    {
        [Key]
        public int RecipesId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Ingredients { get; set; }

        public string Instructions { get; set; }

        public int PrepTime { get; set; }

        public int CockTime { get; set; }

        public int Serving { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Category")]
        public int CategoriesId { get; set; }
        public Category Category { get; set; }


        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    }

}
