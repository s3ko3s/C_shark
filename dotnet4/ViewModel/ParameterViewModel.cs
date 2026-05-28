using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using dotnet2.Services;

namespace dotnet2.ViewModel
{
    public sealed class ParameterViewModel : INotifyPropertyChanged
    {
        private string _value;

        public ParameterViewModel(string technicalName, Type parameterType, string defaultValue = null)
        {
            Name = technicalName;
            DisplayName = ReflectionDisplayNames.ToRussian(technicalName);
            ParameterType = parameterType;
            TypeDisplayName = ReflectionDisplayNames.ToRussianType(parameterType);
            _value = defaultValue ?? GetDefaultValue(parameterType);
        }

        /// <summary>Имя для рефлексии (английское).</summary>
        public string Name { get; }

        /// <summary>Подпись на форме (русская).</summary>
        public string DisplayName { get; }

        public Type ParameterType { get; }

        public string TypeDisplayName { get; }

        public string Value
        {
            get => _value;
            set
            {
                if (_value != value)
                {
                    _value = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private static string GetDefaultValue(Type parameterType)
        {
            Type underlyingType = Nullable.GetUnderlyingType(parameterType) ?? parameterType;

            if (underlyingType == typeof(string))
            {
                return string.Empty;
            }

            if (underlyingType == typeof(bool))
            {
                return "Ложь";
            }

            if (underlyingType == typeof(int))
            {
                return "0";
            }

            return string.Empty;
        }
    }
}
