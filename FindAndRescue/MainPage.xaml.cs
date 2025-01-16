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

            if (BindingContext is RescueViewModel viewModel && !viewModel.IsBusy)
            {
                await viewModel.GetRescuesAsync();
            }
        }

    }
}
