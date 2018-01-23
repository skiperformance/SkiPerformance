using Android.OS;
using Android.Views;

namespace Ski.Fragments
{
    public class ChartFragment : Android.Support.V4.App.Fragment
    {      
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.chartlayout, container, false);
        }
    }
}