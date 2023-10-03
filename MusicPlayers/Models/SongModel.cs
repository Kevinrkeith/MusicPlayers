using MusicPlayers.Misc;
using MusicPlayers.Music;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TagLib;

namespace MusicPlayers.Models
{
    public class SongModel
    {
        #region Variables
        public int Id { get; set; }
        public string FilePath { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public uint Year { get; set; }
        public ICommand playCommand { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes the current Id
        /// Filepath
        /// And Name
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="FilePath"></param>
        public SongModel(int Id, string FilePath)
        {
            this.Id = Id;
            this.FilePath = FilePath;
            Name = Path.GetFileName(FilePath);
            using (var mp3 = new Mp3FileReader(FilePath))
            {
                TimeSpan span = mp3.TotalTime;
                Duration = $"{span.Minutes}:{span.Seconds}";
                playCommand = new DelegateCommand(ChangeSong);
            }
            var file = TagLib.File.Create(FilePath);
            Artist = file.Tag.FirstPerformer;
            Album = file.Tag.Album;
            Year = file.Tag.Year;
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
