namespace FlyingMachine.Contracts
{
    /// <summary>
    /// Контракт для летательных аппаратов (задача 2).
    /// </summary>
    public interface IFlyingMachine
    {
        bool IsFlying { get; }

        bool TakeOff();

        void Land();

        string GetInfo();
    }
}
