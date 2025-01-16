namespace FindAndRescue;

public partial class DetailsPage : ContentPage
{
    public DetailsPage(RescueDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

}
