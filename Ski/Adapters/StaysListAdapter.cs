using System;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Ski.Adapters
{
    public class StaysListAdapter : RecyclerView.Adapter
    {

        Context context;

        public StaysListAdapter()
        {
            //this.context = context;
        }

        public override int ItemCount => throw new NotImplementedException();

        public override long GetItemId(int position)
        {
            return position;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
           
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
       
        public TextView Caption { get; private set; }

        public StaysListAdapterViewHolder(View itemView) : base(itemView)
        {          
           
            Caption = itemView.FindViewById<TextView>(Resource.Id.cityName);
        }
    }
}