using Android.OS;
using Android.Views;
using Microcharts;
using Microcharts.Droid;
using SkiaSharp;

namespace Ski.Fragments
{
    public class ChartFragment : Android.Support.V4.App.Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.chartlayout, container, false);

            var entries = new[]
                        {
                            new Entry(200)
                            {                               
                                Label = "January",
                                //ValueLabel = "200",
                                Color = SKColor.Parse("#266489")
                            },
                            new Entry(400)
                            {
                            Label = "February",
                            //ValueLabel = "400",
                            Color = SKColor.Parse("#68B9C0")
                            },
                            new Entry(-100)
                            {
                            Label = "March",
                            //ValueLabel = "-100",
                            Color = SKColor.Parse("#90D585")
                            }};

            var chart = new LineChart() { Entries = entries };
            //chart.BackgroundColor = SKColor.Parse("#000000");
            
            var chartView = view.FindViewById<ChartView>(Resource.Id.chartView);
            chartView.Chart = chart;

            return view;
        }
    }
}