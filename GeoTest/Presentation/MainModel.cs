using Microsoft.UI.Dispatching;
using Uno.Extensions.Reactive;
using Windows.Devices.Geolocation;
using Windows.UI.Core;

namespace GeoTest.Presentation;

public partial record MainModel
{
    private INavigator _navigator;
    private Geolocator _geolocator;

    // Insert variables below here
    public MainModel(
        IStringLocalizer localizer,
        IOptions<AppConfig> appInfo,
        INavigator navigator)
    {
        _navigator = navigator;
        Title = "Main";
        Title += $" - {localizer["ApplicationName"]}";
        Title += $" - {appInfo?.Value?.Environment}";

        _geolocator = new Geolocator();

        _geolocator.MovementThreshold = 1;
        _geolocator.ReportInterval = 2000;
    }

    private async void Locator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
    {
        var loc = args.Position;
        await Status.Update(x => $"Location Changed: {loc.Coordinate?.Latitude.ToString()}", CancellationToken.None);
        
        await Locations.AddAsync(loc.Coordinate.Latitude.ToString() + "," + loc.Coordinate.Longitude.ToString(), CancellationToken.None);
    }

    public string? Title { get; }

    public IListState<string> Locations => ListState<string>.Empty(this);

    public IState<string> Status => State<string>.Empty(this);

    public async Task AskPermissions()
    {
        await Status.Update(x => "Asking Permissions...", CancellationToken.None);

        var accessStatus = await Geolocator.RequestAccessAsync();

        if (accessStatus == GeolocationAccessStatus.Allowed)
        {
            //var loc = await _geolocator.GetGeopositionAsync();
            //var loc = await _geolocator.GetGeopositionAsync(TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(10));
            //var lon = loc?.Coordinate.Longitude;
            //loc?.Coordinate.Latitude
            await Status.Update(x => $"Permission Granted: Current lon {0} and lat: {0}", CancellationToken.None);

            _geolocator.PositionChanged += Locator_PositionChanged;
        }
    }
}
