using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Value
    {
        public List<Venue> Venues { get; set; } = new List<Venue>();

        public Venue Venue { get; set; }

        public List<TicketEvent> Events  = new List<TicketEvent>();

        public List<Tickets> BookTicket = new List<Tickets>();

        public Tickets Tickets { get; set; }


    }
}
