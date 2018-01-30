using Android.Locations;
using Newtonsoft.Json;
using Ski.Containers;
using Ski.Data;
using Ski.Data.Entities;
using System;
using System.Collections.Generic;

namespace Ski.EntryPoints
{
    public class ComputeRunEntryPoint
    {
        private static volatile ComputeRunEntryPoint instance;
        private static object syncRoot = new Object();
        public static ComputeRunEntryPoint Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ComputeRunEntryPoint();
                    }
                }

                return instance;
            }
        }

        LocationManager _locationManager;
        LocationListener _locationlistener;

        private DistanceContainer _distanceContainer = new DistanceContainer();
        private SpeedContainer _speedContainer = new SpeedContainer();

        public void Initialize(LocationManager locationManager)
        {
            _locationManager = locationManager;
        }

        //public ComputeRunEntryPoint(LocationManager locationManager)
        //{
        //    _locationManager = locationManager;
        //}

        public void Start()
        {
            _locationlistener = new LocationListener();
            _locationlistener.LocationChanged += OnLocationChanged;

            //LocationManager locationManager = (LocationManager) GetSystemService("location");
            Criteria locationCriteria = new Criteria();
            locationCriteria.Accuracy = Accuracy.Fine;

            string locationProvider = _locationManager.GetBestProvider(locationCriteria, true);
            _locationManager.RequestLocationUpdates(locationProvider, 0, 0, _locationlistener);
        }

        public void Stop()
        {
            //Save speeds
            var run = new Run
            {
                Caption = "My Run",
                AvgSpeed = _speedContainer.AverageSpeed,
                MaxSpeed = _speedContainer.MaxSpeed,
                Speeds = JsonConvert.SerializeObject(_speedContainer.GetSpeeds())
            };

            DataEntryPoint.Instance.InsertRun(run);
        }

        private void OnLocationChanged(object sender, EventArgs e)
        {
            var location = sender as Location;
            if (location != null)
            {
                if (location.Speed != 0)
                {
                    //Current Speed
                    var speed = _speedContainer.GetSpeed(location);

                    //Distance
                    _distanceContainer.Initialize(location);
                    double distance;
                    distance = _distanceContainer.GetCurrentDistance(location);

                }
            }
        }

        public double GetAverageSpeed()
        {
            return _speedContainer.AverageSpeed;
        }

        public double GetMaxSpeed()
        {
            return _speedContainer.MaxSpeed;
        }

        public List<double> GetSpeeds()
        {
            return _speedContainer.GetSpeeds();
        }
    }
}