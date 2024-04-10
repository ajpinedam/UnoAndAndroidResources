using Windows.Devices.Geolocation;

namespace GeoTest.Presentation;

public sealed partial class MainPage : Page
{
    private Geolocator _geolocator;
    public MainPage()
    {
        this.InitializeComponent();

        _geolocator = new Geolocator();
        _geolocator.MovementThreshold = 1;
        _geolocator.ReportInterval = 2000;
    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        await AskPermissions();
    }

    public async Task AskPermissions()
    {
        var accessStatus = await Geolocator.RequestAccessAsync();
        if (accessStatus == GeolocationAccessStatus.Allowed)
        {
            _geolocator.PositionChanged += Locator_PositionChanged;
        }
    }

    private async void Locator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
    {
        var loc = args.Position;
        this.Text1.Text = "Latitude Changed:" + loc.Coordinate.Latitude.ToString();
        //await Locations.AddAsync(loc.Coordinate.Latitude.ToString() + "," + loc.Coordinate.Longitude.ToString());
    }
}
