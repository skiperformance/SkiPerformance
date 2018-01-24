using Android.Gms.Maps;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;

namespace Ski.Fragments
{
    public class MapsFragment : Fragment, IOnMapReadyCallback
    {
        GoogleMap _map;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.maplayout, container, false);

            SupportMapFragment mapFrag = (SupportMapFragment)FragmentManager.FindFragmentById(Resource.Id.map);
            mapFrag.GetMapAsync(this);

            if (_map != null)
            {
                _map.MapType = GoogleMap.MapTypeSatellite;
            }

                return view;
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            _map = googleMap;
        }
    }
}