using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        // jeśli zwracamy tylko jeden typ rezultatu,
        // to warto użyć konkretnej klasy zamiast IAction Result,
        // pomoże to w testowaniu unit test

        // stosowanie kontrolera bazowego Controller oraz interfejsu IActionResult
        // daje nam elastyczność oddzielenia decyzji o akcji i samej akcji

        public IActionResult Index()
        {
            // ewentualnie ContentResult
            //return Content("Hello from the HomeController!");

            var model = new Restaurant { Id = 1, Name = "The House of gulci" };

            // domyślne ustawienie mvc, obiekt będzie serializowany do json
            // ObjectResult daje nam content negotiation, możemy wybrać w jaki sposób zwrócimy dane
            return new ObjectResult(model);
        }
    }
}
