﻿using MusicPlayers.Models;
using MusicPlayers.ViewModels;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayers.Music
{
    public static class SongManager
    {
        public static MusicViewModel musicViewModel;
        public static int currentSong;
        private static IWavePlayer _player;
        private static AudioFileReader _audioFileReader;
        public static ObservableCollection<SongModel> pubSongs
        {
            get
            {
                return Songs;
            }
            set { Songs = value; }
        }
        private static ObservableCollection<SongModel> Songs;
        public static string Path;
        public static bool _isPlaying;
        public static void Initialize(string path)
        {
            Songs = new ObservableCollection<SongModel>();
            _isPlaying = false;
            Path = path;
            _player = new WaveOutEvent();
            string[] fileNames = Directory.GetFiles($"{path}\\Music");
            for (int i = 0; i < fileNames.Length; i++)
            {
                SongModel song = new SongModel();
                song.Id = i;
                song.FilePath = fileNames[i];
                song.Name = fileNames[i].Replace(path + "\\Music\\", string.Empty);
                Songs.Add(song);
            }
            _audioFileReader = new AudioFileReader(Songs[currentSong].FilePath);
            _player.Init(_audioFileReader);
        }
        public static void SetSong(int id)
        {
            if (id < 0) id = SongManager.Songs.Count - 1;
            currentSong = id;
            _audioFileReader = new AudioFileReader(Songs[currentSong].FilePath);
            _player.Stop();
            _player.Init(_audioFileReader);
            _player.Play();
        }
        public static void StopSong()
        {
            _player.Stop();
            _isPlaying = false;
        }
        public static void PlaySong()
        {
            if (_isPlaying)
            {
                _player.Pause();
            } else
            {
                _player.Play();
            }
        }
    }
}