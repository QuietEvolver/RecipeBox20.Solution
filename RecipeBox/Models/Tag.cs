  
using System.Collections.Generic;

namespace RecipeBox.Models
{
    public class Tag
    {
        public Tag()
        {
            this.TagRecipes = new HashSet<TagRecipe>();
        }

        public int TagId { get; set; }
        public string TagDescription { get; set; }

        public ICollection<TagRecipe> TagRecipes { get;}
    }
}