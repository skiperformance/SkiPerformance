using System;
using System.Collections.Generic;
using SQLite;

namespace Ski.Data.Entities
{
    [Table("Stay")]
    public class Stay : EntityBase
    {
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public bool IsCurrent { get; set; }
    }
}