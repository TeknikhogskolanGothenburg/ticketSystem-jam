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

        string localhost = "http://localhost:50248/api/";

        //TicketEvent Calls
        /// <summary>
        /// Get all Events from the database.
        /// </summary>
        /// <returns>EventID, Name , Description</returns>
        public List<TicketEvent> GetAllEvents()
        {
            var client = new RestClient(localhost);
            var request = new RestRequest("TicketEvents", Method.GET);
            var response = client.Execute<List<TicketEvent>>(request);
            return response.Data;
        }
        /// <summary>
        /// Gets a specific Event returned based on the input id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Specific EventID, Name , Description </returns>
        public List<TicketEvent> GetEvents(int id)
        {
            var client = new RestClient(localhost);
            var request = new RestRequest("TicketEvents/{id}", Method.GET);
            request.AddUrlSegment("id", id);
            var response = client.Execute<List<TicketEvent>>(request);
            return response.Data;
        }
        /// <summary>
        /// Adds an Event - EventID, Name , Description - To the database
        /// </summary>
        /// <param name="ticketEvent"></param>
        public void EventsAdd(TicketEvent ticketEvent)
        {
            var output = JsonConvert.SerializeObject(ticketEvent);
            var client = new RestClient(localhost);
            var request = new RestRequest("TicketEvents", Method.POST);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var response = client.Execute<TicketEvent>(request); 
        }

        /// <summary>
        /// Updates chosen properties to an existing Event, based on input EventID.
        /// </summary>
        /// <param name="id">EventID</param>
        /// <param name="ticketEvent">Properties in Class TicketEvent</param>

        public void EventsUpdate(int id, TicketEvent ticketEvent)
        {
            var output = JsonConvert.SerializeObject(ticketEvent);
            var client = new RestClient(localhost);
            var request = new RestRequest("TicketEvents/{id}", Method.PUT);
            request.AddUrlSegment("id", id);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var response = client.Execute<TicketEvent>(request);
        }

        /// <summary>
        /// Deletes chosen Event based on selected EventID.
        /// </summary>
        /// <param name="id">EventID</param>
        public void DeleteEvent(int id)
        {
            var client = new RestClient(localhost);
            var request = new RestRequest("TicketEvents/{id}", Method.DELETE);
            request.AddUrlSegment("id", id);
            var respons = client.Execute<TicketEvent>(request);
        }

        //Venue Calls
        /// <summary>
        /// Get all Venues from the database.
        /// </summary>
        /// <returns>VenueID, Address, City, Country, Seats</returns>
        public List<Venue> GetAllVenues()
        {
            var client = new RestClient(localhost);
            var request = new RestRequest("venues", Method.GET);
            var response = client.Execute<List<Venue>>(request);
            return response.Data;
        }
        /// <summary>
        /// Get a specific Venue based on the selected VenueID
        /// </summary>
        /// <param name="id">VenueID</param>
        /// <returns>Selected VenueID, Address, City, Country, Seats
        /// </returns>

        public Venue GetVenues(int id)
        {
            var client = new RestClient(localhost);
            var request = new RestRequest("venues/{id}", Method.GET);
            request.AddUrlSegment("id", id);
            var response = client.Execute<Venue>(request);
            return response.Data;
        }
        /// <summary>
        /// Posts a new Venue object to the database. - Selected VenueID, Address, City, Country, Seats
        /// </summary>
        /// <param name="venue"></param>
        public void VenueAdd(Venue venue)
        {
            var output = JsonConvert.SerializeObject(venue);
            var client = new RestClient(localhost);
            var request = new RestRequest("venues", Method.POST);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var response = client.Execute<Venue>(request);
        }
        /// <summary>
        /// Updates a specific Venue object based on the selected VenueID.
        /// </summary>
        /// <param name="id">VenueID</param>
        /// <param name="venue">VenueID, Address, City, Country, Seats</param>

        public void VenuesUpdate(int id, Venue venue)
        {
            var output = JsonConvert.SerializeObject(venue);
            var client = new RestClient(localhost);
            var request = new RestRequest("venues/{id}", Method.PUT);
            request.AddUrlSegment("id", id);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var response = client.Execute<Venue>(request);
        }
        /// <summary>
        /// Deletes a Venue objcet based on selected VenueID.
        /// </summary>
        /// <param name="id">VenueID</param>

        public void DeleteVenues(int id)
        {
            var client = new RestClient(localhost);
            var request = new RestRequest("venues/{id}", Method.DELETE);
            request.AddUrlSegment("id", id);
            var response = client.Execute(request);
        }

        //TicketEventDates calls

        /// <summary>
        /// Get all TicketEventDates from the database.
        /// </summary>
        /// <returns>TicketEventDateID, TicketEventID, VenueId, EventStartDateTime</returns>
        public List<TicketEventDate> GetAllEventDates()
        {
            var client = new RestClient(localhost);
            var request = new RestRequest("ticketeventdates", Method.GET);
            var response = client.Execute<List<TicketEventDate>>(request);
            return response.Data;
        }
        /// <summary>
        /// Get a specific Event on a certain place and date, selected by a TicketEventDateID.
        /// </summary>
        /// <param name="id">TicketEventDateID</param>
        /// <returns>selected TicketEventDateID, TicketEventID, VenueId, EventStartDateTime</returns>
        public TicketEventDate GetEventDates(int id)
        {
            var client = new RestClient(localhost);
            var request = new RestRequest("ticketeventdates/{id}", Method.GET);
            request.AddUrlSegment("id", id);
            var response = client.Execute<TicketEventDate>(request);
            return response.Data;
        }
        /// <summary>
        /// Adds a new TicketEventDate object to the database. 
        /// </summary>
        /// <param name="ticketEventDate">TicketEventDateID, TicketEventID, VenueId, EventStartDateTime</param>
        public void EventDatesAdd(TicketEventDate ticketEventDate)
        {
            var output = JsonConvert.SerializeObject(ticketEventDate);
            var client = new RestClient(localhost);
            var request = new RestRequest("ticketeventdates", Method.POST);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var response = client.Execute<TicketEventDate>(request);
        }
        /// <summary>
        /// Updates a specific TicketEventDate object, selected by the TicketEventDateID.
        /// </summary>
        /// <param name="id">TicketEventDateID</param>
        /// <param name="ticketEventDate">TicketEventDateID, TicketEventID, VenueId, EventStartDateTime</param>
        public void EventDatesUpdate(int id, TicketEventDate ticketEventDate)
        {
            var output = JsonConvert.SerializeObject(ticketEventDate);                      //Serialiaze'a objektet vi skickar in
            var client = new RestClient(localhost);                                         //En instans av Restclient med adress
            var request = new RestRequest("ticketeventdates/{id}", Method.PUT);             //En instans av Restrequest med routing och metod info.
            request.AddUrlSegment("id", id);                                                //Addar id parametern till URL segementet
            request.AddParameter("application/json", output, ParameterType.RequestBody);    //content-type, data, det är request body vi skickar.
            var response = client.Execute<TicketEventDate>(request);                        //Exekuterar request med client och sparar i reponse.
        }
        /// <summary>
        /// Deletes a TicketEventDate object from the database, based on selected TicketEventDateID.
        /// </summary>
        /// <param name="id">TicketEventDateID</param>
        public void DeleteEventDates(int id)
        {
            var client = new RestClient(localhost);
            var request = new RestRequest("ticketeventdates/{id}", Method.DELETE);
            request.AddUrlSegment("id", id);
            var response = client.Execute<TicketEventDate>(request);
        }

        //TicketTransaction calls
        /// <summary>
        /// Get all TicketTransactions from the database.
        /// </summary>
        /// <returns>TransactionID, BuyerLastName, BuyerFirstName, BuyerAddress, BuyerCity, BuyerEmail, PaymentStatus, PaymentReferenceId</returns>
        public List<TicketTransaction> GetAllTicketTransactions()
        {
            var client = new RestClient(localhost);
            var request = new RestRequest("TicketTransactions", Method.GET);
            var response = client.Execute<List<TicketTransaction>>(request);
            return response.Data;
        }
        /// <summary>
        /// Get a specific TicketTransaction from the database, based on selected TransactionID.
        /// </summary>
        /// <param name="id">TransactionID</param>
        /// <returns>TransactionID, BuyerLastName, BuyerFirstName, BuyerAddress, BuyerCity, BuyerEmail, PaymentStatus, PaymentReferenceId</returns>

        public TicketTransaction GetTicketTransactions(int id)
        {
            var client = new RestClient(localhost);
            var request = new RestRequest("TicketTransactions/{id}", Method.GET);
            request.AddUrlSegment("id", id);
            var response = client.Execute<TicketTransaction>(request);
            return response.Data;
        }
        /// <summary>
        /// Adds a new TicketTransaction to the database.
        /// </summary>
        /// <param name="ticketTransaction">TransactionID, BuyerLastName, BuyerFirstName, BuyerAddress, BuyerCity, BuyerEmail, PaymentStatus, PaymentReferenceId</param>
        /// <returns>TransactionID, BuyerLastName, BuyerFirstName, BuyerAddress, BuyerCity, BuyerEmail, PaymentStatus, PaymentReferenceId</returns>
        public TicketTransaction TicketTransactionAdd(TicketTransaction ticketTransaction)
        {
            var output = JsonConvert.SerializeObject(ticketTransaction);
            var client = new RestClient(localhost);
            var request = new RestRequest("TicketTransactions", Method.POST);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var response = client.Execute<TicketTransaction>(request);
            return response.Data;
        }

        /// <summary>
        /// Updates a chosen TicketTransaction, based on selected TransactionID.
        /// </summary>
        /// <param name="id">TransactionID</param>
        /// <param name="ticketTransaction">TransactionID, BuyerLastName, BuyerFirstName, BuyerAddress, BuyerCity, BuyerEmail, PaymentStatus, PaymentReferenceId</param>
        public void TicketTransactionUpdate(int id, TicketTransaction ticketTransaction)
        {
            var output = JsonConvert.SerializeObject(ticketTransaction);
            var client = new RestClient(localhost);
            var request = new RestRequest("TicketTransactions/{id}", Method.PUT);
            request.AddUrlSegment("id", id);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var response = client.Execute<TicketTransaction>(request);
        }
        /// <summary>
        /// Deletes a chosen TicketTransaction from the database, selected by the TransactionID.
        /// </summary>
        /// <param name="id">TransactionID</param>
        public void DeleteTicketTransaction(int id)
        {
            var client = new RestClient(localhost);
            var request = new RestRequest("TicketTransactions/{id}", Method.DELETE);
            request.AddUrlSegment("id", id);
            var response = client.Execute<TicketTransaction>(request);
        }
        /// <summary>
        /// Get all TicketTransactions (Customers) based on a querystring, containing the letters from part of the Customername.
        /// </summary>
        /// <param name="query">BuyerLastName, BuyerFirstName</param>
        /// <returns>BuyerLastName, BuyerFirstName, BuyerAddress, BuyerCity</returns>

        public List<TicketTransaction> GetCustomer(string query)
        {
            var client = new RestClient(localhost);
            var request = new RestRequest("TicketTransactions/User/{query}", Method.GET);
            request.AddUrlSegment("query", query);
            var response = client.Execute<List<TicketTransaction>>(request);
            return response.Data;
        }
        //Ticket Calls 
        /// <summary>
        /// Get all Tickets from the database.
        /// </summary>
        /// <returns>TicketId, SeatId
        /// </returns>
        public List<Ticket> TicketGet()
        {
            var client = new RestClient(localhost);
            var request = new RestRequest("ticket", Method.GET);
            var response = client.Execute<List<Ticket>>(request);
            return response.Data;
        }
        /// <summary>
        /// Posts information from SeatsAtEventDate to the Tickets table in the database.
        /// </summary>
        /// <param name="seatsAtEventDate">SeatId</param>
        /// <returns>TicketId, SeatId</returns>
        public Tickets PurchasedTickets(SeatsAtEventDate seatsAtEventDate)
        {
            var json = JsonConvert.SerializeObject(seatsAtEventDate);
            var client = new RestClient(localhost);
            var request = new RestRequest("TicketTransactions/Ticket/", Method.POST);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            var response = client.Execute<Tickets>(request);
            return response.Data;
        }
        /// <summary>
        /// Gets a Ticket from the database, based on a selected TicketId. Throws an exception if ticket don't exist.
        /// </summary>
        /// <param name="ticketId">TicketId</param>
        /// <returns>TicketId, SeatId</returns>
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

        //Join table calls
        /// <summary>
        /// Get all EventSummary from the database.
        /// </summary>
        /// <returns>TicketEventDateID, EventName, EventHtmlDescription, VenueName, EventStartDateTime</returns>
        public List<EventSummary> GetAllSummary()
        {
            var client = new RestClient(localhost);
            var request = new RestRequest("TicketEventDates/Summary/", Method.GET);
            var response = client.Execute<List<EventSummary>>(request);
            return response.Data;
        }
        /// <summary>
        /// Gets a chosen EventSummary, based on selected querystring, from the EventName.
        /// </summary>
        /// <param name="id">EventName</param>
        /// <returns>TicketEventDateID, EventName, EventHtmlDescription, VenueName, EventStartDateTime</returns>
        public List<EventSummary> GetSearchSummary(string id)
        {
            var client = new RestClient(localhost);
            var request = new RestRequest("TicketEventDates/{id}/Search", Method.GET);
            request.AddUrlSegment("id", id);
            var response = client.Execute<List<EventSummary>>(request);
            return response.Data;
        }
        /// <summary>
        /// Gets a chosen EventSummary, based on selected TicketEventDateID.
        /// </summary>
        /// <param name="id">TicketEventDateID</param>
        /// <returns>TicketEventDateID, EventName, EventHtmlDescription, VenueName, EventStartDateTime</returns>

        public EventSummary GetSummary(int id)
        {
            var client = new RestClient(localhost);
            var request = new RestRequest("TicketEventDates/{id}/Summary", Method.GET);
            request.AddUrlSegment("id", id);
            var response = client.Execute<EventSummary>(request);
            return response.Data;
        }
        /// <summary>
        /// Adds a SeatAtEventDate to the database.
        /// </summary>
        /// <param name="eventSummary">TicketEventDateId</param>
        /// <returns>SeatId, TicketEventDateId</returns>

        public SeatsAtEventDate PurchasedSeats(EventSummary eventSummary)
        {
            var json = JsonConvert.SerializeObject(eventSummary);
            var client = new RestClient(localhost);
            var request = new RestRequest("TicketTransactions/Seat/", Method.POST);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            var response = client.Execute<SeatsAtEventDate>(request);
            return response.Data;
        }

        /// <summary>
        /// Adds a TicketBuyer to the TicketToTransaction table in the database.
        /// </summary>
        /// <param name="ticketToTransaction">TicketID, TransactionID</param>
        /// <returns>TicketID, TransactionID</returns>
        public TicketToTransaction AddTicketBuyer(TicketToTransaction ticketToTransaction)
        {
            var json = JsonConvert.SerializeObject(ticketToTransaction);
            var client = new RestClient(localhost);
            var request = new RestRequest("TicketTransactions/TicketBuyer/", Method.POST);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            var response = client.Execute<TicketToTransaction>(request);
            return response.Data;
        }
        /// <summary>
        /// Gets a specific TicketBuyer, based on selected CustomerID
        /// </summary>
        /// <param name="id">TransactionID</param>
        /// <returns>TicketEventDateID, EventName, EventHtmlDescription, VenueName, EventStartDateTime</returns>
        public List<EventSummary> FindTicketBuyer(int id)
        {
            var client = new RestClient(localhost);
            var request = new RestRequest("TicketTransactions/Ticket/{id}", Method.GET);
            request.AddUrlSegment("id", id);
            var response = client.Execute<List<EventSummary>>(request);
            return response.Data;
        }
    }
}

