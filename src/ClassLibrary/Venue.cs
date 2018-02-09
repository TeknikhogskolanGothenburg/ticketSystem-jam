using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClassLibrary
{

    public class Venue
    {
        public int VenueId { get; set; }

        [Required]
        public string VenueName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Seats { get; set; }
    }
}
