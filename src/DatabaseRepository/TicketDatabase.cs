﻿using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using ClassLibrary;

namespace TicketSystem.DatabaseRepository
{
    public class TicketDatabase : ITicketDatabase
    {
        string connectionString = "Server=(local)\\SqlExpress; Database=TicketSystem; Trusted_connection=true";

        // TicketEventController Queries
        public List<TicketEvent> GetAllEvents()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string queryString = "SELECT * FROM TicketEvents";
                connection.Open();
                return connection.Query<TicketEvent>(queryString).ToList();
            }
        }

        public TicketEvent GetEvents(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string queryString = "SELECT * FROM TicketEvents WHERE TicketEventID = @ID";
                connection.Open();
                return connection.Query<TicketEvent>(queryString, new { ID = id }).First();
            }
        }

        public TicketEvent EventsAdd(TicketEvent ticketEvent)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string queryString = "INSERT INTO TicketEvents(EventName, EventHtmlDescription) VALUES(@Name, @Description)";
                connection.Open();
                connection.Query(queryString, new { Name = ticketEvent.EventName, Description = ticketEvent.EventHtmlDescription });
                var addedEventQuery = connection.Query<int>("SELECT IDENT_CURRENT ('TicketEvents') AS Current_Identity").First();
                return connection.Query<TicketEvent>("SELECT * FROM TicketEvents WHERE TicketEventID=@Id", new { Id = addedEventQuery }).First();
            }
        }

        public TicketEvent EventsUpdate(int id, TicketEvent ticketEvent)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query("UPDATE TicketEvents SET EventName = @eventName, " + " EventHtmlDescription = @description " + "WHERE TicketEventID = @ID", new { eventName = ticketEvent.EventName, description = ticketEvent.EventHtmlDescription, ID = id });
                var addedEventQuery = connection.Query<int>("SELECT IDENT_CURRENT ('TicketEvents') AS Current_Identity").First();
                return connection.Query<TicketEvent>("SELECT * FROM TicketEvents WHERE TicketEventID=@Id", new { Id = id }).First();
            }
        }

        public void DeleteEvents(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query("DELETE FROM TicketEvents WHERE TicketEventID = @ID", new { ID = id });
            }
        }

        //VenuesController Queries
        public List<Venue> GetAllVenues()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string queryString = "SELECT * FROM Venues";
                connection.Open();
                return connection.Query<Venue>(queryString).ToList();
            }
        }

        public Venue GetVenues(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string queryString = "SELECT * FROM Venues WHERE VenueID = @ID";
                connection.Open();
                return connection.Query<Venue>(queryString, new { ID = id }).First();
            }
        }

        public Venue VenuesAdd(Venue venue)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string queryString = "INSERT INTO Venues(VenueName, Address, City, Country, Seats) VALUES(@Name,@Address, @City, @Country, @Seats)";
                connection.Open();
                connection.Query(queryString, new
                {
                    Name = venue.VenueName,
                    venue.Address,
                    venue.City,
                    venue.Country,
                    venue.Seats
                });
                var addedVenueQuery = connection.Query<int>("SELECT IDENT_CURRENT ('Venues') AS Current_Identity").First();
                return connection.Query<Venue>("SELECT * FROM Venues WHERE VenueID=@Id", new { Id = addedVenueQuery }).First();
            }
        }

        public Venue VenuesUpdate(int id, Venue venue)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query("UPDATE Venues SET VenueName = @venueName, " + " Address = @address, " + " City = @city, " + " Country = @country, " + " Seats = @seats " + "WHERE VenueID = @ID",
                    new { venueName = venue.VenueName, address = venue.Address, city = venue.City, country = venue.Country, seats = venue.Seats, ID = id });
                return connection.Query<Venue>("SELECT * FROM Venues WHERE VenueID=@Id", new { Id = id }).First();
            }
        }

        public void DeleteVenue(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query("DELETE FROM Venues WHERE VenueID = @ID", new { ID = id });

            }
        }

        //EventDate Queries
        public List<TicketEventDate> GetAllEventDates()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string queryString = "SELECT * FROM TicketEventDates";
                connection.Open();
                return connection.Query<TicketEventDate>(queryString).ToList();
            }
        }

        public TicketEventDate GetEventDates(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string queryString = "SELECT * FROM TicketEventDates WHERE TicketEventDateID = @ID";
                connection.Open();
                return connection.Query<TicketEventDate>(queryString, new { ID = id }).First();
            }
        }

        public TicketEventDate EventDatesAdd(TicketEventDate ticketEventDate)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string queryString = "INSERT INTO TicketEventDates([TicketEventID],[VenueId],[EventStartDateTime]) VALUES(@TicketEventID,@VenueId, @EventStartDateTime)";
                connection.Open();
                connection.Query(queryString, new { TicketEventID = ticketEventDate.TicketEventID, VenueId = ticketEventDate.VenueId, EventStartDateTime = ticketEventDate.EventStartDateTime });
                var addedTicketEventDateQuery = connection.Query<int>("SELECT IDENT_CURRENT ('TicketEventDates') AS Current_Identity").First();
                return connection.Query<TicketEventDate>("SELECT * FROM TicketEventDates WHERE TicketEventDateID=@Id", new { Id = addedTicketEventDateQuery }).First();
            }
        }

        public TicketEventDate EventDatesUpdate(int id, TicketEventDate ticketEventDate)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query("UPDATE TicketEventDates SET TicketEventID = @ticketEventID, " + "VenueId = @venueID, " + "EventStartDateTime = @eventStartDateTime " + "WHERE TicketEventDateID = @ID",
                    new { ticketEventID = ticketEventDate.TicketEventID, venueID = ticketEventDate.VenueId, eventStartDateTime = ticketEventDate.EventStartDateTime, ID = id });
                return connection.Query<TicketEventDate>("SELECT * FROM TicketEventDates WHERE TicketEventDateID=@Id", new { Id = id }).First();
            }
        }

        public void DeleteEventDates(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query("DELETE FROM TicketEventDates WHERE TicketEventDateID = @ID", new { ID = id });
            }
        }

        //TicketTransaction Queries
        public List<TicketTransaction> GetAllTicketTransactions()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string queryString = "SELECT * FROM TicketTransactions";
                connection.Open();
                return connection.Query<TicketTransaction>(queryString).ToList();
            }
        }

        public TicketTransaction GetTicketTransactions(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string queryString = "SELECT * FROM TicketTransactions WHERE TransactionID = @ID  ";
                connection.Open();
                return connection.Query<TicketTransaction>(queryString, new { ID = id }).First();
            }
        }

        public TicketTransaction TicketTransactionsAdd(TicketTransaction ticketTransaction)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string queryString = "INSERT INTO TicketTransactions(BuyerLastName, BuyerFirstName, BuyerAddress, BuyerCity)" +
                    "VALUES (@LastName, @FirstName, @Address, @City)";
                connection.Open();
                connection.Query(queryString, new { LastName = ticketTransaction.BuyerLastName, FirstName = ticketTransaction.BuyerFirstName, Address = ticketTransaction.BuyerAddress, City = ticketTransaction.BuyerCity });
                var addedTicketEventDateQuery = connection.Query<int>("SELECT IDENT_CURRENT ('TicketTransactions') AS Current_Identity").First();
                return connection.Query<TicketTransaction>("SELECT * FROM TicketTransactions WHERE TransactionID=@Id", new { Id = addedTicketEventDateQuery }).First();
            }
        }

        public TicketTransaction TicketTransactionUpdate(int id, TicketTransaction ticketTransaction)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string queryString = "UPDATE TicketTransactions SET BuyerLastName = @LastName, " + "BuyerFirstName = @FirstName, " + "BuyerAddress = @Address, "
                    + "BuyerCity = @City, " + "PaymentStatus = @Status, " + "PaymentReferenceId = @ReferenceID " + "WHERE TransactionID = @ID";
                connection.Open();
                connection.Query(queryString, new { LastName = ticketTransaction.BuyerLastName, FirstName = ticketTransaction.BuyerFirstName, Address = ticketTransaction.BuyerAddress, City = ticketTransaction.BuyerAddress, Status = ticketTransaction.PaymentStatus, ReferenceID = ticketTransaction.PaymentReferenceId, ID = id });
                return connection.Query<TicketTransaction>("SELECT * FROM TicketTransactions WHERE TransactionID=@Id", new { ID = id }).First();
            }
        }

        public void DeleteTicketTransactions(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string queryString = "DELETE FROM TicketTransactions WHERE TransactionID = @ID";
                connection.Query(queryString, new { ID = id });
            }
        }

        public List<TicketTransaction> GetCustomer(string query)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string queryString = "SELECT * FROM TicketTransactions WHERE BuyerFirstName + ' ' + BuyerLastName LIKE '%' + @Query + '%'";
                connection.Open();
                return connection.Query<TicketTransaction>(queryString, new { Query = query }).ToList();
            }
        }

        //Ticket Queries
        public Tickets PurchasedTickets(SeatsAtEventDate seatsAtEventDate)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string queryStringTicket = "INSERT INTO Tickets(SeatID) values(@SeatID)";
                connection.Open();
                connection.Query(queryStringTicket, new { SeatID = seatsAtEventDate.SeatId });
                var addedTicketsQuery = connection.Query<int>("SELECT IDENT_CURRENT ('Tickets') AS Current_Identity").First();
                return connection.Query<Tickets>("SELECT * FROM Tickets WHERE TicketID=@Id", new { Id = addedTicketsQuery }).First();
            }
        }

        public SeatsAtEventDate PurchasedSeats(EventSummary eventSummary)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string queryStringSeat = "INSERT INTO SeatsAtEventDate  (TicketEventDateID) VALUES(@TicketEventDateID)";
                connection.Open();
                connection.Query(queryStringSeat, new { TicketEventDateID = eventSummary.TicketEventDateID });
                var addedSeatsAtEventDateQuery = connection.Query<int>("SELECT IDENT_CURRENT ('SeatsAtEventDate') AS Current_Identity").First();
                return connection.Query<SeatsAtEventDate>("SELECT * FROM SeatsAtEventDate WHERE SeatID=@Id", new { Id = addedSeatsAtEventDateQuery }).First();
            }
        }


        // Join table Queries
        public List<EventSummary> GetAllEventSummary()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string queryString = "SELECT TicketEventDates.TicketEventDateID, TicketEventDates.EventStartDateTime, TicketEvents.EventName, TicketEvents.EventHtmlDescription,  Venues.VenueName FROM" +
                    " TicketEventDates" +
                    " JOIN TicketEvents ON TicketEventDates.TicketEventID = TicketEvents.TicketEventID" +
                    " JOIN Venues ON TicketEventDates.VenueID = Venues.VenueID";
                connection.Open();
                var response = connection.Query<EventSummary>(queryString).ToList();
                return response;
            }
        }

        public EventSummary GetEventSummary(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string queryString = "SELECT TicketEventDates.TicketEventDateID, TicketEventDates.EventStartDateTime, TicketEvents.EventName, TicketEvents.EventHtmlDescription,  Venues.VenueName FROM" +
                    " TicketEventDates" +
                    " JOIN TicketEvents ON TicketEventDates.TicketEventID = TicketEvents.TicketEventID" +
                    " JOIN Venues ON TicketEventDates.VenueID = Venues.VenueID" +
                    " WHERE TicketEventDates.TicketEventDateID = @ID";
                connection.Open();
                var response = connection.Query<EventSummary>(queryString, new { ID = id }).First();
                return response;
            }
        }

        public List<EventSummary> GetSearchSummary(string id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string queryString = "SELECT TicketEventDates.TicketEventDateID, TicketEventDates.EventStartDateTime, TicketEvents.EventName, TicketEvents.EventHtmlDescription,  Venues.VenueName FROM" +
                    " TicketEventDates" +
                    " JOIN TicketEvents ON TicketEventDates.TicketEventID = TicketEvents.TicketEventID" +
                    " JOIN Venues ON TicketEventDates.VenueID = Venues.VenueID" +
                    " WHERE TicketEvents.EventName LIKE '%' + @id + '%'";
                connection.Open();
                var response = connection.Query<EventSummary>(queryString, new { ID = id }).ToList();
                return response;
            }
        }               

        public TicketToTransaction AddTicketBuyer(TicketToTransaction ticketToTransaction)

        {
            using (var connection = new SqlConnection(connectionString))
            {
                string queryString = "INSERT INTO TicketsToTransactions(TicketID, TransactionID) VALUES (@TicketID, @TransactionID)";
                connection.Open();
                connection.Query(queryString, new { TicketID = ticketToTransaction.TicketID, TransactionID = ticketToTransaction.TransactionID });
                return connection.Query<TicketToTransaction>("SELECT * FROM TicketsToTransactions WHERE TicketID=@Id", new { Id = ticketToTransaction.TicketID }).First();
            }
        }

        public List<EventSummary> FindTicketBuyer(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string queryString = "SELECT BuyerFirstName, BuyerLastName, EventName, VenueName, EventStartDateTime  FROM TicketTransactions" +
                    " JOIN TicketsToTransactions ON TicketTransactions.TransactionID = TicketsToTransactions.TransactionID" +
                    " JOIN Tickets ON TicketsToTransactions.TicketID = Tickets.TicketID" +
                    " JOIN SeatsAtEventDate ON Tickets.SeatID = SeatsAtEventDate.SeatID" +
                    " JOIN TicketEventDates ON SeatsAtEventDate.TicketEventDateID = TicketEventDates.TicketEventDateID" +
                    " JOIN TicketEvents ON TicketEventDates.TicketEventID = TicketEvents.TicketEventID" +
                    " JOIN Venues ON TicketEventDates.VenueId = Venues.VenueID" +
                    " WHERE TicketTransactions.TransactionID = @Id";
                connection.Open();
                var response = connection.Query<EventSummary>(queryString, new { Id = id }).ToList();
                return response;
            }
        }
    }
}
