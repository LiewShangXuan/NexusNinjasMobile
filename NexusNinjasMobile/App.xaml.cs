using NexusNinjasMobile;
using Microsoft.Maui.Controls;
using NexusNinjasMobile.Chatbox;
namespace NexusNinjasMobile
{
    public partial class App : Application
    { 
        public App()
        {
            InitializeComponent();

            // Set the loading page as the main page initially
            MainPage = new NavigationPage(new LoadingPage());

            MeeageViewModel viewModel = new MeeageViewModel();
            
        }
    }
}
