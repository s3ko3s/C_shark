using System;

namespace dotnet2.Model
{
    public class Airplane : FlyingMachine
    {
        private int _requiredRunwayLength;
        public int RequiredRunwayLength
        {
            get => _requiredRunwayLength;
            set
            {
                if (value <= 0) throw new ArgumentException("Длина ВПП должна быть положительной");
                _requiredRunwayLength = value;
            }
        }

        public int AvailableRunwayLength { get; set; }

        public Airplane(int requiredRunwayLength)
        {
            RequiredRunwayLength = requiredRunwayLength;
            AvailableRunwayLength = requiredRunwayLength;
        }

        public override bool TakeOff()
        {
            bool success = AvailableRunwayLength >= RequiredRunwayLength;
            RaiseTakeoffAttempt(success);  // вместо прямого вызова
            if (success)
                Altitude = 1000;
            return success;
        }

        public override void Land()
        {
            if (IsFlying)
            {
                Altitude = 0;
                RaiseLanding();  // вместо прямого вызова
            }
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", треб. ВПП: {RequiredRunwayLength} м, доступно: {AvailableRunwayLength} м";
        }
    }
}