using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class EventSummary
    {
        public int TicketEventDateID { get; set; }
        public string EventName { get; set; }
        public string EventHtmlDescription { get; set; }
        public string VenueName { get; set; }
        public DateTime EventStartDateTime { get; set; }
    }
}
