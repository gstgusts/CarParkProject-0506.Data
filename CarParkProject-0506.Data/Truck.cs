namespace CarParkProject_0506.Data
{
    public class Truck : Vehicle
    {
        public float Volume { get; set; }

        public override string GetDetails()
        {
            return $"Volume:{Volume}" + base.GetDetails();
        }
    }
}
