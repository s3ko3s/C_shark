using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using dotnet2.Model;

namespace dotnet2.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private FlyingMachine _currentFlyingMachine;
        private string _selectedType;
        private int _runwayLength = 1200;
        private string _logMessages;

        public string[] AircraftTypes { get; } = { "Самолёт", "Вертолёт" };

        public string SelectedType
        {
            get => _selectedType;
            set
            {
                if (_selectedType != value)
                {
                    _selectedType = value;
                    OnPropertyChanged();
                }
            }
        }

        public int RunwayLength
        {
            get => _runwayLength;
            set
            {
                _runwayLength = value;
                OnPropertyChanged();
                if (_currentFlyingMachine is Airplane airplane)
                    airplane.AvailableRunwayLength = value;
            }
        }

        public string LogMessages
        {
            get => _logMessages;
            set { _logMessages = value; OnPropertyChanged(); }
        }

        public string AircraftInfo => _currentFlyingMachine?.GetInfo() ?? "Не создан";

        public bool CanTakeOff => _currentFlyingMachine != null && !_currentFlyingMachine.IsFlying;
        public bool CanLand => _currentFlyingMachine != null && _currentFlyingMachine.IsFlying;

        public MainViewModel()
        {
            SelectedType = "Самолёт";
        }

        public void CreateAircraft()
        {
            if (SelectedType == "Самолёт")
            {
                var plane = new Airplane(1000);
                plane.AvailableRunwayLength = RunwayLength;
                _currentFlyingMachine = plane;
                SetLog("Самолёт создан");
            }
            else
            {
                _currentFlyingMachine = new Helicopter();
                SetLog("Вертолёт создан");
            }

            _currentFlyingMachine.OnTakeoffAttempt += (ac, success) =>
            {
                string msg = ac is Airplane
                    ? (success ? "Самолёт взлетел" : "Самолёт не смог взлететь (короткая ВПП)")
                    : "Вертолёт взлетел";
                SetLog(msg);
            };

            _currentFlyingMachine.OnLanding += (ac) =>
                SetLog(ac is Airplane ? "Самолёт приземлился" : "Вертолёт приземлился");

            OnPropertyChanged(nameof(CanTakeOff));
            OnPropertyChanged(nameof(CanLand));
        }

        public void TakeOff()
        {
            if (_currentFlyingMachine == null || _currentFlyingMachine.IsFlying) return;
            _currentFlyingMachine.TakeOff();  // событие само выведет сообщение
            OnPropertyChanged(nameof(CanTakeOff));
            OnPropertyChanged(nameof(CanLand));
        }

        public void Land()
        {
            if (_currentFlyingMachine == null || !_currentFlyingMachine.IsFlying) return;
            _currentFlyingMachine.Land();     // событие выведет "приземлился"
            OnPropertyChanged(nameof(CanTakeOff));
            OnPropertyChanged(nameof(CanLand));
        }

        private void SetLog(string message) => LogMessages = message;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}