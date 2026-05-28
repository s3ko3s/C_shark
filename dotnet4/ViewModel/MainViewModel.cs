using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using FlyingMachine.Contracts;
using dotnet2.Services;

namespace dotnet2.ViewModel
{
    public sealed class MainViewModel : INotifyPropertyChanged
    {
        private readonly FlyingMachineAssemblyLoader _assemblyLoader = new FlyingMachineAssemblyLoader();
        private readonly Dictionary<string, string> _constructorDisplayToTechnical =
            new Dictionary<string, string>(StringComparer.Ordinal);
        private readonly Dictionary<string, string> _methodDisplayToEnglishName =
            new Dictionary<string, string>(StringComparer.Ordinal);

        private string _libraryPath;
        private string _statusMessage;
        private string _selectedClassName;
        private string _selectedConstructorSignature;
        private string _selectedMethodSignature;
        private string _executionResult;
        private bool _canExecute;

        public MainViewModel()
        {
            ClassNames = new ObservableCollection<string>();
            ConstructorSignatures = new ObservableCollection<string>();
            MethodSignatures = new ObservableCollection<string>();
            ConstructorParameters = new ObservableCollection<ParameterViewModel>();
            MethodParameters = new ObservableCollection<ParameterViewModel>();
            ObjectProperties = new ObservableCollection<ParameterViewModel>();
        }

        public ObservableCollection<string> ClassNames { get; }

        public ObservableCollection<string> ConstructorSignatures { get; }

        public ObservableCollection<string> MethodSignatures { get; }

        public ObservableCollection<ParameterViewModel> ConstructorParameters { get; }

        public ObservableCollection<ParameterViewModel> MethodParameters { get; }

        public ObservableCollection<ParameterViewModel> ObjectProperties { get; }

        public string LibraryPath
        {
            get => _libraryPath;
            set
            {
                if (_libraryPath != value)
                {
                    _libraryPath = value;
                    OnPropertyChanged();
                }
            }
        }

        public string StatusMessage
        {
            get => _statusMessage;
            set
            {
                _statusMessage = value;
                OnPropertyChanged();
            }
        }

        public string SelectedClassName
        {
            get => _selectedClassName;
            set
            {
                string technicalName = ReflectionDisplayNames.ToEnglish(value);
                if (_selectedClassName != technicalName)
                {
                    _selectedClassName = technicalName;
                    OnPropertyChanged();
                    RefreshConstructorsAndMethods();
                }
            }
        }

        public string SelectedConstructorSignature
        {
            get => _selectedConstructorSignature;
            set
            {
                if (_selectedConstructorSignature != value)
                {
                    _selectedConstructorSignature = value;
                    OnPropertyChanged();
                    RefreshConstructorParameters();
                }
            }
        }

        public string SelectedMethodSignature
        {
            get => _selectedMethodSignature;
            set
            {
                if (_selectedMethodSignature != value)
                {
                    _selectedMethodSignature = value;
                    OnPropertyChanged();
                    RefreshMethodParameters();
                    UpdateCanExecute();
                }
            }
        }

        public string ExecutionResult
        {
            get => _executionResult;
            set
            {
                _executionResult = value;
                OnPropertyChanged();
            }
        }

        public bool CanExecute
        {
            get => _canExecute;
            private set
            {
                if (_canExecute != value)
                {
                    _canExecute = value;
                    OnPropertyChanged();
                }
            }
        }

        public void LoadLibrary()
        {
            try
            {
                StatusMessage = _assemblyLoader.Load(LibraryPath);
                ClassNames.Clear();
                _constructorDisplayToTechnical.Clear();
                _methodDisplayToEnglishName.Clear();

                foreach (Type type in _assemblyLoader.ImplementingTypes)
                {
                    ClassNames.Add(ReflectionDisplayNames.ToRussian(type.Name));
                }

                ExecutionResult = string.Empty;
            }
            catch (Exception exception)
            {
                StatusMessage = "Ошибка загрузки: " + exception.Message;
                ClassNames.Clear();
                ConstructorSignatures.Clear();
                MethodSignatures.Clear();
                ConstructorParameters.Clear();
                MethodParameters.Clear();
                ObjectProperties.Clear();
                _constructorDisplayToTechnical.Clear();
                _methodDisplayToEnglishName.Clear();
                CanExecute = false;
            }
        }

        public void ExecuteSelectedMethod()
        {
            try
            {
                Type type = _assemblyLoader.GetTypeByName(_selectedClassName);
                if (type == null)
                {
                    ExecutionResult = "Класс не выбран.";
                    return;
                }

                ConstructorInfo constructor = FindSelectedConstructor(type);
                if (constructor == null)
                {
                    ExecutionResult = "Конструктор не выбран.";
                    return;
                }

                MethodInfo method = FindSelectedMethod(type);
                if (method == null)
                {
                    ExecutionResult = "Метод не выбран.";
                    return;
                }

                string methodDisplayName = ReflectionDisplayNames.ToRussian(method.Name);

                object[] constructorArguments = BuildArguments(ConstructorParameters);
                object instance = Activator.CreateInstance(type, constructorArguments);

                ApplyPropertyValues(instance, type, ObjectProperties);

                object[] methodArguments = BuildArguments(MethodParameters);
                object result = method.Invoke(instance, methodArguments);

                if (method.ReturnType == typeof(void))
                {
                    ExecutionResult = $"Метод «{methodDisplayName}» выполнен.";
                    if (instance is IFlyingMachine flyingMachine)
                    {
                        ExecutionResult += Environment.NewLine
                            + ReflectionDisplayNames.TranslateResultText(flyingMachine.GetInfo());
                    }
                }
                else
                {
                    string resultText = ReflectionDisplayNames.TranslateResultText(result?.ToString() ?? string.Empty);
                    ExecutionResult = $"Метод «{methodDisplayName}» выполнен. Результат: {resultText}";
                }
            }
            catch (Exception exception)
            {
                ExecutionResult = "Ошибка выполнения: " + exception.Message;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RefreshConstructorsAndMethods()
        {
            ConstructorSignatures.Clear();
            MethodSignatures.Clear();
            ConstructorParameters.Clear();
            MethodParameters.Clear();
            ObjectProperties.Clear();
            _constructorDisplayToTechnical.Clear();
            _methodDisplayToEnglishName.Clear();
            CanExecute = false;

            Type type = _assemblyLoader.GetTypeByName(_selectedClassName);
            if (type == null)
            {
                return;
            }

            foreach (ConstructorInfo constructor in FlyingMachineAssemblyLoader.GetConstructors(type))
            {
                string technicalSignature = BuildTechnicalConstructorSignature(constructor);
                string displaySignature = ReflectionDisplayNames.BuildRussianConstructorSignature(constructor);
                ConstructorSignatures.Add(displaySignature);
                _constructorDisplayToTechnical[displaySignature] = technicalSignature;
            }

            foreach (MethodInfo method in FlyingMachineAssemblyLoader.GetCallableMethods(type))
            {
                string displaySignature = ReflectionDisplayNames.BuildRussianMethodSignature(method);
                MethodSignatures.Add(displaySignature);
                _methodDisplayToEnglishName[displaySignature] = method.Name;
            }

            RefreshObjectProperties();
        }

        private void RefreshConstructorParameters()
        {
            ConstructorParameters.Clear();

            Type type = _assemblyLoader.GetTypeByName(_selectedClassName);
            ConstructorInfo constructor = FindSelectedConstructor(type);
            if (constructor == null)
            {
                return;
            }

            foreach (ParameterInfo parameter in constructor.GetParameters())
            {
                ConstructorParameters.Add(CreateParameterViewModel(parameter));
            }
        }

        private void RefreshMethodParameters()
        {
            MethodParameters.Clear();
            UpdateCanExecute();

            Type type = _assemblyLoader.GetTypeByName(_selectedClassName);
            MethodInfo method = FindSelectedMethod(type);
            if (method == null)
            {
                return;
            }

            foreach (ParameterInfo parameter in method.GetParameters())
            {
                MethodParameters.Add(CreateParameterViewModel(parameter));
            }
        }

        private void RefreshObjectProperties()
        {
            ObjectProperties.Clear();

            Type type = _assemblyLoader.GetTypeByName(_selectedClassName);
            if (type == null)
            {
                return;
            }

            HashSet<string> constructorParameterNames = FlyingMachineAssemblyLoader
                .GetConstructors(type)
                .SelectMany(constructor => constructor.GetParameters())
                .Select(parameter => parameter.Name)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            foreach (PropertyInfo property in FlyingMachineAssemblyLoader.GetWritableProperties(type))
            {
                if (constructorParameterNames.Contains(property.Name))
                {
                    continue;
                }

                string defaultValue = GetPropertyDefaultValue(property);
                ObjectProperties.Add(new ParameterViewModel(property.Name, property.PropertyType, defaultValue));
            }
        }

        private void UpdateCanExecute()
        {
            CanExecute = !string.IsNullOrEmpty(_selectedClassName)
                && !string.IsNullOrEmpty(SelectedConstructorSignature)
                && !string.IsNullOrEmpty(SelectedMethodSignature);
        }

        private MethodInfo FindSelectedMethod(Type type)
        {
            if (type == null || string.IsNullOrEmpty(SelectedMethodSignature))
            {
                return null;
            }

            if (_methodDisplayToEnglishName.TryGetValue(SelectedMethodSignature, out string englishMethodName))
            {
                return FlyingMachineAssemblyLoader
                    .GetCallableMethods(type)
                    .FirstOrDefault(method => method.Name == englishMethodName);
            }

            string methodName = ReflectionDisplayNames.ExtractMethodNameFromSignature(SelectedMethodSignature);
            return FlyingMachineAssemblyLoader
                .GetCallableMethods(type)
                .FirstOrDefault(method => method.Name == methodName);
        }

        private ConstructorInfo FindSelectedConstructor(Type type)
        {
            if (type == null || string.IsNullOrEmpty(SelectedConstructorSignature))
            {
                return null;
            }

            if (_constructorDisplayToTechnical.TryGetValue(
                SelectedConstructorSignature,
                out string technicalSignature))
            {
                return FlyingMachineAssemblyLoader
                    .GetConstructors(type)
                    .FirstOrDefault(constructor => BuildTechnicalConstructorSignature(constructor) == technicalSignature);
            }

            return null;
        }

        private static ParameterViewModel CreateParameterViewModel(ParameterInfo parameter)
        {
            string defaultValue = null;

            if (parameter.Name.IndexOf("runway", StringComparison.OrdinalIgnoreCase) >= 0
                && parameter.ParameterType == typeof(int))
            {
                defaultValue = "1000";
            }

            if (parameter.Name.IndexOf("altitude", StringComparison.OrdinalIgnoreCase) >= 0
                && parameter.ParameterType == typeof(int))
            {
                defaultValue = "0";
            }

            return new ParameterViewModel(parameter.Name, parameter.ParameterType, defaultValue);
        }

        private static object[] BuildArguments(IEnumerable<ParameterViewModel> parameters)
        {
            return parameters
                .Select(parameter => ReflectionParameterConverter.ParseValue(parameter.Value, parameter.ParameterType))
                .ToArray();
        }

        private static void ApplyPropertyValues(
            object instance,
            Type type,
            IEnumerable<ParameterViewModel> properties)
        {
            foreach (ParameterViewModel propertyViewModel in properties)
            {
                PropertyInfo property = type.GetProperty(
                    propertyViewModel.Name,
                    BindingFlags.Public | BindingFlags.Instance);

                if (property == null || !property.CanWrite)
                {
                    continue;
                }

                object value = ReflectionParameterConverter.ParseValue(
                    propertyViewModel.Value,
                    property.PropertyType);

                property.SetValue(instance, value);
            }
        }

        private static string GetPropertyDefaultValue(PropertyInfo property)
        {
            if (property.Name.IndexOf("runway", StringComparison.OrdinalIgnoreCase) >= 0
                && property.PropertyType == typeof(int))
            {
                return "1000";
            }

            if (property.PropertyType == typeof(int))
            {
                return "0";
            }

            if (property.PropertyType == typeof(bool))
            {
                return "Ложь";
            }

            return string.Empty;
        }

        private static string BuildTechnicalConstructorSignature(ConstructorInfo constructor)
        {
            string parameters = string.Join(
                ", ",
                constructor.GetParameters().Select(
                    parameter => parameter.ParameterType.Name + " " + parameter.Name));

            return $"{constructor.DeclaringType.Name}({parameters})";
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
