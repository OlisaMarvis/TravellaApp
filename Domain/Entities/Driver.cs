using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Driver
    {
        public Guid DriverId { get; set; }
        public string? DriverName { get; set; }
        public string? Description { get; set; }
        public string? CarDesecription { get; set; }
        public string? DriverReview { get; set; }
        public string? DriverLocation { get; set; }
    }
}
