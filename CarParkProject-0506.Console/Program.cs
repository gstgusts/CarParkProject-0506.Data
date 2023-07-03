using CarParkProject_0506.Data;
using CarParkProject_0506.Data.Dto;
using System.Diagnostics;

namespace CarParkProject_0506.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            //var filteredList = vehicles.Where(v => v.Engine.Volume > 1.5);

            var dataStore = new CarParkDataStore();

            var vehicles = dataStore.Load();

            //dataStore.Save(filteredList.ToList(), @"vehicles_with_engine_more_than_15.xml");


            //var onlyBusAndTruck = vehicles.Where(v => v is Bus || v is Truck)
            //    .Select(v => new ExportDto1 { 
            //        Power = v.Engine.Power,
            //        Type = v.Engine.Type,
            //        SerialNumber = v.Engine.SerialNumber,
            //    });

             //var onlyBusAndTruck2 = vehicles.Where(v => v is Bus || v is Truck)
             //   .Select(v => new ExportDto1(v.Engine.Type, v.Engine.Power, v.Engine.SerialNumber));

            //var onlyBusAndTruck2 = vehicles.Where(v => v is Bus || v is Truck)
            //    .Select(v => new                 {
            //        Power = v.Engine.Power,
            //        Type = v.Engine.Type,
            //        SerialNumber = v.Engine.SerialNumber,
            //    });


            //dataStore.Save(onlyBusAndTruck.ToList(), @"car_and_truck_data.xml");

            //foreach (var vehicle in vehicles)
            //{
            //    Console.WriteLine(vehicle.GetDetails());
            //}

            // Console.WriteLine("\n\n\n\n");



            //dataStore.Save(vehicles);

            //var result = dataStore.Load();

            //foreach (var vehicle in result)
            //{
            //    Console.WriteLine(vehicle.GetDetails());
            //}

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