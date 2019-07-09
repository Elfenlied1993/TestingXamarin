using Xamarin.Forms;

namespace TestingXamarinForms
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new DataViewModel();
        }
    }
}
