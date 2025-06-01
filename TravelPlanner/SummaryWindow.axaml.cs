using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TravelPlanner
{
    public partial class SummaryWindow : Window
    {
        public SummaryWindow(TravelData data)
        {
            InitializeComponent();
            BuildSummary(data);
        }

        private void InitializeComponent() => AvaloniaXamlLoader.Load(this);

        private void BuildSummary(TravelData data)
        {
            var panel = this.FindControl<StackPanel>("SummaryPanel");

            panel.Children.Add(new TextBlock { Text = $"Imię: {data.UserName}" });
            panel.Children.Add(new TextBlock { Text = $"Kraj: {data.Country}" });
            panel.Children.Add(new TextBlock { Text = $"Środek transportu: {data.Transport}" });

            panel.Children.Add(new TextBlock { Text = "Atrakcje:" });
            foreach (var attraction in data.Attractions)
                panel.Children.Add(new TextBlock { Text = $"- {attraction}" });

            panel.Children.Add(new TextBlock { Text = "Miasta do odwiedzenia:" });
            foreach (var city in data.Cities)
                panel.Children.Add(new TextBlock { Text = $"- {city}" });
        }
    }
}