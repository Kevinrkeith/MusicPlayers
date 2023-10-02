using MusicPlayers.Misc;
using MusicPlayers.Music;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicPlayers.Models
{
    public class SongModel
    {
        #region Variables
        public int Id { get; set; }
        public string FilePath { get; set; }
        public string Name { get; set; }

        
        public ICommand playCommand { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes the ICommand and the class.
        /// </summary>
        public SongModel()
        {
            playCommand = new DelegateCommand(ChangeSong);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Changes the current song in the singleton
        /// </summary>
        public void ChangeSong()
        {
            Console.WriteLine($"Hello world {Id}");
            SongManager.SetSong(Id);
        }
        #endregion
    }
}
