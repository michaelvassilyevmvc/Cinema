using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Cinema.Models.Tickets;
using Newtonsoft.Json;


namespace Cinema.Controllers
{
    public class TicketsAdminController:Controller
    {
        private string PathToJson = "/Files/Tickets.json";

        public ActionResult SaveTickets()
        {
            var movies = new Movie[3];
            var halls = new Hall[3];
            var tariffs = new Tariff[3];
            var timeslots = new Timeslot[3];

            var jsonModel = new TicketsJsonModel
            {
                Movies = movies,
                Halls = halls,
                Tariffs = tariffs,
                Timeslots = timeslots
            };

            var json = JsonConvert.SerializeObject(jsonModel);
            var jsonFilePath = HttpContext.Server.MapPath(PathToJson);
            System.IO.File.WriteAllText(jsonFilePath, json);

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
            return Content("File don't exists", "application/json");
        }
    }
}
