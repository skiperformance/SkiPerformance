using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Ski.Adapters;

namespace Ski
{
    [Activity(Label = "StaysListActivity", MainLauncher = true)]
    public class StaysListActivity : Activity
    {
        RecyclerView _recyclerView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.stays);

            var adapter = new StaysListAdapter();
            _recyclerView = FindViewById<RecyclerView>(Resource.Id.staysRecyclerView);
        }
    }
}