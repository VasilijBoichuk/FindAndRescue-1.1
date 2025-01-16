namespace FindAndRescue
{
    public partial class MainPage : ContentPage
    {
        public MainPage(RescueViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Check if the command can be executed
            if (BindingContext is RescueViewModel viewModel && !viewModel.IsBusy)
            {
                // Execute the GetRescuesAsync method
                await viewModel.GetRescuesAsync();
            }
        }

    }
}
