﻿using Android.Locations;
using Ski.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace Ski.Containers
{
    public class SpeedContainer
    {
        public double MaxSpeed { get; set; }

        private double _currentSpeed { get; set; }

        public double AverageSpeed
        {
            get
            {
                return _speeds.Average();
            }
        }

        private List<double> _speeds = new List<double>();

        public double GetSpeed(Location loc)
        {
            
            //current speed
            _currentSpeed = SpeedConverter.ToKmH(loc.Speed);
            _speeds.Add(_currentSpeed);

            //Set max speed if needed
            if (_currentSpeed > MaxSpeed)
            {
                MaxSpeed = _currentSpeed;
            }

            return _currentSpeed;
        }
    }
}