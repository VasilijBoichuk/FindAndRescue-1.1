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

        async Task GetRescuesAsync()
        {
            if(IsBusy)
                return;

            try
            {

            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }
    }
}
