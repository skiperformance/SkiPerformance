using Android.Support.V4.App;
using Ski.Fragments;

namespace Ski.Adapters
{
    public class ResultsTabAdapter : FragmentPagerAdapter
    {
        //private Fragment currentFragment;
        public DataFragment DataFragment { get; set; }
        public MapsFragment MapFragment { get; set; }
        public ChartFragment ChartFragment { get; set; }

        public ResultsTabAdapter(FragmentManager fragmentManager) : base(fragmentManager)
        {
            DataFragment = new DataFragment();
            MapFragment = new MapsFragment();
            ChartFragment = new ChartFragment();
        }

        public override int Count
        {
            get { return 3; }
        }

        public override Fragment GetItem(int position)
        {
            return new Fragment();
            //switch (position)
            //{
            //    case 0:
            //        return DataFragment;
            //    case 1:
            //        return MapFragment;
            //    case 2:
            //        return ChartFragment;
            //    default:
            //        return DataFragment;
            //}
          
        }

        public override Java.Lang.ICharSequence GetPageTitleFormatted(int position)
        {
            switch (position)
            {
                case 0:
                    return new Java.Lang.String("DATA");
                case 1:
                    return new Java.Lang.String("MAP");
                case 2:
                    return new Java.Lang.String("CHARTS");
                default:
                    return new Java.Lang.String("CHARTS");
            }

           
        }
    }
}