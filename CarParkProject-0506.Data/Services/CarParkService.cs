using CarParkProject_0506.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkProject_0506.Data.Services
{
    public class CarParkService
    {
        private const string AllVehiclesFilePath = "all.xml";

        private readonly ICarParkRepository _carParkRepository;

        private List<Vehicle> _vehicles = new List<Vehicle>();

        public CarParkService(ICarParkRepository carParkRepository)
        {
            _carParkRepository = carParkRepository;
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

        public void Save(IEnumerable<ExportDto1> data, string path)
        {
            _carParkRepository.Save(data.ToList(), path);
        }

        public void Save(List<ExportDto2> data, string path)
        {
            _carParkRepository.Save(data, path);
        }
    }
}
