namespace CarParkProject_0506.Data.Dto
{
    public class ExportDto2
    {
        public TransmissionTypeEnum Key { get; set; }

        public List<Vehicle> Items { get; set; } = new List<Vehicle>();
    }
}
