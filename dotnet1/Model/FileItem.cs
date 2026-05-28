using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace dotnet1.Model
{
    public class FileItem : INotifyPropertyChanged
    {
        private string _name;
        private string _location;

        public string Name => _name;
        public FileCategory Category { get; }
        public long Size { get; }
        public string Location => _location;

        public FileItem(string name, FileCategory category, long size, string location)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Имя не может быть пустым");
            if (string.IsNullOrWhiteSpace(location))
                throw new ArgumentException("Путь не может быть пустым");
            if (size < 0)
                throw new ArgumentException("Размер не может быть отрицательным");

            _name = name;
            Category = category;
            _location = location;
            Size = (category == FileCategory.Folder) ? 0 : size;
        }

        public FileItem CopyTo(string newLocation)
        {
            if (string.IsNullOrWhiteSpace(newLocation))
                throw new ArgumentException("Путь для копии не может быть пустым");
            return new FileItem(Name, Category, Size, newLocation);
        }

        public void MoveTo(string newLocation)
        {
            if (string.IsNullOrWhiteSpace(newLocation))
                throw new ArgumentException("Новый путь не может быть пустым");
            _location = newLocation;
            OnPropertyChanged(nameof(Location));
        }

        public void Rename(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Новое имя не может быть пустым");
            _name = newName;
            OnPropertyChanged(nameof(Name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public override string ToString() => Name;
    }
}