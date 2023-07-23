using MusicPlayers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayers.Misc
{
    public class NavigationStore
    {
        private BaseViewModel currentViewModel { get; set; }
        public BaseViewModel CurrentViewModel
        {

            get => currentViewModel;

            set
            {
                currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }
        public event Action CurrentViewModelChanged;
        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
