using MusicPlayers.Misc;
using MusicPlayers.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicPlayers.ViewModels
{
    public class FileExplorerViewModel : BaseViewModel
    {
        public ICommand onClick { get; set; }
        private ObservableCollection<string> _directories;
        private ObservableCollection<string> _files;
        private string path { get; set; }
        public ObservableCollection<string> Directories
        {
            get { return _directories; }
            set { _directories = value; }
        }
        public ObservableCollection<string> Files
        {
            get { return _files; }
            set { _files = value; }
        }
        public FileExplorerViewModel() 
        {
            Console.WriteLine("Hello World");
            onClick = new DelegateCommand(Clicked);
            _directories = new ObservableCollection<string>();
            path = Directory.GetCurrentDirectory();
            CreateDirectory();
            GetFiles();
        }
        private void GetFiles()
        {
            _files = new ObservableCollection<string>();
            string[] temp = Directory.GetFiles(path);
            foreach (string s in temp)
            {
                _files.Add(s);
            }
        }
        private void CreateDirectory()
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            string temp = "";
            StringBuilder builder = new StringBuilder();
            foreach (char c in path)
            {
                temp += c;
                if(c == '\\')
                {
                    _directories.Add(temp);
                    temp = "";
                }
            }
        }
        private void Clicked()
        {
            Console.WriteLine("Hello World");
        }
    }
}
