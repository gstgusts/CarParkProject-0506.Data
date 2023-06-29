using System.Xml.Serialization;

namespace CarParkProject_0506.Data
{
    [Serializable]
    [XmlInclude(typeof(Bus))]
    [XmlInclude(typeof(PassengerCar))]
    [XmlInclude(typeof(Scooter))]
    [XmlInclude(typeof(Truck))]
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
