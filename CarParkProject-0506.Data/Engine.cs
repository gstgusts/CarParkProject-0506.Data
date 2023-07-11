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

        public bool HasProperty(string name)
        {
            return name == nameof(Power)
                || name == nameof(Volume)
                || name == nameof(Type)
                || name == nameof(SerialNumber);
        }

        public bool IsMatch(string propertyName, string val)
        {
            switch (propertyName)
            {
                case nameof(Power):
                    return Power.ToString() == val;
                case nameof(Volume):
                    return Volume.ToString() == val;
                case nameof(Type):
                    return Type.ToString() == val;
                case nameof(SerialNumber):
                    return SerialNumber == val;
                    default:
                    return false;
            }
        }
    }
}