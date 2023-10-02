using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayers.Models
{
    /// <summary>
    /// Creates a base class for the view model
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {

        NavigateCommand<BaseViewModel> navigateCommand;

        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Initializes the view Model
        /// </summary>
        public BaseViewModel()
        {

        }
        
        /// <summary>
        /// When property is changed update
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
