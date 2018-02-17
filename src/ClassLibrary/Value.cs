using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace ClassLibrary
{
    public class Value
    {
        public List<Venue> Venues { get; set; } = new List<Venue>();

        public Venue Venue { get; set; }

        public TicketEvent TicketEvent { get; set; }

        public List<TicketEvent> Events = new List<TicketEvent>();

        public List<Tickets> BookTicket = new List<Tickets>();

        public List<TicketEventDate> TicketEventDate { get; set; } = new List<TicketEventDate>();

        public List<TicketTransaction> TicketTransaction { get; set; } = new List<TicketTransaction>();
                         
        public List<EventSummary> EventSummaries { get; set; } = new List<EventSummary>();

        public TicketEventDate TicketEventDates { get; set; }

        public List<TicketEventDate> Cart { get; set; } = new List<TicketEventDate>();

        public List<EventSummary> CartSummary { get; set; } = new List<EventSummary>();

        public int Id { get; set; }
        public TicketTransaction TicketBuyer { get; set; }

        public AllModels AllModels { get; set; }

        public List<int> cartListId  { get; set; }

        public TicketToTransaction TicketToTransaction { get; set; }

        public Tickets Tickets { get; set; }
        public List <TicketToTransaction> TickToTrans { get; set; }


    }
}
