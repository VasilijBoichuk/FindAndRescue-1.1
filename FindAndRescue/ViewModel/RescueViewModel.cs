using FindAndRescue.Services;

namespace FindAndRescue.ViewModel
{
    public partial class RescueViewModel : BaseViewModel
    {
        RescueService rescueService;

        public ObservableCollection<Rescue> Rescues { get; } = new();

        public RescueViewModel(RescueService rescueService)
        {
            Title = "Find and Rescue";
            this.rescueService = rescueService;
        }

        [ICommand]

        async Task GetRescuesAsync()
        {
            if (IsBusy)
                return;

            try
            {
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
