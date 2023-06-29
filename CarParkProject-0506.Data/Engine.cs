namespace CarParkProject_0506.Data
{
    [Serializable]
    public class Engine
    {
        public int Power { get; set; }

        public float Volume { get; set; }

        public EngineTypeEnum Type { get; set; }

        public string? SerialNumber { get; set; }

        public override string ToString()
        {
            return $"Power:{Power}\nVolume:{Volume}\nType:{Type}\nSerialNumber:{SerialNumber}";
        }
    }
}