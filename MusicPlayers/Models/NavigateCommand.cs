using MusicPlayers.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayers.Models
{
    /// <summary>
    /// Creates a Navigation Command to allow us to move between multiple views
    /// </summary>
    /// <typeparam name="TViewModel"></typeparam>
    public class NavigateCommand<TViewModel> : CommandBase
        where TViewModel : BaseViewModel
    {
        private readonly NavigationStore navi;
        private readonly Func<TViewModel> viewModel;
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Initializes Navigation Command
        /// </summary>
        /// <param name="navi">Holds the Navigation Store</param>
        /// <param name="createViewModel">Holds where the ViewModel is located for the Main view to select it</param>
        public NavigateCommand(NavigationStore navi, Func<TViewModel> createViewModel)
        {
            this.navi = navi;
            viewModel = createViewModel;
        }
        /// <summary>
        /// When property is changed, sends alert
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// Executes the command when called
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object parameter)
        {
            navi.CurrentViewModel = viewModel();
        }
    }
}
