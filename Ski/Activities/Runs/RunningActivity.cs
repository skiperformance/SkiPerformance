
using Android.App;
using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Widget;
using Ski.EntryPoints;

namespace Ski.Activities.Runs
{
    [Activity(Label = "RunningActivity")]
    public class RunningActivity : Activity
    {
        Chronometer _chronometer;
        Button _btnStop;
        //ComputeRunEntryPoint _entryPoint;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.running);

            _chronometer = FindViewById<Chronometer>(Resource.Id.chronometer);
            _btnStop = FindViewById<Button>(Resource.Id.btnStop);
            _btnStop.Click += OnStopClick;
            _chronometer.Start();

            //_entryPoint = new ComputeRunEntryPoint((LocationManager)GetSystemService("location"));
            ComputeRunEntryPoint.Instance.Initialize((LocationManager)GetSystemService("location"));
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