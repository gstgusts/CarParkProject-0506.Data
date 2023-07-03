using CarParkProject_0506.Data;
using CarParkProject_0506.Data.Dto;
using CarParkProject_0506.Data.Services;
using System.Diagnostics;

namespace CarParkProject_0506.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var carService = new CarParkService(new CarParkDataStore());

            var vehicles = carService.GetAllVehicles();

            //var result = carService.GetBusAndTrucks();

            //carService.Save(result, "test.xml");

            var result2 = carService.GetVehiclesGroupByTransmission();

            var vehicles2 = result2.Select(a => new ExportDto2()
            {
                Key = a.Key,
                Items = a.ToList()
            });

            carService.Save(vehicles2.ToList(), "groupedby.xml");
        }
    }
}