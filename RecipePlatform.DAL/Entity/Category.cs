using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipePlatform.Model.Entity
{
    public class Category
    {
        [Key]   
        public int CategoriesId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CretedDate { get; set; }
        public bool IsActive { get; set; }




        public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
    }

}
