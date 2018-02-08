
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Ski.Constants;

namespace Ski.Activities.Runs
{
    [Activity(Label = "LaunchRunActivity")]
    public class LaunchRunActivity : Activity
    {
        private int _stayId;
        Button _btnGo;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            _stayId = Intent.GetIntExtra(IntentConstants.StayId, -1);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.launchRun);

            _btnGo = FindViewById<Button>(Resource.Id.btnGo);
            _btnGo.Click += OnGoClick;
        }

        private void OnGoClick(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(RunningActivity));
            intent.PutExtra(IntentConstants.StayId, _stayId);
            StartActivity(intent);
        }
    }
}