using System.Collections.Generic;
using ClassLibrary;

namespace TicketSystem.DatabaseRepository
{
    public interface ITicketDatabase
    {
        /// <summary>
        /// Add a new Event to the database
        /// </summary>
        /// <param name="name">Name of the event</param>
        /// <param name="description">A desription of the event, html markup of the event is allowed</param>
        /// <returns>An object representing the newly created TicketEvent</returns>
        TicketEvent EventsAdd(TicketEvent ticketEvent);

        /// <summary>
        /// Add a new venue to the database
        /// </summary>
        /// <param name="name">Name of the venue</param>
        /// <param name="address">Physical address of the venue</param>
        /// <param name="city">City part of the adress</param>
        /// <param name="country">Country part of the adress</param>
        /// <returns>An object representing the newly created Venue</returns>
        Venue VenuesAdd(Venue venue);


        /// <summary>
        /// Find all venus matching the query
        /// </summary>
        /// <param name="id">A text which is user i looking for in the venues</param>
        /// <returns>A list of venus matching the query</returns>
        Venue GetVenues(int id);
    }
}
