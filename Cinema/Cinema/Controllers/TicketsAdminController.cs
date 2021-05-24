using Cinema.Models.Tickets;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace Cinema.Controllers
{
    public class TicketsAdminController : Controller
    {
        private string PathToJson = "/Files/Tickets.json";
        public ActionResult SaveTickets()
        {
            var movies = new Movie[3];
            var tariffs = new Tariff[3];
            var halls = new Hall[3];
            var timeslots = new Timeslot[3];

            var jsonModel = new TicketsJsonModel
            {
                Halls = halls,
                Movies = movies,
                Tariffs = tariffs,
                Timeslots = timeslots
            };

            var json = JsonConvert.SerializeObject(jsonModel);
            var jsonFilePath = HttpContext.Server.MapPath(PathToJson);
            System.IO.File.WriteAllText(jsonFilePath,json);

            return Content(json, "application/json");
            
        }

        public ActionResult GetAllTickets()
        {
            var jsonFilePath = HttpContext.Server.MapPath(PathToJson);
            if (System.IO.File.Exists(jsonFilePath))
            {
                var jsonModel = System.IO.File.ReadAllText(jsonFilePath);
                var deserializedModel = JsonConvert.DeserializeObject<TicketsJsonModel>(jsonModel);
                return Content(jsonModel, "application/json");
            }
            return Content("File don't exist", "application/json");
        }
    }
}
