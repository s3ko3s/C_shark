namespace FlyingMachine.Library
{
    public class Helicopter : FlyingMachine
    {
        public Helicopter(int initialAltitude)
            : base(initialAltitude)
        {
        }

        public override bool TakeOff()
        {
            RaiseTakeoffAttempt(true);
            Altitude = 500;
            return true;
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
    }
}
