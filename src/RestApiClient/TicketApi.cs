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

        



        public List<Ticket> TicketGet()
        {
            var client = new RestClient("http://localhost:61835");
            var request = new RestRequest("ticket", Method.GET);
            var response = client.Execute<List<Ticket>>(request);
            return response.Data;
        }        

        public List<Venue> VenueGet()
        {
            var client = new RestClient("http://localhost:60234/api/"); 
            var request = new RestRequest("venues", Method.GET);
            var response = client.Execute<List<Venue>>(request);
            return response.Data;
        }

        public void VenueAdd(Venue venue)
        {
            var json = JsonConvert.SerializeObject(venue);
            var client = new RestClient("http://localhost:60234/api/");
            var request = new RestRequest("venues", Method.POST);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            var response = client.Execute<Venue>(request);
        }

        //public static IRestResponse Create<T>(object objectToUpdate, string apiEndPoint) where T : new()
        //{
        //    var json = JsonConvert.SerializeObject(objectToUpdate);
        //    var request = new RestRequest(apiEndPoint, Method.POST);
        //    request.AddParameter("text/json", json, ParameterType.RequestBody);
        //    var response = client.Execute<T>(request);
        //    return response;
        //}

        public void VenueDelete(int id)
        {
            var client = new RestClient("http://localhost:60234/api/");
            var request = new RestRequest("venues/{id}", Method.DELETE);
            request.AddUrlSegment("id", id);
            var response = client.Execute(request);
        }

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
    }
}
