using Android.Support.V4.App;
using Ski.Fragments;

namespace Ski
{
    class FlashCardDeckAdapter : FragmentPagerAdapter
    {
        public FlashCardDeck flashCardDeck;
        public FlashCardDeckAdapter(FragmentManager fm, FlashCardDeck flashCards)
            : base(fm)
        {
            flashCardDeck = flashCards;
        }

        public override int Count
        {
            get { return 3; }
        }

        public override Fragment GetItem(int position)
        {
            switch (position)
            {
                case 0:
                    return new DataFragment();
                case 1:
                    return new MapFragment();
                case 2:
                    return new ChartFragment();
                default:
                    return new DataFragment();
            }
          
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