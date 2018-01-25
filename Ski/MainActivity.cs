
using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;
using Ski.Controls;
using Ski.Data;
using Ski.Data.Entities;

namespace Ski
{
    [Activity(Label = "MainActivity", MainLauncher = false)]
    public class MainActivity : Activity
    {
        Spinner _placeSpinner;
        Spinner _countrySpinner;
        Button _departureButton;
        Button _arrivalButton;
        Button _nextButton;
        private List<KeyValuePair<string, string>> _places;
        private List<KeyValuePair<string, string>> _countries;

        DateTime _arrival;
        DateTime _departure;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            InitControls();
        }

        private void InitControls()
        {
            //Countries
            _countrySpinner = FindViewById<Spinner>(Resource.Id.countrySpinner);
            _countries = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Austria", "Austria"),
                    new KeyValuePair<string, string>("Venus", "464 degrees C"),
                    new KeyValuePair<string, string>("Earth", "15 degrees C"),
                    new KeyValuePair<string, string>("Mars", "-65 degrees C"),
                    new KeyValuePair<string, string>("Jupiter" , "-110 degrees C"),
                    new KeyValuePair<string, string>("Saturn", "-140 degrees C"),
                    new KeyValuePair<string, string>("Uranus", "-195 degrees C"),
                    new KeyValuePair<string, string>("Neptune", "-200 degrees C")
                };


            List<string> _countriesNames = new List<string>();
            foreach (var item in _countries)
                _countriesNames.Add(item.Key);

            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, _countriesNames);
            _countrySpinner.Adapter = adapter;


            //Places
            _placeSpinner = FindViewById<Spinner>(Resource.Id.placeSpinner);
            _places = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Kitzbühel", "A1"),
                    new KeyValuePair<string, string>("Venus", "464 degrees C"),
                    new KeyValuePair<string, string>("Earth", "15 degrees C"),
                    new KeyValuePair<string, string>("Mars", "-65 degrees C"),
                    new KeyValuePair<string, string>("Jupiter" , "-110 degrees C"),
                    new KeyValuePair<string, string>("Saturn", "-140 degrees C"),
                    new KeyValuePair<string, string>("Uranus", "-195 degrees C"),
                    new KeyValuePair<string, string>("Neptune", "-200 degrees C")
                };


            List<string> _placesNames = new List<string>();
            foreach (var item in _places)
                _placesNames.Add(item.Key);

            adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, _placesNames);
            _placeSpinner.Adapter = adapter;

            //Dates
            _departureButton = FindViewById<Button>(Resource.Id.btnDepartureDate);
            _arrivalButton = FindViewById<Button>(Resource.Id.btnArrivalDate);
            _departureButton.Click += _departureButton_Click;
            _arrivalButton.Click += _arrivalButton_Click;

            //Next Button
            _nextButton = FindViewById<Button>(Resource.Id.btnSavePlace);
            _nextButton.Click += OnNextButtonClick;
        }

        private void _arrivalButton_Click(object sender, EventArgs e)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                _arrival = time;
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }

        private void _departureButton_Click(object sender, EventArgs e)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                _departure = time;
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }

        private void OnNextButtonClick(object sender, EventArgs e)
        {
            var stay = new Stay
            {
                Country = _countrySpinner.SelectedItem.ToString(),
                City = _placeSpinner.SelectedItem.ToString(),
                Arrival = _arrival,
                Departure = _departure,
                IsCurrent = true
            };
            DataEntryPoint.Instance.InsertStay(stay);
        }
    }
}