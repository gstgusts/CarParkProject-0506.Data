using CarParkProject_0506.Data.Exceptions;
using CarParkProject_0506.Data.Services;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CarParkProject_0506.Data
{
    [Serializable]
    [XmlInclude(typeof(Bus))]
    [XmlInclude(typeof(PassengerCar))]
    [XmlInclude(typeof(Scooter))]
    [XmlInclude(typeof(Truck))]
    public class Vehicle : ISaveItem
    {
        public Vehicle() { }

        public Vehicle(Engine engine, Transmission transmission, Chassis chassis)
        {
            if (engine == null || transmission == null || chassis == null)
            {
                throw new InitializationException();
            }

            Engine = engine;
            Transmission = transmission;
            Chassis = chassis;
        }

        public Engine Engine { get; set; }
        public Transmission Transmission { get; set; }
        public Chassis Chassis { get; set; }

        public virtual string  GetDetails()
        {
            return $"{Engine} {Transmission} {Chassis}";
        }

        public virtual bool IsValid()
        {
            return true;
        }

        public virtual bool HasProperty(string name)
        {
            return Engine.HasProperty(name) 
                || Chassis.HasProperty(name)
                || Transmission.HasProperty(name);
        }

        public virtual bool IsMatch(string propertyName, string query)
        {
            return Engine.IsMatch(propertyName, query)
                || Chassis.IsMatch(propertyName, query)
                || Transmission.IsMatch(propertyName, query);
        }
    }
}
