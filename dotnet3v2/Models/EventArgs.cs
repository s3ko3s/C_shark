using System;

namespace dotnet3v2.Models
{
    public class OverheatEventArgs : EventArgs
    {
        public int Temperature { get; }
        public OverheatEventArgs(int temperature) => Temperature = temperature;
    }

    public class TemperatureChangedEventArgs : EventArgs
    {
        public int NewTemperature { get; }
        public TemperatureChangedEventArgs(int newTemperature) => NewTemperature = newTemperature;
    }

    public class MaterialChangedEventArgs : EventArgs
    {
        public int NewMaterialLevel { get; }
        public MaterialChangedEventArgs(int newMaterialLevel) => NewMaterialLevel = newMaterialLevel;
    }
}