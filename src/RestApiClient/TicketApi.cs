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

        //TicketEvent Calls
        public List<TicketEvent> GetAllEvents()
        {
            var client = new RestClient("http://localhost:61835/api/");
            var request = new RestRequest("TicketEvents", Method.GET);
            var response = client.Execute<List<TicketEvent>>(request);
            return response.Data;
        }

        public List<TicketEvent> GetEvents(int id)
        {            
            var client = new RestClient("http://localhost:61835/api/");
            var request = new RestRequest("TicketEvents/{id}", Method.GET);
            request.AddUrlSegment("id", id);
            var response = client.Execute<List<TicketEvent>>(request);
            return response.Data;
        }

        public void EventsAdd(TicketEvent ticketEvent)
        {
            var output = JsonConvert.SerializeObject(ticketEvent);
            var client = new RestClient("http://localhost:61835/api");
            var request = new RestRequest("TicketEvents", Method.POST);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var response = client.Execute<TicketEvent>(request); //Vad gör den här raden?
        }

        public void EventsUpdate(int id, TicketEvent ticketEvent)
        {
            var output = JsonConvert.SerializeObject(ticketEvent);
            var client = new RestClient("http://localhost:61835/api");
            var request = new RestRequest("TicketEvents/{id}", Method.PUT);
            request.AddUrlSegment("id", id);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var response = client.Execute<TicketEvent>(request);
        }

        public void DeleteEvent(int id)
        {
            var client = new RestClient("http://localhost:61835/api");
            var request = new RestRequest("TicketEvents/{id}", Method.DELETE);
            request.AddUrlSegment("id", id);
            var respons = client.Execute<TicketEvent>(request);
        }

        //Venue Calls
        public List<Venue> GetAllVenues()
        {
            var client = new RestClient("http://localhost:61835/api/");
            var request = new RestRequest("venues", Method.GET);
            var response = client.Execute<List<Venue>>(request);
            return response.Data;
        }

        public List<Venue> GetVenues(int id)
        {
            var client = new RestClient("http://localhost:61835/api/");
            var request = new RestRequest("venues/{id}", Method.GET);
            request.AddUrlSegment("id", id);
            var response = client.Execute<List<Venue>>(request);
            return response.Data;
        }

        public void VenueAdd(Venue venue)
        {
            var output = JsonConvert.SerializeObject(venue);
            var client = new RestClient("http://localhost:61835/api/");
            var request = new RestRequest("venues", Method.POST);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var response = client.Execute<Venue>(request);
        }

        public void VenuesUpdate(int id, Venue venue)
        {
            var output = JsonConvert.SerializeObject(venue);
            var client = new RestClient("http://localhost:61835/api/");
            var request = new RestRequest("venues/{id}", Method.PUT);
            request.AddUrlSegment("id", id);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var response = client.Execute<Venue>(request);
        }

        public void DeleteVenues(int id)
        {
            var client = new RestClient("http://localhost:61835/api/");
            var request = new RestRequest("venues/{id}", Method.DELETE);
            request.AddUrlSegment("id", id);
            var response = client.Execute(request);
        }

        //TicketEventDates calls
        public List<TicketEventDate> GetAllEventDates()
        {
            var client = new RestClient("http://localhost:61835");
            var request = new RestRequest("ticketeventdates", Method.GET);
            var response = client.Execute<List<TicketEventDate>>(request);
            return response.Data;
        }

        public List<TicketEventDate> GetEventDates


        //Ticket Calls 
        public List<Ticket> TicketGet()
        {
            var client = new RestClient("http://localhost:61835");
            var request = new RestRequest("ticket", Method.GET);
            var response = client.Execute<List<Ticket>>(request);
            return response.Data;
        }      
             
        //public static IRestResponse Create<T>(object objectToUpdate, string apiEndPoint) where T : new()
        //{
        //    var json = JsonConvert.SerializeObject(objectToUpdate);
        //    var request = new RestRequest(apiEndPoint, Method.POST);
        //    request.AddParameter("text/json", json, ParameterType.RequestBody);
        //    var response = client.Execute<T>(request);
        //    return response;
        //}        

        public Ticket TicketTicketIdGet(int ticketId)
        {
            var client = new RestClient("http://localhost:18001/");
            var request = new RestRequest("ticket/{id}", Method.GET);
            request.AddUrlSegment("id", ticketId);
            var response = client.Execute<Ticket>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException(string.Format("Ticket with ID: {0} is not found", ticketId));
            }

            return response.Data;
        }

        public Tickets PurchasedTickets( SeatsAtEventDate eventId)
        {
            var json = JsonConvert.SerializeObject(eventId);
            var client = new RestClient("http://localhost:49270/api/");
            var request = new RestRequest("shop", Method.POST);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            var response = client.Execute<Tickets>(request);
            return response.Data;
        }
    }
}

