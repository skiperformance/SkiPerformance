
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Ski.Activities.Runs;
using Ski.Adapters;
using Ski.Data;
using static Android.Support.V7.Widget.RecyclerView;

namespace Ski.Activities.Stays
{
    [Activity(Label = "My Stays", MainLauncher = false)]
    public class StaysListActivity : Activity
    {
        StaysListAdapter _adapter;
        RecyclerView _recyclerView;
        LayoutManager _layoutManager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.stays);

            var toolbar = FindViewById<Android.Widget.Toolbar>(Resource.Id.toolbar_stays);
            SetActionBar(toolbar);
            ActionBar.Title = "My Stays";

            _recyclerView = FindViewById<RecyclerView>(Resource.Id.staysRecyclerView);

            // Plug in the linear layout manager:
            _layoutManager = new LinearLayoutManager(this);
            _recyclerView.SetLayoutManager(_layoutManager);

            var stays = DataEntryPoint.Instance.GetAllStays();           

            // Plug in my adapter:
            _adapter = new StaysListAdapter(stays);
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
            StartActivity(typeof(EditStayActivity));

            return true;
        }

        void OnItemClick(object sender, int position)
        {
            StartActivity(typeof(RunsListActivity));
        }
    }
}