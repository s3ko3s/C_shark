using System;
using FlyingMachine.Contracts;

namespace FlyingMachine.Library
{
    public abstract class FlyingMachine : IFlyingMachine
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

        public event Action<FlyingMachine, int> OnAltitudeChanged;
        public event Action<FlyingMachine, bool> OnTakeoffAttempt;
        public event Action<FlyingMachine> OnLanding;

        protected void RaiseTakeoffAttempt(bool success) => OnTakeoffAttempt?.Invoke(this, success);

        protected void RaiseLanding() => OnLanding?.Invoke(this);

        protected FlyingMachine(int initialAltitude)
        {
            Altitude = initialAltitude;
        }

        public abstract bool TakeOff();

        public abstract void Land();

        public virtual string GetInfo() =>
            $"{GetType().Name}: высота {Altitude} м, {(IsFlying ? "в воздухе" : "на земле")}";
    }
}
