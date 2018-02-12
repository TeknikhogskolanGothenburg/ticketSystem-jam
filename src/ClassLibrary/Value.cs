using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Value
    {
        public List<Venue> Venues { get; set; } = new List<Venue>();

        public Venue Venue { get; set; }

        public TicketEvent TicketEvent { get; set; }

        public List<TicketEvent> Events  = new List<TicketEvent>();

        public List<Tickets> BookTicket = new List<Tickets>();

        public Tickets Tickets { get; set; }

        public List<TicketEventDate> TicketEventDate { get; set; } = new List<TicketEventDate>(); //behöver lite att testa med

        public TicketEventDate TicketEventDates { get; set; }

    }
}
