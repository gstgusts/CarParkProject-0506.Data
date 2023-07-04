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

    }
}
