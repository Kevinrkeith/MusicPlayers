using MusicPlayers.Misc;
using MusicPlayers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayers.ViewModels
{
    public class MainWindowModel : BaseViewModel
    {
        private readonly NavigationStore navigation;
        public BaseViewModel CurrentViewModel => navigation.CurrentViewModel;
        
        /// <summary>
        /// Initializes the Main Window
        /// Opens whatever the current view model is and matches with the view
        /// </summary>
        /// <param name="navigation"></param>
        public MainWindowModel(NavigationStore navigation)
        {
            this.navigation = navigation;

            navigation.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        /// <summary>
        /// If changed then changes view
        /// </summary>
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
