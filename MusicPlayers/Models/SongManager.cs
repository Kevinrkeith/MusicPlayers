using MusicPlayers.Models;
using MusicPlayers.ViewModels;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MusicPlayers.Music
{
    public static class SongManager
    {
        #region Variables
        public static MusicViewModel musicViewModel;
        public static int currentSong;
        private static IWavePlayer _player;
        private static AudioFileReader _audioFileReader;
        public static string time;
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
        public static float Volume;
        #endregion

        #region Initialize
        /// <summary>
        /// Initilizes the Singleton Class
        /// Creates a list of the songs from the PDF
        /// parses them out to include the title and audio format
        /// Initializes the player
        /// </summary>
        /// <param name="path"> Takes in the Current path for the files</param>
        public static void Initialize(string path)
        {
            Songs = new ObservableCollection<SongModel>();
            _isPlaying = false;
            Path = path;
            _player = new WaveOutEvent();
            string[] fileNames = Directory.GetFiles($"{path}\\Music");
            for (int i = 0; i < fileNames.Length; i++)
            {
                SongModel song = new SongModel(i, fileNames[i]);
                Songs.Add(song);
            }
            _audioFileReader = new AudioFileReader(Songs[currentSong].FilePath);
            _player.Init(_audioFileReader);
            Volume = 0.5f;
            _player.Volume = Volume;
            time = $":{Songs[currentSong].Duration}";
        }
        #endregion

        #region Start/Stop
        /// <summary>
        /// Sets the current song set from an ID
        /// </summary>
        /// <param name="id"></param>
        public static void SetSong(int id)
        {
            if (id < 0) id = SongManager.Songs.Count - 1;
            currentSong = id;
            _audioFileReader = new AudioFileReader(Songs[currentSong].FilePath);
            _player.Stop();
            _player.Init(_audioFileReader);
            _player.Play();
        }
        /// <summary>
        /// Stops the song
        /// </summary>
        public static void StopSong()
        {
            _player.Stop();
            _isPlaying = false;
        }
        /// <summary>
        /// Plays the song
        /// </summary>
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
        #endregion

        /// <summary>
        /// Changes the Volume for the audio on the song
        /// </summary>
        public static void ChangeAudio()
        {
            _player.Volume = Volume;
        }
    }
}
