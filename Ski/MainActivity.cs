using Android.App;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V4.App;
using Ski.Containers;
using Android.Locations;

namespace Ski
{
    [Activity(Label = "Ski", MainLauncher = true)]
    public class MainActivity : FragmentActivity
    {
    
        LocationListener _locationlistener;

        FlashCardDeckAdapter _adapter;


        protected override void OnCreate(Bundle bundle)
        {
            //Create view
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            //Init Location management
            _locationlistener = new LocationListener();
            _locationlistener.LocationChanged += OnLocationChanged;   

            LocationManager locationManager = (LocationManager)GetSystemService("location");
            Criteria locationCriteria = new Criteria();
            locationCriteria.Accuracy = Accuracy.Fine;

            string locationProvider = locationManager.GetBestProvider(locationCriteria, true);
            locationManager.RequestLocationUpdates(locationProvider, 0, 0, _locationlistener);

            //Init Pager
            var pager = FindViewById<ViewPager>(Resource.Id.viewpager);

            _adapter = new FlashCardDeckAdapter(SupportFragmentManager);
            pager.Adapter = _adapter;
        }

        private void OnLocationChanged(object sender, System.EventArgs e)
        {
            var location = sender as Location;
            if (location != null)
            {
                if (location.Speed != 0)
                {
                    //Data
                    var dataFragment = _adapter.DataFragment;
                    dataFragment.Update(location);
                }
            }
        }
    }
}

