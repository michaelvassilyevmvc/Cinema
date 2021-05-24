using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Models.Tickets
{
    public class TicketsJsonModel
    {
        public Movie[] Movies { get; set; }
        public Tariff[] Tariffs { get; set; }
        public Hall[] Halls { get; set; }
        public Timeslot[] Timeslots { get; set; }
    }
}
