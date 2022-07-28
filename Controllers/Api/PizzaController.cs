using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Controllers.Api
{
    [Route("api/Pizza")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string? search)
        {
            PizzaContext context = new PizzaContext();
            IQueryable<Pizza> pizzaList = context.Pizzas;

            if(search != null && search != "")
            {
                pizzaList = pizzaList.Where(p => p.Name.Contains(search));
            }

            return Ok(pizzaList.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            /*int id = int.Parse((string)RouteData.Values["id"]);*/

            PizzaContext context = new PizzaContext();
            Pizza pizza = context.Pizzas.Where(p => p.Id == id).Include("Ingredients").Include("Category").FirstOrDefault();

            return Ok(pizza);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            /*int id = int.Parse((string)RouteData.Values["id"]);*/

            PizzaContext context = new PizzaContext();
            Pizza toDelete = context.Pizzas.Where(p => p.Id == id).Include("Ingredients").Include("Category").FirstOrDefault();
            if(toDelete != null)
            {
                context.Remove(toDelete);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
