using CarParkProject_0506.Data.Dto;
using CarParkProject_0506.Data.Exceptions;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarParkProject_0506.Data.Services
{
    public class CarParkService
    {
        private const string AllVehiclesFilePath = "all.xml";

        private readonly ICarParkRepository _carParkRepository;

        private List<Vehicle> _vehicles = new List<Vehicle>();

        private Dictionary<string, string> _fieldMapping;

        public CarParkService(ICarParkRepository carParkRepository)
        {
            _carParkRepository = carParkRepository;
            _vehicles = _carParkRepository.Load();

            _fieldMapping = new Dictionary<string, string>
            {
                { "Engine.Power", "e.Power" },
                { "Engine.Volume", "e.Volume" }
            };
        }

        public IEnumerable<Vehicle> Vehicles { 
            get {
                if(!_vehicles.Any())
                {
                    _vehicles = _carParkRepository.Load();
                }
                return _vehicles;
            } 
        }

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return Vehicles;
        }

        public IEnumerable<Vehicle> GetVehiclesWithEngineMoreThan(double engineVolume = 1.5) 
        {  
           return Vehicles.Where(v => v.Engine.Volume > engineVolume);
        }

        public IEnumerable<ExportDto1> GetBusAndTrucks()
        {
            return Vehicles.Where(v => v is Bus || v is Truck)
                .Select(v => new ExportDto1(v.Engine.Type, v.Engine.Power, v.Engine.SerialNumber));
        }

        public IEnumerable<IGrouping<TransmissionTypeEnum, Vehicle>> GetVehiclesGroupByTransmission()
        {
            return Vehicles.GroupBy(a => a.Transmission.Type);
        }

        public void Save()
        {
            _carParkRepository.Save(_vehicles, AllVehiclesFilePath);
        }

        public void Save<T>(List<T> data, string path) where T : ISaveItem
        {
            _carParkRepository.Save(data.ToList(), path);
        }

        public void AddVehicle(Vehicle vehicle)
        {
            if(vehicle == null || !vehicle.IsValid())
            {
                throw new AddException();
            }

            _vehicles.Add(vehicle);

            _carParkRepository.Save(_vehicles, AllVehiclesFilePath);
        }

        public IEnumerable<Vehicle> GetAutoByParameter(string propertyName, string value)
        {
            if(!_fieldMapping.ContainsKey(propertyName))
            {
                throw new GetAutoByParameterException(propertyName);
            }

            var sqlQuery = "SELECT * FROM Vehicle v WHERE 1=1 ";

            sqlQuery = $"AND {_fieldMapping[propertyName]}={value}";

            //exexc query

            //Type engineType = typeof(Engine);
            //Type transmissionType = typeof(Transmission);
            //Type chassisType = typeof(Chassis);

            //PropertyInfo propertyInfo1 = engineType.GetProperty(propertyName);
            //PropertyInfo propertyInfo2 = transmissionType.GetProperty(propertyName);
            //PropertyInfo propertyInfo3 = chassisType.GetProperty(propertyName);

            //if (propertyInfo1 == null && propertyInfo2 == null && propertyInfo3 == null)
            //{
            //    throw new GetAutoByParameterException(propertyName);
            //}

            //var propertiesByName = new List<PropertyInfo>();

            //AddProperty(propertyInfo1, propertiesByName);
            //AddProperty(propertyInfo2, propertiesByName);
            //AddProperty(propertyInfo3, propertiesByName);

            ////foreach (var item in _vehicles)
            ////{
            ////    //var val = propertyInfo.GetValue(item, null);
            ////}

            return new List<Vehicle> { };
        }

        public IEnumerable<Vehicle> GetAutoByParameter<T>(string propertyName, string paramValue) where T : class
        {
            Type paramType = typeof(T);
            PropertyInfo propertyInfo = paramType.GetProperty(propertyName);

            if (propertyInfo == null)
            {
                throw new GetAutoByParameterException(propertyName);
            }

            var results = new List<Vehicle>();

            foreach (var item in _vehicles)
            {
                object val = null;

                switch (paramType.FullName)
                {
                    case "CarParkProject_0506.Data.Chassis":
                        val = propertyInfo.GetValue(item.Chassis, null);
                        break;
                    case "CarParkProject_0506.Data.Engine":
                        val = propertyInfo.GetValue(item.Engine, null);
                        break;
                    case "CarParkProject_0506.Data.Transmission":
                        val = propertyInfo.GetValue(item.Transmission, null);
                        break;
                    default:
                        if(item is T)
                        {
                            val = propertyInfo.GetValue(item, null);
                        }
                        break;
                }

                if (val != null && val.ToString() == paramValue)
                {
                    results.Add(item);
                    continue;
                }
            }

            return results;
        }

        public IEnumerable<Vehicle> GetAutoByParameter2(string propertyName, string paramValue)
        {
            var hasProperty = _vehicles.Any(v => v.HasProperty(propertyName));

            if (!hasProperty)
            {
                throw new GetAutoByParameterException(propertyName);
            }

            return _vehicles.Where(v => v.IsMatch(propertyName, paramValue));
        }

        private static void AddProperty(PropertyInfo? propertyInfo, List<PropertyInfo> propertiesByName)
        {
            if (propertyInfo != null)
            {
                propertiesByName.Add(propertyInfo);
            }
        }
    }
}
