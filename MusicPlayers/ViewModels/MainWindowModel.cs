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
        public MainWindowModel(NavigationStore navigation)
        {
            this.navigation = navigation;

            navigation.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
