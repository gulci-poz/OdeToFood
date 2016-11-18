using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        // jeśli zwracamy tylko jeden typ rezultatu,
        // to warto użyć konkretnej klasy zamiast IActionResult,
        // pomoże to w testowaniu unit test

        // stosowanie kontrolera bazowego Controller oraz interfejsu IActionResult
        // daje nam elastyczność oddzielenia decyzji o akcji i samej akcji

        public IActionResult Index()
        {
            // Content to helper method klasy Controller, zwraca ContentResult
            //return Content("Hello from the HomeController!");

            var model = new Restaurant { Id = 1, Name = "The House of gulci" };

            // domyślne ustawienie mvc to serializacja obiektu do json
            // ObjectResult daje nam content negotiation, możemy wybrać w jaki sposób zwrócimy dane
            // ObjectResult implementuje IActionResult, nie mamy metody pomocniczej
            //return new ObjectResult(model);

            // metoda View zwraca ViewResult
            // możemy zdefiniować nazwę widoku View("Home"), domyślnie jest Index - tak jak nazwa metody
            // w folderze Views/Shared są widoki dostępne dla wszystkich kontrolerów
            return View(model);
        }
    }
}
