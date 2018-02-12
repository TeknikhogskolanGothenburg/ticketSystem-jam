using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class TicketEventDate
    {
        //public int TicketEventDateID { get; set; }
        public int TicketEventID { get; set; }
        public int VenueId { get; set; }
        public DateTime EventStartDateTime { get; set; }
    }
}
