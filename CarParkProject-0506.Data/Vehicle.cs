namespace CarParkProject_0506.Data
{
    public class Vehicle
    {
        public Engine Engine { get; set; }
        public Transmission Transmission { get; set; }
        public Chassis Chassis { get; set; }

        public virtual string  GetDetails()
        {
            return $"{Engine} {Transmission} {Chassis}";
        }
    }
}
