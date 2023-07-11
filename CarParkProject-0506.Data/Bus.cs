using CarParkProject_0506.Data.Exceptions;

namespace CarParkProject_0506.Data
{
    [Serializable]
    public class Bus : Vehicle
    {
        public Bus()
        {
            
        }

        public Bus(short levels, Engine engine, Transmission transmission, Chassis chassis)
            : base(engine, transmission, chassis)
        {
            if(levels <= 0)
            {
                throw new InitializationException("You should indicate value for levels");
            }

            Levels = levels;
        }

        public short Levels { get; set; }

        public override string GetDetails()
        {
            return $"Levels: {Levels}\n" + base.GetDetails();
        }

        public override bool IsValid()
        {
            return Levels > 0 && Levels <= 2 && base.IsValid();
        }

        public override bool HasProperty(string name)
        {
            return name == nameof(Levels) || base.HasProperty(name);
        }

        public override bool IsMatch(string propertyName, string query)
        {
            if(nameof(Levels) == propertyName)
            {
                return Levels.ToString() == query;
            }

            return base.IsMatch(propertyName, query);
        }
    }
}
