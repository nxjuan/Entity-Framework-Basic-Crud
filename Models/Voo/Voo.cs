using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudDoYT.Models.Voo
{
    public class Voo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; } = Guid.NewGuid();

        public string? Company { get; set; }
        public string? Seat { get; set; }
        public string? DepartureTime { get; set; }
        public string? ArrivalTime { get; set; }
        public string? Origin { get; set; }
        public string? Destination { get; set; }
        public string? Duration { get; set; }
        public string? Price { get; set; }
        public string? FlightType { get; set; }
        public string? date { get; set; }

    }
}