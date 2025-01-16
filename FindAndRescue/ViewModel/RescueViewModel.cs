using FindAndRescue.Services;
namespace FindAndRescue.ViewModel
{
    public partial class RescueViewModel : BaseViewModel
    {
        RescueService rescueService;

        public ObservableCollection<Rescue> Rescues { get; } = new();

        IConnectivity connectivity;
        IGeolocation geolocation;

        public RescueViewModel(RescueService rescueService, IConnectivity connectivity, IGeolocation geolocation)
        {
            Title = "Find and Rescue";
            this.rescueService = rescueService;
            this.connectivity = connectivity;
            this.geolocation = geolocation;
        }

        

        [ICommand]

        async Task GoToDetailsPageAsync(Rescue rescue)
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
                if(connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("Internet Error Message!",
                    $"No Internet.", "OK");
                    return;
                }
                IsBusy = true;
                var rescues = await rescueService.GetRescues();

                if (Rescues.Count != 0)
                    Rescues.Clear();

                foreach (var rescue in rescues)
                    Rescues.Add(rescue);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("ERROR!",
                    $"Not able to get streets data: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
