using Cinema.Models.Tickets;


namespace Cinema.Controllers
{
    public class TicketsJsonModel
    {
        public Movie[] Movies { get; set; }
        public Hall[] Halls { get; set; }
        public Timeslot[] Timeslots { get; set; }
        public Tariff[] Tariffs { get; set; }
    }
}
