using System;
using SQLite;

namespace Ski.Data.Entities
{
    [Table("Stay")]
    public class Stay
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Country { get; set; }
        public string City { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public bool IsCurrent { get; set; }
    }
}