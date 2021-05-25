using Cinema.Models.Tickets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Cinema.Services
{
    public class JsonTicketService : ITicketService
    {
        public HttpContext Context { get; set; }
        private const string PathToJson = "/Files/Tickets.json";

        public JsonTicketService(HttpContext context)
        {
            Context = context;
        }

        public Hall[] GetAllHalls()
        {
            return this.GetDataFromFile().Halls;
        }

        public Movie[] GetAllMovies()
        {
            return this.GetDataFromFile().Movies;
        }

        public Tariff[] GetAllTariffs()
        {
            return this.GetDataFromFile().Tariffs;
        }

        public Timeslot[] GetAllTimeslots()
        {
            return this.GetDataFromFile().Timeslots;
        }

        public Hall GetHallById(int id)
        {
            return this.GetDataFromFile().Halls.FirstOrDefault(x => x.Id == id);
        }

        public Movie GetMovieById(int id)
        {
            return this.GetDataFromFile().Movies.FirstOrDefault(x => x.Id == id);
        }

        public Tariff GetTariffById(int id)
        {
            return this.GetDataFromFile().Tariffs.FirstOrDefault(x => x.Id == id);
        }

        public Timeslot GetTimeslotById(int id)
        {
            return this.GetDataFromFile().Timeslots.FirstOrDefault(x => x.Id == id);
        }

        private TicketsJsonModel GetDataFromFile()
        {
            var jsonFilePath = Context.Server.MapPath(PathToJson);
            if (!System.IO.File.Exists(jsonFilePath))
                return null;

            var jsonModel = System.IO.File.ReadAllText(jsonFilePath);
            var deserializedModel = JsonConvert.DeserializeObject<TicketsJsonModel>(jsonModel);
            return deserializedModel;

        }
    }
}
