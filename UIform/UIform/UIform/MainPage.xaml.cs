using Windows.UI;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;

namespace UIform
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            SolidColorBrush brush = new SolidColorBrush(Colors.Gray);
            brush.Opacity = 0.25;
            Head.Text = "You can";
            Google.Text = "Sign up with google";
            Cloud.Text = "and store your data in the cloud*, or";
            Start.Text = "Just Start";
            Phone.Text = "and store all your data on the phone**";
            Privacy.Text =
                "*Further you can check our Privacy Policy, also you will be able to delete your account at any time";
            Privacy_2.Text = "**If you delete, reinstall the app all data will be lost";
        }
    }
}
