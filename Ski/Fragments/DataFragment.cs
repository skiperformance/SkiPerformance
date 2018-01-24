
using Android.Locations;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Ski.Containers;

namespace Ski.Fragments
{
    public class DataFragment : Fragment
    {
        private DistanceContainer _distanceContainer = new DistanceContainer();
        private SpeedContainer _speedContainer = new SpeedContainer();

        private TextView _txtSpeed;
        private TextView _txtMaxSpeed;
        private TextView _txtAvgSpeed;
        private TextView _txtDistance;

        public DataFragment() { }       

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.datalayout, container, false);
           
            _txtSpeed = view.FindViewById<TextView>(Resource.Id.txtSpeed);
            _txtMaxSpeed = view.FindViewById<TextView>(Resource.Id.txtMaxSpeed);
            _txtAvgSpeed = view.FindViewById<TextView>(Resource.Id.txtAvgSpeed);
            _txtDistance = view.FindViewById<TextView>(Resource.Id.txtDistance);
            
            return view;

        }

        public void Update(Location location)
        {
            //Current Speed
            var speed = _speedContainer.GetSpeed(location);

            //Distance
            _distanceContainer.Initialize(location);
            double distance;
            distance = _distanceContainer.GetCurrentDistance(location);


            UpdateUI(speed.ToString("N2"), _speedContainer.MaxSpeed.ToString("N2"), _speedContainer.AverageSpeed.ToString("N2"), distance.ToString("N2"));
        }


        private void UpdateUI(string speed, string maxSpeed, string avgSpeed, string distance)
        {
            _txtSpeed.Text = string.Format("{0} km/h", speed);
            _txtMaxSpeed.Text = string.Format("{0} km/h", maxSpeed);
            _txtAvgSpeed.Text = string.Format("{0} km/h", avgSpeed);
            _txtDistance.Text = string.Format("{0} meters", distance);
        }      
    }
}