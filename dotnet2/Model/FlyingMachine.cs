using System;

namespace dotnet2.Model
{
    public abstract class FlyingMachine
    {
        private int _altitude;
        public int Altitude
        {
            get => _altitude;
            protected set
            {
                _altitude = value;
                OnAltitudeChanged?.Invoke(this, value);
            }
        }

        public bool IsFlying => Altitude > 0;

        // События
        public event Action<FlyingMachine, int> OnAltitudeChanged;
        public event Action<FlyingMachine, bool> OnTakeoffAttempt;
        public event Action<FlyingMachine> OnLanding;

        // Защищённые методы для вызова событий из наследников
        protected void RaiseTakeoffAttempt(bool success) => OnTakeoffAttempt?.Invoke(this, success);
        protected void RaiseLanding() => OnLanding?.Invoke(this);

        protected FlyingMachine()
        {
            Altitude = 0;
        }

        public abstract bool TakeOff();
        public abstract void Land();

        public virtual string GetInfo() => $"{GetType().Name}: высота {Altitude} м, {(IsFlying ? "в воздухе" : "на земле")}";
    }
}