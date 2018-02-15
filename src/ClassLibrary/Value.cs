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

        public List<TicketEvent> Events = new List<TicketEvent>();

        public List<Tickets> BookTicket = new List<Tickets>();

        public List<TicketEventDate> TicketEventDate { get; set; } = new List<TicketEventDate>(); //behöver lite att testa med..

        public List<TicketTransaction> TicketTransaction { get; set; } = new List<TicketTransaction>(); //..och lite mer.


        public List<EventSummary> EventSummaries { get; set; } = new List<EventSummary>(); // ...nu nu .. nu är det den sista.

        public TicketEventDate TicketEventDates { get; set; }

        public List<TicketEventDate> Cart { get; set; } = new List<TicketEventDate>();

        public List<EventSummary> CartSummary { get; set; } = new List<EventSummary>();

        public int Id { get; set; }
        public TicketTransaction  TicketByuer { get; set; }

        public AllModels AllModels { get; set; }



    }
}
