
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Ski.Activities.Stays;
using Ski.Adapters;
using Ski.Data;
using static Android.Support.V7.Widget.RecyclerView;

namespace Ski.Activities.Runs
{
    [Activity(Label = "My Runs", MainLauncher = false)]
    public class RunsListActivity : Activity
    {
       RunsListAdapter _adapter;
        RecyclerView _recyclerView;
        LayoutManager _layoutManager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.runs);

            var toolbar = FindViewById<Android.Widget.Toolbar>(Resource.Id.toolbar_runs);
            SetActionBar(toolbar);
            ActionBar.Title = "My Runs";

            _recyclerView = FindViewById<RecyclerView>(Resource.Id.runsRecyclerView);

            // Plug in the linear layout manager:
            _layoutManager = new LinearLayoutManager(this);
            _recyclerView.SetLayoutManager(_layoutManager);

            var runs = DataEntryPoint.Instance.GetAllRuns();           

            // Plug in my adapter:
            _adapter = new RunsListAdapter(runs);
            _adapter.ItemClick += OnItemClick;
            _recyclerView.SetAdapter(_adapter);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_stays_list, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            StartActivity(typeof(LaunchRunActivity));

            return true;
        }

        void OnItemClick(object sender, int position)
        {
            //StartActivity(typeof(LaunchRunActivity));
        }
    }
}