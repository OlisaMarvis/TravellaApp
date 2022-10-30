using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Trip
    {
        public Guid TripId { get; set; }
        public string? Destination { get; set; } 
        public string? Source { get; set; } 
        public string? TripDescription { get; set; }
        public List<RegisteredPassengers>? registeredPassengers { get; set; }
        public double TripDuration { get; set; }
        public string? TripSummary { get; set; }
    }
}
