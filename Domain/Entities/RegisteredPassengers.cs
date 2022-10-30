using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RegisteredPassengers
    {
        public int Id { get; set; }
        public int NumberOfPassengers { get; set; }
        public string Description { get; set; }
    }
}
