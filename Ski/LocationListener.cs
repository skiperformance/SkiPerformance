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

            //if (location.Speed != 0)
            //{
            //    //Current Speed
            //    var speed = _speedContainer.GetSpeed(location);

            //    //Distance
            //    _distanceContainer.Initialize(location);

            //    double distance;
            //    distance = _distanceContainer.GetCurrentDistance(location);

            //    //        _dataFragment.UpdateUI(speed.ToString("N2"), _speedContainer.MaxSpeed.ToString("N2"), _speedContainer.AverageSpeed.ToString("N2"), distance.ToString("N2"));
            //}
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