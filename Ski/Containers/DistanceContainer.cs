using Android.Locations;
using Ski.Helpers;

namespace Ski.Containers
{
    public class DistanceContainer
    {
        public Location InitialLocation { get; set; }
        public Location LastKnownLocation { get; set; }
        public double CurrentDistance { get; set; }

        public void Initialize(Location initialLocation)
        {
            InitialLocation = initialLocation;
        }

        public double GetCurrentDistance(Location currentLocation)
        {
            if (currentLocation.Speed != 0)
            {
                double lastLeg = 0;
                if (LastKnownLocation == null)
                {
                    lastLeg = DistanceHelper.CalculateDistance(InitialLocation, currentLocation);
                    LastKnownLocation = currentLocation;
                }
                else
                {
                    lastLeg = DistanceHelper.CalculateDistance(LastKnownLocation, currentLocation);
                }
                CurrentDistance = CurrentDistance + lastLeg;
            }

            return CurrentDistance;
        }
    }
}