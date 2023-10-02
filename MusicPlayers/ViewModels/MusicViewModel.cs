using MusicPlayers.Misc;
using MusicPlayers.Models;
using MusicPlayers.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using NAudio.Wave;
using MusicPlayers.Music;

namespace MusicPlayers.ViewModels
{
    public class MusicViewModel : BaseViewModel
    {
        #region Variables
        public string PlayPause { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public string Stop { get; set; }
        #endregion

        #region ICommand 
        public ICommand PlayCommand { get; set; }
        public ICommand FileCommand { get; set; }
        public ICommand StopCommand { get; set; }
        public ICommand NextCommand { get; set; }
        public ICommand PreviousCommand { get; set; }
        #endregion

        public ObservableCollection<SongModel> Songs {
            get
            {
                return SongManager.pubSongs;
            }
            set 
            {
                SongManager.pubSongs = value;
            }
        }
        public string CurrentSong { get; set; }

        Timer timer;

        /// <summary>
        /// Sets the Navigation Store and View Model for this so this view can be changed to
        /// </summary>
        /// <param name="navi"></param>
        public MusicViewModel(NavigationStore navi)
        {
            string path = Directory.GetCurrentDirectory();
            path = Directory.GetParent(Directory.GetParent(path).FullName).FullName;
            SongManager.Initialize(path);
            PlayPause = $"{path}\\Images\\PlayButton2.png";
            Previous = $"{path}\\Images\\PreviousButton.png";
            Stop = $"{path}\\Images\\StopButton.png";
            Next = $"{path}\\Images\\NextButton.png";
            PlayCommand = new DelegateCommand(playButtonCommand);
            NextCommand = new DelegateCommand(NextButtonCommand);
            PreviousCommand = new DelegateCommand(PreviousButtonCommand);
            FileCommand = new DelegateCommand(FileButton);
            StopCommand = new DelegateCommand(StopSong);
            SongManager.musicViewModel = this;
        }
        /// <summary>
        /// Opens up the file explorer
        /// </summary>
        private void FileButton()
        {
            FileExplorer files = new FileExplorer();
            files.Show();
        }

        /// <summary>
        /// Stops the song in the Song Manager
        /// </summary>
        private void StopSong()
        {
            playButtonCommand();
            PlayPause = $"{SongManager.Path}\\Images\\PauseButton1.png";
            SongManager.StopSong();
            OnPropertyChanged(nameof(PlayPause));
        }

        /// <summary>
        /// Calls The Next Song, if at the end, plays the first song
        /// </summary>
        private void NextButtonCommand()
        {
            int val = (SongManager.currentSong + 1) % SongManager.pubSongs.Count;
            SongManager.SetSong(val);
        }

        /// <summary>
        /// Calls the previous song, if at the beginning, plays the last song
        /// </summary>
        private void PreviousButtonCommand()
        {
            
            int val = (SongManager.currentSong - 1) % SongManager.pubSongs.Count;
            SongManager.SetSong(val);
        }

        /// <summary>
        /// Calls the Play and Pause
        /// Button changes to reflect the song playing
        /// </summary>
        private void playButtonCommand()
        {   
            if (SongManager._isPlaying)
            {
                PlayPause = $"{SongManager.Path}\\Images\\PlayButton2.png";
            } else
            {
                PlayPause = $"{SongManager.Path}\\Images\\PauseButton1.png";
            }
            SongManager.PlaySong();
            SongManager._isPlaying = !SongManager._isPlaying;
            OnPropertyChanged(nameof(PlayPause));
        }
    }
}
