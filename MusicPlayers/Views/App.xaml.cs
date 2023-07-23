using MusicPlayers.Misc;
using MusicPlayers.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MusicPlayers.Views
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore navigation;
        public App()
        {
            navigation = new NavigationStore();
        }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            navigation.CurrentViewModel = new MusicViewModel(navigation);

            MainWindow = new MainWindow()
            {
                DataContext = new MainWindowModel(navigation)
            };
            MainWindow.Show();
        }
    }
}
