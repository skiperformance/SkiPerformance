using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using System.Threading.Tasks;

namespace Ski.Fragments
{
    public class MapsFragment : Fragment, IOnMapReadyCallback
    {
        GoogleMap _map;
        SupportMapFragment _mapFragment;

        public MapsFragment() { }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.maplayout, container, false);
            //SupportMapFragment mapFrag = (SupportMapFragment)FragmentManager.FindFragmentById(Resource.Id.map);

            _mapFragment = (SupportMapFragment)FragmentManager.FindFragmentByTag("map");
            if (_mapFragment == null)
            {

                GoogleMapOptions mapOptions = new GoogleMapOptions()
                      .InvokeMapType(GoogleMap.MapTypeNormal)
                      .InvokeZoomControlsEnabled(true)
                      .InvokeCompassEnabled(true);

                FragmentTransaction fragTx = FragmentManager.BeginTransaction();
                 _mapFragment = SupportMapFragment.NewInstance(mapOptions);
                fragTx.Add(Resource.Id.map, _mapFragment, "map");

                fragTx.CommitAllowingStateLoss();
            }
            _mapFragment.GetMapAsync(this);

            return view;
        }

        //public override void OnActivityCreated(Bundle savedInstanceState)
        //{
        //    base.OnActivityCreated(savedInstanceState);
        //}

        public void OnMapReady(GoogleMap googleMap)
        {
            _map = googleMap;

            if (_map != null)
            {
                var latLng = new LatLng(47.433507, 12.378624);
                CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
                builder.Target(latLng);
                builder.Zoom(18);
                builder.Bearing(155);
                builder.Tilt(65);
                CameraPosition cameraPosition = builder.Build();
                CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);
                _map.MoveCamera(cameraUpdate);
                //MarkerOptions markerOpt1 = new MarkerOptions();
                //markerOpt1.SetPosition(new LatLng(47.433507, 12.378624));
                //markerOpt1.SetTitle("HahnenKamm");
                //_map.AddMarker(markerOpt1);
            }
        }
    }
}