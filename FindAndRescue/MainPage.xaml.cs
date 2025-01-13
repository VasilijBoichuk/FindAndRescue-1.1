using System.Net.Http;
using System.Reflection;

namespace FindAndRescue
{
    public partial class MainPage : ContentPage
    {
        public List<Rescue> Rescues { get; set; }
        public MainPage()
        {
            InitializeComponent();

        }

    }
}
