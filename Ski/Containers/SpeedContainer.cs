using Android.Locations;
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
                if (_speeds.Count>0)
                {
                    return _speeds.Average();
                }
                return 0;
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

        public List<double> GetSpeeds()
        {
            return _speeds;
        }
    }
}