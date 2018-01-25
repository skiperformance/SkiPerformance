using System;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Ski.Containers;

namespace Ski
{
    public class LocationListener : Java.Lang.Object, ILocationListener
    {
        private DistanceContainer _distanceContainer;
        private SpeedContainer _speedContainer;

        public event EventHandler LocationChanged;

        public void OnLocationChanged(Location location)
        {
            if (LocationChanged != null)
            {
                LocationChanged(location, null);
            }          
        }

        public void OnProviderDisabled(string provider)
        {

        }

        public void OnProviderEnabled(string provider)
        {

        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {

        }
    }
}