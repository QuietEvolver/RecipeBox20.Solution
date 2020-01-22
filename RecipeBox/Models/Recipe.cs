using System.Collections.Generic;

namespace RecipeBox.Models
{
  public class Recipe
    {
        public Recipe()
        {
            this.Ingredients = new HashSet<RecipeIngredient>();
            this.Tags = new HashSet<TagRecipe>();
        }

        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string RecipeInstructions { get; set; }
       // public string TagRecipes { get; set; }
        public virtual ICollection<RecipeIngredient> Ingredients { get; set; }
        public virtual ICollection<TagRecipe> Tags { get; set; }
    }
}