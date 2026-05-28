namespace dotnet2.Model
{
    public class Helicopter : FlyingMachine
    {
        public override bool TakeOff()
        {
            RaiseTakeoffAttempt(true);  // вместо прямого вызова
            Altitude = 500;
            return true;
        }

        public override void Land()
        {
            if (IsFlying)
            {
                Altitude = 0;
                RaiseLanding();  // вместо прямого вызова
            }
        }
    }
}