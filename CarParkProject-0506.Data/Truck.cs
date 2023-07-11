﻿using CarParkProject_0506.Data.Exceptions;

namespace CarParkProject_0506.Data
{
    [Serializable]
    public class Truck : Vehicle
    {
        public Truck()
        {
            
        }

        public Truck(float volume, Engine engine, Transmission transmission, Chassis chassis)
            : base(engine, transmission, chassis)
        {
            if(volume <= 0)
            {
                throw new InitializationException("Volume should be greater than 0");
            }

            Volume = volume;
        }

        public float Volume { get; set; }

        public override string GetDetails()
        {
            return $"Volume:{Volume}" + base.GetDetails();
        }

        public override bool IsValid()
        {
            return Volume > 0 && Volume <= 1000 && base.IsValid();
        }

        public override bool HasProperty(string name)
        {
            return name == nameof(Volume) || base.HasProperty(name);
        }

        public override bool IsMatch(string propertyName, string query)
        {
            if (nameof(Volume) == propertyName)
            {
                return Volume.ToString() == query;
            }

            return base.IsMatch(propertyName, query);
        }
    }
}
