namespace FindAndRescue.ViewModel;

[QueryProperty("Rescue", "Rescue")]
public partial class RescueDetailsViewModel : BaseViewModel
{
    public RescueDetailsViewModel()
    {
    }

    [ObservableProperty]
    Rescue rescue;
}
