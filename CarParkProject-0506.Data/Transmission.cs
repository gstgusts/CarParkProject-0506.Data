namespace CarParkProject_0506.Data
{
    [Serializable]
    public class Transmission
    {
        public short NumberOfGears { get; set; }

        public string? Manufacturer { get; set; }

        public TransmissionTypeEnum Type { get; set; }

        public override string ToString()
        {
            return $"NumberOfGears:{NumberOfGears}\nManufacturer:{Manufacturer}\nType:{Type}";
        }

        public bool HasProperty(string name)
        {
            return name == nameof(NumberOfGears)
                || name == nameof(Manufacturer)
                || name == nameof(Type);
        }

        public bool IsMatch(string propertyName, string val)
        {
            switch (propertyName)
            {
                case nameof(NumberOfGears):
                    return NumberOfGears.ToString() == val;
                case nameof(Manufacturer):
                    return Manufacturer == val;
                case nameof(Type):
                    return Type.ToString() == val;
                default:
                    return false;
            }
        }
    }
}
