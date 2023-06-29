namespace CarParkProject_0506.Data
{
    public class PassengerCar : Vehicle
    {
        public BuildTypeEnum BuildType { get; set; }

        public override string GetDetails()
        {
            return $"BuildType:{BuildType}\n" + base.GetDetails();
        }
    }
}
