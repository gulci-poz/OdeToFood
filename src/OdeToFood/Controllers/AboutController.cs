using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Controllers
{
    // attribute routes
    //[Route("about")]

    // z użyciem tokenów w []
    // podając token kontrolera i akcji, nie potrzebujemy atrybutu Route przy metodach

    // możemy używać literałów

    [Route("[controller]/[action]")]
    public class AboutController
    {
        // domyślna akcja, w url wystarczy samo about
        //[Route("")]

        //[Route("[action]")]
        public string Phone()
        {
            return "1+555-555-5555";
        }

        //[Route("address")]

        //[Route("[action]")]
        public string Address()
        {
            return "USA";
        }
    }
}
