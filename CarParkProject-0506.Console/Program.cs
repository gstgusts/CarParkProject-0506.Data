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

            var groupedByVehicles = vehicles.GroupBy(a => a.Transmission.Type);

            foreach (var group in groupedByVehicles)
            {
                Console.WriteLine(group.Key);

                foreach (var vehicle in group)
                {
                    Console.WriteLine(vehicle.GetDetails());

                    Debug.WriteLine(group.Key);
                }
            }

        }
    }
}