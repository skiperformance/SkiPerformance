using Android.Locations;
using Android.OS;
using Android.Runtime;
using Ski.Containers;
using Ski.Fragments;

namespace Ski
{
    public class MyLocationListener : Java.Lang.Object, ILocationListener
    {       
        private DistanceContainer _distanceContainer;
        private SpeedContainer _speedContainer;
        public void Dispose()
        {

        }

        public MyLocationListener()
        {
            _distanceContainer = new DistanceContainer();
            _speedContainer = new SpeedContainer();

        }

        public void OnLocationChanged(Location loc)
        {
            if (loc.Speed != 0)
            {
                //Current Speed
                var speed = _speedContainer.GetSpeed(loc);

                //Distance
                _distanceContainer.Initialize(loc);

                double distance;
                distance = _distanceContainer.GetCurrentDistance(loc);

                DataFragment.Instance.UpdateUI(speed.ToString("N2"), _speedContainer.MaxSpeed.ToString("N2"), _speedContainer.AverageSpeed.ToString("N2"), distance.ToString("N2"));
            }
        }


        public void OnProviderDisabled(string provider)
        {

        }


        public void OnProviderEnabled(string provider)
        {

        }


        public void OnStatusChanged(string provider, int status, Bundle extras)
        {

        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {

        }
    }
}