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
            List<Pizza> pizzaList = context.Pizzas.Include("Ingredients").Include("Category").ToList();

            return Ok(pizzaList);
        }
    }
}
