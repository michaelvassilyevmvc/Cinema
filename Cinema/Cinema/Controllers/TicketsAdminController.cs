using Cinema.Models.Tickets;
using Cinema.Services;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace Cinema.Controllers
{
    public class TicketsAdminController : Controller
    {
        private readonly ITicketService _ticketService;
        public TicketsAdminController()
        {
            this._ticketService = new JsonTicketService(System.Web.HttpContext.Current);
        }

        public ActionResult FindMovieById(int id)
        {
            var movie = _ticketService.GetMovieById(id);
            if (movie == null)
                return Content("Movie with such id doesn't exist");

            var modelJson = JsonConvert.SerializeObject(movie);
            return Content(modelJson, "application/json");
        }
    }
}
