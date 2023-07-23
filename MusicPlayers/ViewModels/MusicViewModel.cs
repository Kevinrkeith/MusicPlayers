﻿using MusicPlayers.Misc;
using MusicPlayers.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicPlayers.ViewModels
{
    public class MusicViewModel : BaseViewModel
    {
        public string PlayPause { get; set; }
        public ICommand PlayCommand { get; set; }
        private bool _isPlaying {get; set;}
        public string CurrentSong { get; set; }
        private SoundPlayer player;
        string path;
        Timer timer;
        public MusicViewModel(NavigationStore navi)
        {
            path = Directory.GetCurrentDirectory();
            path = Directory.GetParent(path).FullName;
            path = Directory.GetParent(path).FullName;
            PlayPause = $"{path}\\Images\\PlayButton2.png";
            PlayCommand = new DelegateCommand(playButtonCommand);
            _isPlaying = false;
            CurrentSong = "Hello World";
        }
        private void playButtonCommand()
        {
            
            Console.WriteLine(path);
            
            if (_isPlaying)
            {
                PlayPause = $"{path}\\Images\\PlayButton2.png";
                player.Stop();
            } else
            {
                PlayPause = $"{path}\\Images\\PauseButton1.png";
                player.Play();
            }
            _isPlaying = !_isPlaying;
            OnPropertyChanged(nameof(PlayPause));
        }
    }
}