using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Value
    {
        public List<Venue> Venues { get; set; } = new List<Venue>();

        public List<TicketEvent> Events { get; set; } = new List<TicketEvent>();

    }
}
