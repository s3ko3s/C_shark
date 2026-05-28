using System;

namespace FlyingMachine.Library
{
    public class Airplane : FlyingMachine
    {
        private int _requiredRunwayLength;

        public int RequiredRunwayLength
        {
            get => _requiredRunwayLength;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Длина ВПП должна быть положительной");
                }

                _requiredRunwayLength = value;
            }
        }

        public int AvailableRunwayLength { get; set; }

        public Airplane(int requiredRunwayLength, int initialAltitude)
            : base(initialAltitude)
        {
            RequiredRunwayLength = requiredRunwayLength;
        }

        public override bool TakeOff()
        {
            bool success = AvailableRunwayLength >= RequiredRunwayLength;
            RaiseTakeoffAttempt(success);
            if (success)
            {
                Altitude = 1000;
            }

            return success;
        }

        public override void Land()
        {
            if (!IsFlying)
            {
                return;
            }

            Altitude = 0;
            RaiseLanding();
        }

        public override string GetInfo() =>
            base.GetInfo() +
            $", треб. ВПП: {RequiredRunwayLength} м, доступно: {AvailableRunwayLength} м";
    }
}
