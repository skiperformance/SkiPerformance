using System;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Ski.Data.Entities;
using SQLite;

namespace Ski.Adapters
{
    public class StaysListAdapter : RecyclerView.Adapter
    {

        TableQuery<Stay> _stays;


        public StaysListAdapter(TableQuery<Stay> stays)
        {
            _stays = stays;
        }

        public override int ItemCount
        {
            get
            {
                var count = _stays.Count();
                return count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            StaysListAdapterViewHolder vh = holder as StaysListAdapterViewHolder;

            var item = _stays.ElementAt(position);
            vh.City.Text = item.City;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            // Inflate the CardView for the photo:
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.staysCardView, parent, false);

            // Create a ViewHolder to hold view references inside the CardView:
            StaysListAdapterViewHolder vh = new StaysListAdapterViewHolder(itemView);
            return vh;
        }
    }

    public class StaysListAdapterViewHolder : RecyclerView.ViewHolder
    {
        public TextView City { get; private set; }

        public StaysListAdapterViewHolder(View itemView) : base(itemView)
        {

            City = itemView.FindViewById<TextView>(Resource.Id.cityName);
        }
    }
}