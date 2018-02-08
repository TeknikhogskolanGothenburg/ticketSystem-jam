using System.Collections.Generic;
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

        // TicketEventController Methods
        public IEnumerable<string> GetAllEvents()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string queryString = "SELECT * FROM TicketEvents";
                connection.Open();
                return connection.Query<string>(queryString).ToList();
            }
        }

        public List<TicketEvent> GetEvents(string query)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string queryString = "SELECT * FROM TicketEvents WHERE EventName like '%" + query + "%' OR EventHtmlDescription like '%" + query + "%'";
                connection.Open();
                return connection.Query<TicketEvent>(queryString).ToList();
            }
        }

        public TicketEvent EventsAdd(TicketEvent ticketEvent)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string queryString = "insert into TicketEvents(EventName, EventHtmlDescription) values(@Name, @Description)";
                connection.Open();
                connection.Query(queryString, new { Name = ticketEvent.EventName, Description = ticketEvent.EventHtmlDescription });
                var addedEventQuery = connection.Query<int>("SELECT IDENT_CURRENT ('TicketEvents') AS Current_Identity").First();
                return connection.Query<TicketEvent>("SELECT * FROM TicketEvents WHERE TicketEventID=@Id", new { Id = addedEventQuery }).First();
            }
        }

        public TicketEvent EventsUpdate(string nameInput, TicketEvent ticketEvent)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query("UPDATE TicketEvents SET EventName = @eventName, " + " EventHtmlDescription = @description " + "WHERE EventName = @name", new { eventName = ticketEvent.EventName, description = ticketEvent.EventHtmlDescription, name = nameInput });
                var addedEventQuery = connection.Query<int>("SELECT IDENT_CURRENT ('TicketEvents') AS Current_Identity").First();
                return connection.Query<TicketEvent>("SELECT * FROM TicketEvents WHERE TicketEventID=@Id", new { Id = addedEventQuery }).First();
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

        //VenuesController Methods
        public List<Venue> GetAllVenues()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string queryString = "SELECT * FROM Venues";
                connection.Open();
                return connection.Query<Venue>(queryString).ToList();
            }
        }

        public Venue GetVenues(string query)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string queryString = "SELECT * FROM Venues WHERE VenueName like '%" + query + "%'";
                connection.Open();
                return connection.Query<Venue>(queryString).First();
            }
        }

        public Venue VenuesAdd(Venue venue)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string queryString = "insert into Venues([VenueName],[Address],[City],[Country]) values(@Name,@Address, @City, @Country)";
                connection.Open();
                connection.Query(queryString, new { Name = venue.VenueName, Address = venue.Address, City = venue.City, Country = venue.Country });
                var addedVenueQuery = connection.Query<int>("SELECT IDENT_CURRENT ('Venues') AS Current_Identity").First();
                return connection.Query<Venue>("SELECT * FROM Venues WHERE VenueID=@Id", new { Id = addedVenueQuery }).First();
            }
        }

        public Venue VenuesUpdate(string nameInput, Venue venue)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query("UPDATE Venues SET VenueName = @venueName, " + " Address = @address, " + " City = @city, " + " Country = @country, " + " Seats = @seats " + "WHERE VenueName = @name",
                    new { venueName = venue.VenueName, address = venue.Address, city = venue.City, country = venue.Country, seats = venue.Seats, name = nameInput });
                var addedVenueQuery = connection.Query<int>("SELECT IDENT_CURRENT ('Venues') AS Current_Identity").First();
                return connection.Query<Venue>("SELECT * FROM Venues WHERE VenueID=@Id", new { Id = addedVenueQuery }).First();
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

        //EventDate Methods
        public TicketEventDate EventDateAdd(int eventId, int dateId, System.DateTime date)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string queryString = "insert into TicketEventDates([TicketEventID],[VenueId],[EventStartDateTime]) values(@TicketEventID,@VenueId, @EventStartDateTime)";
                connection.Open();
                connection.Query(queryString, new { TicketEventID = eventId, VenueId = dateId, EventStartDateTime = date });
                var addedTicketEventDateQuery = connection.Query<int>("SELECT IDENT_CURRENT ('TicketEventDates') AS Current_Identity").First();
                return connection.Query<TicketEventDate>("SELECT * FROM TicketEventDates WHERE TicketEventDateID=@Id", new { Id = addedTicketEventDateQuery }).First();
            }
        }
    }
}
