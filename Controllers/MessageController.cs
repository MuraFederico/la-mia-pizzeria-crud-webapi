using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        [Authorize]
        public ActionResult Index()
        {
            PizzaContext context = new PizzaContext();
            IEnumerable<Message> messages = context.Messages;
            return View(messages);
        }

        // GET: Message/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Message/Create
        public ActionResult Create()
        {
            return View();
        }


        // GET: Message/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Message/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Message/Delete/5
        public IActionResult Delete(int id)
        {
            using (PizzaContext context = new PizzaContext()) {
                Message toDelete = context.Messages.Where(m => m.Id == id).FirstOrDefault();
                context.Remove(toDelete);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        
    }
}
