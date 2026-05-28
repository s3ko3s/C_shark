using System;
using System.ComponentModel;
using dotnet1.Model;
using System.Collections.Generic;

namespace dotnet1.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private BindingList<FileItem> _files;
        private FileItem _currentFile;

        public BindingList<FileItem> Files
        {
            get => _files;
            set { _files = value; OnPropertyChanged(); }
        }

        public FileItem CurrentFile
        {
            get => _currentFile;
            set { _currentFile = value; OnPropertyChanged(); }
        }

        // Данные передаются извне (соблюдение пункта 3 задания)
        public MainViewModel(IEnumerable<FileItem> initialFiles = null)
        {
            Files = new BindingList<FileItem>(
                initialFiles != null
                    ? new List<FileItem>(initialFiles)
                    : new List<FileItem>()
            );
        }

        private bool ValidateCurrentAndInput(string input, string operationName)
        {
            if (CurrentFile == null)
            {
                ShowMessage("Не выбран элемент.", operationName);
                return false;
            }
            if (string.IsNullOrWhiteSpace(input))
            {
                ShowMessage($"Введите значение для {operationName.ToLower()}.", operationName);
                return false;
            }
            return true;
        }

        public bool RenameCurrent(string newName)
        {
            if (!ValidateCurrentAndInput(newName, "Переименование")) return false;
            try
            {
                CurrentFile.Rename(newName);
                // Обновляем привязки – имя изменится через INotifyPropertyChanged
                return true;
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, "Ошибка переименования");
                return false;
            }
        }

        public bool MoveCurrent(string newPath)
        {
            if (!ValidateCurrentAndInput(newPath, "Перемещение")) return false;
            try
            {
                CurrentFile.MoveTo(newPath);
                return true;
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, "Ошибка перемещения");
                return false;
            }
        }

        public bool CopyCurrent(string newPath)
        {
            if (!ValidateCurrentAndInput(newPath, "Копирование")) return false;
            try
            {
                var copy = CurrentFile.CopyTo(newPath);
                Files.Add(copy);
                ShowMessage($"Копия \"{CurrentFile.Name}\" создана по пути {newPath}", "Копирование");
                return true;
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, "Ошибка копирования");
                return false;
            }
        }

        public void AddTestFile()
        {
            string newName = $"NewFile_{Files.Count + 1}.txt";
            // Используем временную папку системы вместо жёстко заданного C:\temp
            string tempPath = System.IO.Path.GetTempPath();
            Files.Add(new FileItem(newName, FileCategory.File, 512, tempPath));
        }

        public event Action<string, string> ShowMessageEvent;
        private void ShowMessage(string text, string caption) => ShowMessageEvent?.Invoke(text, caption);

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}