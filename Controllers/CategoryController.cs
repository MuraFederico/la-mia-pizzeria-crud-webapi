using la_mia_pizzeria_static.DB;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            PizzaContext context = new PizzaContext();
            List<Category> categories = context.Categories.ToList();

            return View(categories);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            using (PizzaContext context = new PizzaContext())
            {
                context.Add(category);
                context.SaveChanges();
            }

            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            using (PizzaContext context = new PizzaContext())
            {
                Category category = context.Categories.Where(i => i.Id == id).FirstOrDefault();
                return View(category);
            }
        }

        // POST: IngredientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category edited)
        {
            if (!ModelState.IsValid)
            {
                return View(edited);
            }

            using (PizzaContext context = new PizzaContext())
            {
                Category toEdit = context.Categories.Where(i => i.Id == id).FirstOrDefault();

                toEdit.Name = edited.Name;
                context.SaveChanges();
            }

            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: IngredientController/Delete/5
        public ActionResult Delete(int Id)
        {
            PizzaContext context = new PizzaContext();
            Category toDelete = context.Categories.Where(p => p.Id == Id).Include("Pizzas").First();

            if (toDelete != null)
            {
/*                context.Pizzas.RemoveRange(toDelete.Pizzas);*/
                context.Categories.Remove(toDelete);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }
    }
}

