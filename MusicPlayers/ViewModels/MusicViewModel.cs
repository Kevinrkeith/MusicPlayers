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
        public string PlayPause { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public string Stop { get; set; }
        public ICommand PlayCommand { get; set; }
        public ICommand FileCommand { get; set; }
        public ICommand StopCommand { get; set; }
        public ICommand NextCommand { get; set; }
        public ICommand PreviousCommand { get; set; }
        
        private int currentSong = 0;
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
        private ObservableCollection<SongModel> _Songs;
        public ObservableCollection<String> _playlists { get; set;}
        public string CurrentSong { get; set; }

        Timer timer;
        public MusicViewModel(NavigationStore navi)
        {
            
            _Songs = new ObservableCollection<SongModel>();
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
        private void FileButton()
        {
            FileExplorer files = new FileExplorer();
            files.Show();
        }
        private void StopSong()
        {
            playButtonCommand();
            PlayPause = $"{SongManager.Path}\\Images\\PauseButton1.png";
            SongManager.StopSong();
            OnPropertyChanged(nameof(PlayPause));
        }
        private void NextButtonCommand()
        {
            int val = (SongManager.currentSong + 1) % SongManager.pubSongs.Count;
            SongManager.SetSong(val);
        }
        private void PreviousButtonCommand()
        {
            
            int val = (SongManager.currentSong - 1) % SongManager.pubSongs.Count;
            SongManager.SetSong(val);
        }
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
