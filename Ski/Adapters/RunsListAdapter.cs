using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Ski.Data.Entities;
using SQLite;

namespace Ski.Adapters
{
    public class RunsListAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        TableQuery<Run> _runs;


        public RunsListAdapter(TableQuery<Run> runs)
        {
            _runs = runs;
        }

        public override int ItemCount
        {
            get
            {
                //return 0;
                var count = _runs.Count();
                return count;
            }
        }

        public void OnClick(int position)
        {
            if (ItemClick != null)
                ItemClick(this, position);
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
           RunsListAdapterViewHolder vh = holder as RunsListAdapterViewHolder;

            var item = _runs.ElementAt(position);
            vh.Caption.Text = item.Caption;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            // Inflate the CardView for the photo:
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.runsCardView, parent, false);

            // Create a ViewHolder to hold view references inside the CardView:
            RunsListAdapterViewHolder vh = new RunsListAdapterViewHolder(itemView, OnClick);
            return vh;
        }
    }

    public class RunsListAdapterViewHolder : RecyclerView.ViewHolder
    {
        public TextView Caption { get; private set; }

        public RunsListAdapterViewHolder(View itemView, Action<int> listener) : base(itemView)
        {
            Caption = itemView.FindViewById<TextView>(Resource.Id.caption);
            itemView.Click += (sender, e) => listener(base.LayoutPosition);
        }
    }
}