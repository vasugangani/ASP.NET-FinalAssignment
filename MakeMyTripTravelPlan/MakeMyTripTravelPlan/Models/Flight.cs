using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MakeMyTripTravelPlan.Models
{
    public class Flight
    {
        [Required]


        public string FlightDeatil { get; set; }
        [Required]

        public string Name { get; set; }

        [Required]

        public DateTime Date { get; set; }
        [Required]

        public string Description { get; set; }

        public string AirlineServiceId { get; set; }

        // Parent Reference - connection to 1 airline
        public AirlineService? AirlineService { get; set; }

    }
}
