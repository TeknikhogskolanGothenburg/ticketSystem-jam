using RestSharp;
using System;
using System.Collections.Generic;
using TicketSystem.RestApiClient.Model;
using ClassLibrary;
using Newtonsoft.Json;

namespace TicketSystem.RestApiClient
{
    public class TicketApi : ITicketApi
    {
        // Implemented using RestSharp: http://restsharp.org/
        string localhost = "http://localhost:61835/api/";
        //TicketEvent Calls
        public List<TicketEvent> GetAllEvents()
        {
            var client = new RestClient(localhost);
            var request = new RestRequest("TicketEvents", Method.GET);
            var response = client.Execute<List<TicketEvent>>(request);
            return response.Data;
        }

        public List<TicketEvent> GetEvents(int id)
        {
            var client = new RestClient(localhost);
            var request = new RestRequest("TicketEvents/{id}", Method.GET);
            request.AddUrlSegment("id", id);
            var response = client.Execute<List<TicketEvent>>(request);
            return response.Data;
        }

        public void EventsAdd(TicketEvent ticketEvent)
        {
            var output = JsonConvert.SerializeObject(ticketEvent);
            var client = new RestClient(localhost);
            var request = new RestRequest("TicketEvents", Method.POST);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var response = client.Execute<TicketEvent>(request); //Vad gör den här raden?
        }

        public void EventsUpdate(int id, TicketEvent ticketEvent)
        {
            var output = JsonConvert.SerializeObject(ticketEvent);
            var client = new RestClient(localhost);
            var request = new RestRequest("TicketEvents/{id}", Method.PUT);
            request.AddUrlSegment("id", id);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var response = client.Execute<TicketEvent>(request);
        }

        public void DeleteEvent(int id)
        {
            var client = new RestClient(localhost);
            var request = new RestRequest("TicketEvents/{id}", Method.DELETE);
            request.AddUrlSegment("id", id);
            var respons = client.Execute<TicketEvent>(request);
        }

        //Venue Calls
        public List<Venue> GetAllVenues()
        {
            var client = new RestClient(localhost);
            var request = new RestRequest("venues", Method.GET);
            var response = client.Execute<List<Venue>>(request);
            return response.Data;
        }

        public Venue GetVenues(int id)
        {
            var client = new RestClient(localhost);
            var request = new RestRequest("venues/{id}", Method.GET);
            request.AddUrlSegment("id", id);
            var response = client.Execute<Venue>(request);
            return response.Data;
        }

        public void VenueAdd(Venue venue)
        {
            var output = JsonConvert.SerializeObject(venue);
            var client = new RestClient(localhost);
            var request = new RestRequest("venues", Method.POST);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var response = client.Execute<Venue>(request);
        }

        public void VenuesUpdate(int id, Venue venue)
        {
            var output = JsonConvert.SerializeObject(venue);
            var client = new RestClient(localhost);
            var request = new RestRequest("venues/{id}", Method.PUT);
            request.AddUrlSegment("id", id);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var response = client.Execute<Venue>(request);
        }

        public void DeleteVenues(int id)
        {
            var client = new RestClient(localhost);
            var request = new RestRequest("venues/{id}", Method.DELETE);
            request.AddUrlSegment("id", id);
            var response = client.Execute(request);
        }

        //TicketEventDates calls
        public List<TicketEventDate> GetAllEventDates()
        {
            var client = new RestClient(localhost);
            var request = new RestRequest("ticketeventdates", Method.GET);
            var response = client.Execute<List<TicketEventDate>>(request);
            return response.Data;
        }

        public List<TicketEventDate> GetEventDates(int id)
        {
            var client = new RestClient(localhost);
            var request = new RestRequest("ticketeventdates/{id}", Method.GET);
            request.AddUrlSegment("id", id);
            var response = client.Execute<List<TicketEventDate>>(request);
            return response.Data;
        }

        public void EventDatesAdd(TicketEventDate ticketEventDate)
        {
            var output = JsonConvert.SerializeObject(ticketEventDate);
            var client = new RestClient(localhost);
            var request = new RestRequest("ticketeventdates", Method.POST);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var response = client.Execute<TicketEventDate>(request);
        }

        public void EventDatesUpdate(int id, TicketEventDate ticketEventDate)
        {
            var output = JsonConvert.SerializeObject(ticketEventDate);                      //Serialiaze'a objektet vi skickar in
            var client = new RestClient(localhost);                                         //En instans av Restclient med adress
            var request = new RestRequest("ticketeventdates/{id}", Method.PUT);             //En instans av Restrequest med routing och metod info.
            request.AddUrlSegment("id", id);                                                //Addar id parametern till URL segementet
            request.AddParameter("application/json", output, ParameterType.RequestBody);    //content-type, data, det är request body vi skickar.
            var response = client.Execute<TicketEventDate>(request);                        //Exekuterar request med client och sparar i reponse.
        }

        public void DeleteEventDates(int id)
        {
            var client = new RestClient(localhost);
            var request = new RestRequest("ticketeventdates/{id}", Method.DELETE);
            request.AddUrlSegment("id", id);
            var response = client.Execute<TicketEventDate>(request);
        }

        //TicketTransaction calls
        public List<TicketTransaction> GetAllTicketTransactions()
        {
            var client = new RestClient(localhost);
            var request = new RestRequest("TicketTransactions", Method.GET);
            var response = client.Execute<List<TicketTransaction>>(request);
            return response.Data;
        }

        public TicketTransaction GetTicketTransactions(int id)
        {
            var client = new RestClient(localhost);
            var request = new RestRequest("TicketTransactions/{id}", Method.GET);
            request.AddUrlSegment("id", id);
            var response = client.Execute<TicketTransaction>(request);
            return response.Data;
        }

        public void TicketTransactionAdd(TicketTransaction ticketTransaction)
        {
            var output = JsonConvert.SerializeObject(ticketTransaction);
            var client = new RestClient(localhost);
            var request = new RestRequest("TicketTransactions", Method.POST);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var response = client.Execute<TicketTransaction>(request);
        }

        public void TicketTransactionUpdate(int id, TicketTransaction ticketTransaction)
        {
            var output = JsonConvert.SerializeObject(ticketTransaction);
            var client = new RestClient(localhost);
            var request = new RestRequest("TicketTransactions/{id}", Method.PUT);
            request.AddUrlSegment("id", id);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var response = client.Execute<TicketTransaction>(request);
        }

        public void DeleteTicketTransaction(int id)
        {
            var client = new RestClient(localhost);
            var request = new RestRequest("TicketTransactions/{id}", Method.DELETE);
            request.AddUrlSegment("id", id);
            var response = client.Execute<TicketTransaction>(request);
        }

        //Ticket Calls 
        public List<Ticket> TicketGet()
        {
            var client = new RestClient(localhost);
            var request = new RestRequest("ticket", Method.GET);
            var response = client.Execute<List<Ticket>>(request);
            return response.Data;
        }

        public Ticket TicketTicketIdGet(int ticketId)
        {
            var client = new RestClient(localhost);
            var request = new RestRequest("ticket/{id}", Method.GET);
            request.AddUrlSegment("id", ticketId);
            var response = client.Execute<Ticket>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException(string.Format("Ticket with ID: {0} is not found", ticketId));
            }

            return response.Data;
        }

        public Tickets PurchasedTickets(SeatsAtEventDate eventId)
        {
            var json = JsonConvert.SerializeObject(eventId);
            var client = new RestClient(localhost);
            var request = new RestRequest("shop", Method.POST);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            var response = client.Execute<Tickets>(request);
            return response.Data;
        }

        //Join table calls
        public EventSummary GetSummary(int id)
        {
            var client = new RestClient(localhost);
            var request = new RestRequest("TicketEventDates/{id}/Summary", Method.GET);
            request.AddUrlSegment("id", id);
            var response = client.Execute<EventSummary>(request);
            return response.Data;
        }
    }
}

