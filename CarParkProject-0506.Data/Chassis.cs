namespace CarParkProject_0506.Data
{
    [Serializable]
    public class Chassis
    {
        public ushort NumberOfWheels { get; set; }

        public string? Number { get; set; }

        public float PermissibleLoad { get; set; }

        public override string ToString()
        {
            return $"NumberOfWheels:{NumberOfWheels}\nNumber:{Number}\nPermissibleLoad:{PermissibleLoad}";
        }

        public bool HasProperty(string name)
        {
            return name == nameof(NumberOfWheels)
                || name == nameof(Number)
                || name == nameof(PermissibleLoad);
        }

        public bool IsMatch(string propertyName, string val)
        {
            switch (propertyName)
            {
                case nameof(NumberOfWheels):
                    return NumberOfWheels.ToString() == val;
                case nameof(Number):
                    return Number == val;
                case nameof(PermissibleLoad):
                    return PermissibleLoad.ToString() == val;
                default:
                    return false;
            }
        }
    }
}
