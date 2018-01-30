using Android.App;
using Android.OS;
using Android.Locations;
using Ski.Adapters;
using Android.Support.Design.Widget;
using Ski.Fragments;
using Android.Support.V7.App;

namespace Ski.Activities.Runs
{
    [Activity(Label = "RunResultsActivity", MainLauncher = true)]
    public class RunResultsActivity : Activity
    {
        BottomNavigationView bottomNavigation;
        //LocationListener _locationlistener;

        ResultsTabAdapter _adapter;


        protected override void OnCreate(Bundle bundle)
        {
            //Create view
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.RunResultsLayout);

            bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);

            bottomNavigation.NavigationItemSelected += BottomNavigation_NavigationItemSelected;

            // Load the first fragment on creation
            LoadFragment(Resource.Id.menu_home);

            //Init Location management

            /* TODO : Uncomment*/
            //_locationlistener = new LocationListener();
            //_locationlistener.LocationChanged += OnLocationChanged;   

            //LocationManager locationManager = (LocationManager)GetSystemService("location");
            //Criteria locationCriteria = new Criteria();
            //locationCriteria.Accuracy = Accuracy.Fine;

            //string locationProvider = locationManager.GetBestProvider(locationCriteria, true);
            //locationManager.RequestLocationUpdates(locationProvider, 0, 0, _locationlistener);

            //Init Pager
            //var pager = FindViewById<ViewPager>(Resource.Id.viewpager);

            //_adapter = new ResultsTabAdapter(SupportFragmentManager);
            //pager.Adapter = _adapter;
        }

        private void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            LoadFragment(e.Item.ItemId);
        }

        void LoadFragment(int id)
        {
           Fragment fragment = null;
            switch (id)
            {
                case Resource.Id.menu_home:
                    fragment = new DataFragment();
                    break;
                case Resource.Id.menu_audio:
                    fragment = new MapsFragment();
                    break;
                case Resource.Id.menu_video:
                    fragment = new ChartFragment();
                    break;
            }

            if (fragment == null)
                return;

          FragmentManager.BeginTransaction()
                .Replace(Resource.Id.content_frame, fragment)
                .Commit();
        }

    }
}

