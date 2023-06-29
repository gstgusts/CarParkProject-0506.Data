namespace CarParkProject_0506.Data
{
    public class Engine
    {
        public int Power { get; set; }

        public int Volume { get; set; }

        public EngineTypeEnum Type { get; set; }

        public string? SerialNumber { get; set; }

        public override string ToString()
        {
            return $"Power:{Power}\nVolume:{Volume}\nType:{Type}\nSerialNumber:{SerialNumber}";
        }
    }
}