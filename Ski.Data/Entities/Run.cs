using SQLite;
using System.Collections.Generic;

namespace Ski.Data.Entities
{
    public class Run
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Caption { get; set; }
        public double MaxSpeed { get; set; }
        public double AvgSpeed { get; set; }
        public string Speeds { get; set; }
    }
}