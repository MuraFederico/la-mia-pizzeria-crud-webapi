using la_mia_pizzeria_static.DB;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Controllers.Api
{
    [Route("api/PizzaController")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        [Route("PizzaList")]
        public IActionResult PizzaList()
        {
            PizzaContext context = new PizzaContext();
            List<Pizza> pizzaList = context.Pizzas.ToList();

            return Ok(pizzaList);
        }

        [Route("PizzaDetail/{id?}")]
        public IActionResult PizzaDetail()
        {
            int id = int.Parse((string)RouteData.Values["id"]);

            PizzaContext context = new PizzaContext();
            Pizza pizza = context.Pizzas.Where(p => p.Id == id).Include("Ingredients").Include("Category").FirstOrDefault();

            return Ok(pizza);
        }
    }
}
