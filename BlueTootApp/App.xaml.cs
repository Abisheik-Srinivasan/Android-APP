using BlueTootApp.Views;

namespace BlueTootApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());

           
        }
    }
}
