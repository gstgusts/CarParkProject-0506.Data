namespace CarParkProject_0506.Data
{
    [Serializable]
    public class PassengerCar : Vehicle
    {
        public PassengerCar()
        {
            
        }

        public PassengerCar(BuildTypeEnum buildType, Engine engine, Transmission transmission, Chassis chassis)
            : base(engine, transmission, chassis)
        {
            BuildType = buildType;
        }

        public BuildTypeEnum BuildType { get; set; }

        public override string GetDetails()
        {
            return $"BuildType:{BuildType}\n" + base.GetDetails();
        }

        public override bool HasProperty(string name)
        {
            return name == nameof(BuildType) || base.HasProperty(name);
        }

        public override bool IsMatch(string propertyName, string query)
        {
            if (nameof(BuildType) == propertyName)
            {
                return BuildType.ToString() == query;
            }

            return base.IsMatch(propertyName, query);
        }
    }
}
