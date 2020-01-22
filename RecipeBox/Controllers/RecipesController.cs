using Microsoft.AspNetCore.Mvc;
using RecipeBox.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RecipeBox.Controllers
{
  public class RecipesController : Controller
  {
    private readonly RecipeBoxContext _db;

    public RecipesController(RecipeBoxContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Recipe> model = _db.Recipes.ToList();
      return View(model);
    }
// Then add tags
    public ActionResult Create()
    {
      ViewBag.TagId = new MultiSelectList(_db.Tags, "TagId", "TagDescription");
      ViewBag.IngredientId = new MultiSelectList(_db.Ingredients, "IngredientId", "IngredientDescription");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Recipe recipe, List<int> IngredientId, List<int> TagId)
    {
      _db.Recipes.Add(recipe);
      if (IngredientId.Count != 0)
      {
        foreach (int Ingredient in IngredientId)
        {
          _db.RecipeIngredient.Add(new RecipeIngredient() { IngredientId = Ingredient, RecipeId = recipe.RecipeId });
        }   
      }
      if (TagId.Count != 0)
      {
        foreach (int Tag in TagId)
        {
          _db.TagRecipe.Add(new TagRecipe() { TagId = Tag, RecipeId = recipe.RecipeId });
        }   
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisRecipe = _db.Recipes
          .Include(recipe => recipe.Ingredients)
          .ThenInclude(join => join.Ingredient)
          .Include(recipe => recipe.Tags)
          .ThenInclude(join => join.Tag)
          .FirstOrDefault(recipe => recipe.RecipeId == id);
      return View(thisRecipe);
    }

    // public ActionResult Edit(int id)
    // {
    //   var thisRecipe = _db.Recipes.FirstOrDefault(recipe => recipe.RecipeId == id);
    //   return View(thisRecipe);
    // }

    // [HttpPost]
    // public ActionResult Edit(Recipe recipe)
    // {
    //   _db.Entry(recipe).State = EntityState.Modified;
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }

    // public ActionResult Delete(int id)
    // {
    //   var thisRecipe = _db.Recipes.FirstOrDefault(recipe => recipe.RecipeId == id);
    //   return View(thisRecipe);
    // }

    // [HttpPost, ActionName("Delete")]
    // public ActionResult DeleteConfirmed(int id)
    // {
    //   var thisRecipe = _db.Recipes.FirstOrDefault(recipe => recipe.RecipeId == id);
    //   _db.Recipes.Remove(thisRecipe);
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }
  }
}