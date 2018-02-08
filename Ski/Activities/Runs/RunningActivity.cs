
using Android.App;
using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Widget;
using Ski.Constants;
using Ski.EntryPoints;

namespace Ski.Activities.Runs
{
    [Activity(Label = "RunningActivity")]
    public class RunningActivity : Activity
    {
        private int _stayId;
        Chronometer _chronometer;
        Button _btnStop;
        //ComputeRunEntryPoint _entryPoint;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.running);

            _stayId = Intent.GetIntExtra(IntentConstants.StayId, -1);
            _chronometer = FindViewById<Chronometer>(Resource.Id.chronometer);
            _btnStop = FindViewById<Button>(Resource.Id.btnStop);
            _btnStop.Click += OnStopClick;
            _chronometer.Start();

            //_entryPoint = new ComputeRunEntryPoint((LocationManager)GetSystemService("location"));
            ComputeRunEntryPoint.Instance.Initialize((LocationManager)GetSystemService("location"), _stayId);
            ComputeRunEntryPoint.Instance.Start();
        }

        private void OnStopClick(object sender, System.EventArgs e)
        {
            _chronometer.Stop();
            ComputeRunEntryPoint.Instance.Stop();

            StartActivity(typeof(RunResultsActivity));
        }
    }
}