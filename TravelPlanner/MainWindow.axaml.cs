using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Collections.ObjectModel;

namespace TravelPlanner
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CitiesListBox.ItemsSource = _cities;
        }
        
        private ObservableCollection<string> _cities = new();

        private void CountryComboBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            var country = (CountryComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            string imagePath = country switch
            {
                "Francja" => "Assets/france.jpg",
                "Wlochy" => "Assets/italy.jpg",
                "Japonia" => "Assets/japan.jpg",
                _ => null
            };

            if (File.Exists(imagePath))
            {
                CountryImage.Source = new Bitmap(imagePath);
            }
        }

        private void AddCity_Click(object? sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CityInput.Text))
            {
                _cities.Add(CityInput.Text.Trim());
                CityInput.Text = string.Empty;
            }
        }
        
        private void ShowSummary_Click(object? sender, RoutedEventArgs e)
        {
            var data = new TravelData
            {
                UserName = NameTextBox.Text,
                Country = (CountryComboBox.SelectedItem as ComboBoxItem)?.Content.ToString(),
                Attractions = new List<string>(),
                Transport = PlaneRadio.IsChecked == true ? "Samolot" :
                            TrainRadio.IsChecked == true ? "Pociag" : "Samochod",
                Cities = _cities.ToList()

            };

            if (MuseumsCheckBox.IsChecked == true)
                data.Attractions.Add("Muzea");
            if (RestaurantsCheckBox.IsChecked == true)
                data.Attractions.Add("Restauracje");
            if(MonumentCheckBox.IsChecked == true)
                data.Attractions.Add("Zabytki");

            var summary = new SummaryWindow(data);
            summary.ShowDialog(this);
        }
    }
}
