using Microsoft.AspNetCore.Mvc;
using RecipeBox.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RecipeBox.Controllers
{
  public class IngredientsController : Controller
  {
    private readonly RecipeBoxContext _db;

    public IngredientsController(RecipeBoxContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Ingredients.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Ingredient ingredient)
    {
      _db.Ingredients.Add(ingredient);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

//     public ActionResult Details(int id)
//     {
//       var thisIngredient = _db.Ingredients
//           .Include(ingredient => ingredient.Recipes)
//           .ThenInclude(join => join.Recipe)
//           .FirstOrDefault(ingredient => ingredient.IngredientId == id);
//       return View(thisIngredient);
//     }

//     public ActionResult Edit(int id)
//     {
//       var thisIngredient = _db.Ingredients.FirstOrDefault(ingredients => ingredients.IngredientId == id);
//       ViewBag.RecipeId = new SelectList(_db.Recipes, "RecipeId", "Name");
//       return View(thisIngredient);
//     }

//     [HttpPost]
//     public ActionResult Edit(Ingredient ingredient, int RecipeId)
//     {
//       if (RecipeId != 0)
//       {
//         _db.RecipeIngredient.Add(new RecipeIngredient() { RecipeId = RecipeId, IngredientId = ingredient.IngredientId });
//       }
//       _db.Entry(ingredient).State = EntityState.Modified;
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }

//     public ActionResult AddRecipe(int id)
//     {
//       var thisIngredient = _db.Ingredients.FirstOrDefault(ingredients => ingredients.IngredientId == id);
//       ViewBag.RecipeId = new SelectList(_db.Recipes, "RecipeId", "Name");
//       return View(thisIngredient);
//     }

//     [HttpPost]
//     public ActionResult AddRecipe(Ingredient ingredient, int RecipeId)
//     {
//       if (RecipeId != 0)
//       {
//         _db.RecipeIngredient.Add(new RecipeIngredient() { RecipeId = RecipeId, IngredientId = ingredient.IngredientId });
//       }
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }

//     public ActionResult Delete(int id)
//     {
//       var thisIngredient = _db.Ingredients.FirstOrDefault(ingredients => ingredients.IngredientId == id);
//       return View(thisIngredient);
//     }

//     [HttpPost, ActionName("Delete")]
//     public ActionResult DeleteConfirmed(int id)
//     {
//       var thisIngredient = _db.Ingredients.FirstOrDefault(ingredients => ingredients.IngredientId == id);
//       _db.Ingredients.Remove(thisIngredient);
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }

//     [HttpPost]
//     public ActionResult DeleteRecipe(int joinId)
//     {
//       var joinEntry = _db.RecipeIngredient.FirstOrDefault(entry => entry.RecipeIngredientId == joinId);
//       _db.RecipeIngredient.Remove(joinEntry);
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }
  }
}