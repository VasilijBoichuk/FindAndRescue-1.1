namespace FindAndRescue.ViewModel;

[QueryProperty("Rescue", "Rescue")]
public partial class RescueDetailsViewModel : BaseViewModel
{

    IMap map;
    public RescueDetailsViewModel(IMap map)
    {
        this.map = map;
    }

    [ObservableProperty]
    Rescue rescue;

    [ICommand]

    async Task OpenMapAsync()
    {
        try
        {
            await map.OpenAsync(Rescue.Latitude, Rescue.Longitude,
                new MapLaunchOptions
                {
                    Name = string.Join(", ", Rescue.StreetName),
                    NavigationMode = NavigationMode.None
                });
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("ERROR!",
                $"Cant open map: {ex.Message}", "OK");
            return;
        }
    }
}
