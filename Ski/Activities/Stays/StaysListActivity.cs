
using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using Ski.Activities.Runs;
using Ski.Adapters;
using Ski.Constants;
using Ski.Data;
using Ski.Data.Entities;
using SQLite;
using static Android.Support.V7.Widget.RecyclerView;

namespace Ski.Activities.Stays
{
    [Activity(Label = "My Stays", MainLauncher = true)]
    public class StaysListActivity : Activity
    {
        DrawerLayout drawerLayout;
        NavigationView navigationView;
        private bool _isItemSelected;
        public int _currentItemPosition;
        StaysListAdapter _adapter;
        RecyclerView _recyclerView;
        LayoutManager _layoutManager;

        private TableQuery<Stay> _stays;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.stays);

            var toolbar = FindViewById<Android.Widget.Toolbar>(Resource.Id.toolbar_stays);
            SetActionBar(toolbar);
            ActionBar.SetHomeAsUpIndicator(Resource.Drawable.abc_ic_menu_overflow_material);
            ActionBar.Title = "My Stays";

            _recyclerView = FindViewById<RecyclerView>(Resource.Id.staysRecyclerView);

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);

            navigationView.NavigationItemSelected += (sender, e) =>
            {
                e.MenuItem.SetChecked(true);
                //react to click here and swap fragments or navigate
                drawerLayout.CloseDrawers();
            };

            // Plug in the linear layout manager:
            _layoutManager = new LinearLayoutManager(this);
            _recyclerView.SetLayoutManager(_layoutManager);

            _stays = DataEntryPoint.Instance.GetAllStays();

            // Plug in my adapter:
            _adapter = new StaysListAdapter(_stays);
            _adapter.ItemClick += OnItemClick;
            _adapter.ItemLongClick += OnItemLongClick;
            _recyclerView.SetAdapter(_adapter);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_stays_list, menu);
            if (menu != null)
            {
                menu.FindItem(Resource.Id.menu_add).SetVisible(!_isItemSelected);
                menu.FindItem(Resource.Id.menu_delete).SetVisible(_isItemSelected);
            }
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {  // Handle item selection
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
                    return true;

                case Resource.Id.menu_add:
                    StartActivity(typeof(EditStayActivity));
                    return true;
                case Resource.Id.menu_delete:
                    DataEntryPoint.Instance.DeleteStay(_currentItemPosition);
                    //PopupMenu menu = new PopupMenu(this, showPopupMenu);
                    //StartActivity(typeof(EditStayActivity));

                    Recreate();
                    return true;
            }

            return false;

        }

        private void OnItemClick(object sender, int position)
        {
            var currentStay = _stays.ElementAt(position);
            if (currentStay != null)
            {
                var intent = new Intent(this, typeof(RunsListActivity));
                intent.PutExtra(IntentConstants.StayId, currentStay.Id);
                intent.PutExtra(IntentConstants.StayLabel, currentStay.City);
                StartActivity(intent);

                //StartActivity(typeof(RunsListActivity));
            }
        }

        private void OnItemLongClick(object sender, int e)
        {
            _isItemSelected = true;
            _currentItemPosition = e + 1;
            InvalidateOptionsMenu();
        }
    }
}