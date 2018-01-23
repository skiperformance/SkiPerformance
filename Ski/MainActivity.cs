using Android.App;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V4.App;
using Android.Locations;
using Android.Content;

namespace Ski
{
    [Activity(Label = "Ski", MainLauncher = true)]
    public class MainActivity : FragmentActivity
    {
        //private TextView _txtSpeed;
        //private TextView _txtMaxSpeed;
        //private TextView _txtAvgSpeed;
        //private TextView _txtDistance;
        public static MainActivity Instance { get; set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            ViewPager viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
            FlashCardDeck flashCards = new FlashCardDeck();

            FlashCardDeckAdapter adapter =     new FlashCardDeckAdapter(SupportFragmentManager, flashCards);
            viewPager.Adapter = adapter;

            //Instance = this;
            //_txtSpeed = FindViewById<TextView>(Resource.Id.txtSpeed);
            //_txtMaxSpeed = FindViewById<TextView>(Resource.Id.txtMaxSpeed);
            //_txtAvgSpeed = FindViewById<TextView>(Resource.Id.txtAvgSpeed);
            //_txtDistance = FindViewById<TextView>(Resource.Id.txtDistance);


            LocationManager mlocManager = (LocationManager)GetSystemService(Context.LocationService);
            //var locationListener = new MyLocationListener();

            //Criteria locationCriteria = new Criteria();

            //locationCriteria.Accuracy = Accuracy.Fine;

            //string locationProvider = mlocManager.GetBestProvider(locationCriteria, true);
            //mlocManager.RequestLocationUpdates(locationProvider, 0, 0, locationListener);


        }

        public void UpdateUI(string speed, string maxSpeed, string avgSpeed, string distance)
        {
            //_txtSpeed.Text = string.Format("{0} km/h", speed);
            //_txtMaxSpeed.Text = string.Format("{0} km/h", maxSpeed);
            //_txtAvgSpeed.Text = string.Format("{0} km/h", avgSpeed);
            //_txtDistance.Text = string.Format("{0} meters", distance);
        }
    }
}

