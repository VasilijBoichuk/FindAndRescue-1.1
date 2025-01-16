using FindAndRescue.Services;
using Microsoft.Extensions.Logging;

namespace FindAndRescue.ViewModel
{
    [QueryProperty("Rescue", "Rescue")]
    public partial class RescueDetailsViewModel : BaseViewModel
    {
        private readonly IMap map;

        public RescueDetailsViewModel(IMap map)
        {
            this.map = map;
        }

        [ObservableProperty]
        Rescue rescue;

        [ICommand]
        public async Task OpenMapAsync()
        {
            try
            {
                if (rescue == null)
                    return;

                await map.OpenAsync(rescue.Latitude, rescue.Longitude, new MapLaunchOptions
                {
                    Name = string.Join(", ", rescue.StreetName),
                    NavigationMode = NavigationMode.None
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("ERROR!", $"Unable to open map: {ex.Message}", "OK");
            }
        }
    }
}
