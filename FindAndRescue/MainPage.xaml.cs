using System.Reflection;

namespace FindAndRescue
{
    public partial class MainPage : ContentPage
    {
        public List<Rescue> Rescues { get; set; }
        public MainPage()
        {
            InitializeComponent();

            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Resources.Raw.RescueSource.json";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        var json = reader.ReadToEnd();
                        Rescues = JsonSerializer.Deserialize<List<Rescue>>(json);
                    }
                }

                //rescueCollectionView.ItemsSource = Rescues;
            }
        }

    }
}
