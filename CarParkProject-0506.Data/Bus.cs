namespace CarParkProject_0506.Data
{
    public class Bus : Vehicle
    {
        public short Levels { get; set; }

        public override string GetDetails()
        {
            return $"Levels: {Levels}\n" + base.GetDetails();
        }
    }
}
