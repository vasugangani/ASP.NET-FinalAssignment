using System.ComponentModel.DataAnnotations;

namespace MakeMyTripTravelPlan.Models
{
    public class AirlineService
    {
        [Required]

        public int AirlineSeriveId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]

        public string Description { get; set; }
        [Required]

        public string Avaialable { get; set; }

        //Child reference
        public List<Flight>? Flights { get; set; }
    }
}
