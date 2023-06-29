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
    }
}
