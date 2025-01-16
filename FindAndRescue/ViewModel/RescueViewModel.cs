using FindAndRescue.Services;
using Microsoft.Extensions.Logging;

namespace FindAndRescue.ViewModel
{
    public partial class RescueViewModel : BaseViewModel
    {
        private readonly RescueService rescueService;
        private readonly IConnectivity connectivity;
        private readonly IGeolocation geolocation;

        public ObservableCollection<Rescue> Rescues { get; } = new();

        public RescueViewModel(RescueService rescueService, IConnectivity connectivity, IGeolocation geolocation)
        {
            Title = "Find and Rescue";
            this.rescueService = rescueService;
            this.connectivity = connectivity;
            this.geolocation = geolocation;
        }

        [ICommand]
        public async Task GoToDetailsPageAsync(Rescue rescue)
        {
            if (rescue == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(DetailsPage)}", true, new Dictionary<string, object>
            {
                {"Rescue", rescue}
            });
        }

        [ICommand]
        public async Task GetRescuesAsync()
        {
            if (IsBusy)
                return;

            try
            {
                if (connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("Internet Error", "No Internet connection.", "OK");
                    return;
                }

                IsBusy = true;

                var rescues = await rescueService.GetRescues();

                Rescues.Clear();
                foreach (var rescue in rescues)
                {
                    Rescues.Add(rescue);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("ERROR!", $"Unable to fetch street data: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
