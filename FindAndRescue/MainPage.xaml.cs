namespace FindAndRescue
{
    public partial class MainPage : ContentPage
    {
        public MainPage(RescueViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
		}

	}
}
