using MusicPlayers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayers.Misc
{
    /// <summary>
    /// 
    /// </summary>
    public class NavigationStore
    {
        private BaseViewModel currentViewModel { get; set; }
        public event Action CurrentViewModelChanged;
        public BaseViewModel CurrentViewModel
        {

            get => currentViewModel;

            set
            {
                currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }
        /// <summary>
        /// Checks if the view model is changed and updates the view
        /// </summary>
        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
