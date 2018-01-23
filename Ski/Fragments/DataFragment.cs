using Android.Locations;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace Ski.Fragments
{
    public class DataFragment : Android.Support.V4.App.Fragment
    {
        private TextView _txtSpeed;
        private TextView _txtMaxSpeed;
        private TextView _txtAvgSpeed;
        private TextView _txtDistance;
        public static DataFragment Instance { get; set; }
        public DataFragment() { }

        //public static DataFragment newInstance()
        //{
        //    DataFragment fragment = new DataFragment();

        //    //Bundle args = new Bundle();
        //    //args.PutString(FLASH_CARD_QUESTION, question);
        //    //args.PutString(FLASH_CARD_ANSWER, answer);
        //    //fragment.Arguments = args;

        //    return fragment;
        //}

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.datalayout, container, false);

            Instance = this;
            _txtSpeed = view.FindViewById<TextView>(Resource.Id.txtSpeed);
            _txtMaxSpeed = view.FindViewById<TextView>(Resource.Id.txtMaxSpeed);
            _txtAvgSpeed = view.FindViewById<TextView>(Resource.Id.txtAvgSpeed);
            _txtDistance = view.FindViewById<TextView>(Resource.Id.txtDistance);


            LocationManager mlocManager = (LocationManager)Activity.GetSystemService("location");
            var locationListener = new MyLocationListener();

            Criteria locationCriteria = new Criteria();

            locationCriteria.Accuracy = Accuracy.Fine;

            string locationProvider = mlocManager.GetBestProvider(locationCriteria, true);
            mlocManager.RequestLocationUpdates(locationProvider, 0, 0, locationListener);

            return view;

        }

        public void UpdateUI(string speed, string maxSpeed, string avgSpeed, string distance)
        {
            _txtSpeed.Text = string.Format("{0} km/h", speed);
            _txtMaxSpeed.Text = string.Format("{0} km/h", maxSpeed);
            _txtAvgSpeed.Text = string.Format("{0} km/h", avgSpeed);
            _txtDistance.Text = string.Format("{0} meters", distance);
        }

        //public override View OnCreateView(
        //    LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        //{

        //    //string question = Arguments.GetString(FLASH_CARD_QUESTION, "");
        //    //string answer = Arguments.GetString(FLASH_CARD_ANSWER, "");

        //    //View view = inflater.Inflate(Resource.Layout.datalayout, container, false);
        //    //TextView questionBox = (TextView)view.FindViewById(Resource.Id.flash_card_question);
        //    //questionBox.Text = question;

        //    return view;
        //}
    }
}