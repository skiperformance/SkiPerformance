﻿namespace Ski.Data.Entities
{
    public class Run : EntityBase
    {
        public int StayId { get; set; }

        public string Caption { get; set; }
        public double MaxSpeed { get; set; }
        public double AvgSpeed { get; set; }
        public string Speeds { get; set; }
    }
}