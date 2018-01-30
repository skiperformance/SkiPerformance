
using Android.App;
using Android.OS;
using Android.Widget;

namespace Ski.Activities.Runs
{
    [Activity(Label = "LaunchRunActivity")]
    public class LaunchRunActivity : Activity
    {
        Button _btnGo;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.launchRun);

            _btnGo = FindViewById<Button>(Resource.Id.btnGo);
            _btnGo.Click += OnGoClick;
        }

        private void OnGoClick(object sender, System.EventArgs e)
        {
            StartActivity(typeof(RunningActivity));
        }
    }
}