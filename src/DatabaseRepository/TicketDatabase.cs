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
        public IEnumerable<string> GetAllEvents()
        {
            string connectionString = "Server=(local)\\SqlExpress; Database=TicketSystem; Trusted_connection=true";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<string>("SELECT EventName FROM TicketEvents").ToList();
            }
        }
        
        public List<TicketEvent> GetEvents(string query)
        {
            string connectionString = "Server=(local)\\SqlExpress; Database=TicketSystem; Trusted_connection=true";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<TicketEvent>("SELECT * FROM TicketEvents WHERE EventName like '%" + query + "%' OR EventHtmlDescription like '%" + query +  "%'").ToList();
            }
        }

        public TicketEvent EventAdd(string name, string description)
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;
            string connectionString = "Server=(local)\\SqlExpress; Database=TicketSystem; Trusted_connection=true";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query("insert into TicketEvents(EventName, EventHtmlDescription) values(@Name, @Description)", new { Name = name, Description = description });
                var addedEventQuery = connection.Query<int>("SELECT IDENT_CURRENT ('TicketEvents') AS Current_Identity").First();
                return connection.Query<TicketEvent>("SELECT * FROM TicketEvents WHERE TicketEventID=@Id", new { Id = addedEventQuery }).First();
            }
        }

        public Venue VenueAdd(string name, string address, string city, string country)
        {
            string connectionString = "Server=(local)\\SqlExpress; Database=TicketSystem; Trusted_connection=true";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query("insert into Venues([VenueName],[Address],[City],[Country]) values(@Name,@Address, @City, @Country)", new { Name = name, Address= address, City = city, Country = country });
                var addedVenueQuery = connection.Query<int>("SELECT IDENT_CURRENT ('Venues') AS Current_Identity").First();
                return connection.Query<Venue>("SELECT * FROM Venues WHERE VenueID=@Id", new { Id = addedVenueQuery }).First();
            }
        }
        public TicketEventDate EventDateAdd(int eventId, int dateId, System.DateTime date)
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;
            string connectionString = "Server=(local)\\SqlExpress; Database=TicketSystem; Trusted_connection=true";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query("insert into TicketEventDates([TicketEventID],[VenueId],[EventStartDateTime]) values(@TicketEventID,@VenueId, @EventStartDateTime)", new { TicketEventID = eventId, VenueId = dateId, EventStartDateTime = date});
                var addedTicketEventDateQuery = connection.Query<int>("SELECT IDENT_CURRENT ('TicketEventDates') AS Current_Identity").First();
                return connection.Query<TicketEventDate>("SELECT * FROM TicketEventDates WHERE TicketEventDateID=@Id", new { Id = addedTicketEventDateQuery }).First();
            }
        }

        public Venue VenuesFind(string query)
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;
            string connectionString = "Server=(local)\\SqlExpress; Database=TicketSystem; Trusted_connection=true";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<Venue>("SELECT * FROM Venues WHERE VenueName like '%"+query+"%'").First();
            }
        }

        public List<Venue> VenuesFindAll()
        {
            var connectionString = "Server=(local)\\SqlExpress; Database=TicketSystem; Trusted_connection=true";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<Venue>("SELECT * FROM Venues").ToList();
            }
        }
    }
}
