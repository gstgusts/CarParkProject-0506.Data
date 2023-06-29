using CarParkProject_0506.Data;
using CarParkProject_0506.Data.Dto;

namespace CarParkProject_0506.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bus = new Bus
            {
                Levels = 1,
                Chassis = new Chassis
                {
                    NumberOfWheels = 4,
                    PermissibleLoad = 45,
                    Number = "a13213542345"
                },
                Engine = new Engine
                {
                    Volume = 250,
                    Power = 200,
                    SerialNumber = "23464356gsdfg",
                    Type = EngineTypeEnum.Diesel
                },
                Transmission = new Transmission
                {
                    Manufacturer = "Toyota",
                    NumberOfGears = 7,
                    Type = TransmissionTypeEnum.Manual
                }
            };

            var car = new PassengerCar
            {
                BuildType = BuildTypeEnum.Sedan,
                Chassis = new Chassis
                {
                    NumberOfWheels = 4,
                    PermissibleLoad = 200,
                    Number = "2345sdfgsdgf"
                },
                Engine = new Engine
                {
                    Volume = 250,
                    Power = 200,
                    SerialNumber = "568745876",
                    Type = EngineTypeEnum.Eletric
                },
                Transmission = new Transmission
                {
                    Manufacturer = "Bmw",
                    NumberOfGears = 7,
                    Type = TransmissionTypeEnum.Auto
                }
            };

            var vehicles = new List<Vehicle> { bus, car };


            var filteredList = vehicles.Where(v => v.Engine.Volume > 1.5);

            var dataStore = new CarParkDataStore();

            //dataStore.Save(filteredList.ToList(), @"vehicles_with_engine_more_than_15.xml");


            var onlyBusAndTruck = vehicles.Where(v => v is Bus || v is Truck)
                .Select(v => new ExportDto1 { 
                    Power = v.Engine.Power,
                    Type = v.Engine.Type,
                    SerialNumber = v.Engine.SerialNumber,
                });

             var onlyBusAndTruck2 = vehicles.Where(v => v is Bus || v is Truck)
                .Select(v => new ExportDto1(v.Engine.Type, v.Engine.Power, v.Engine.SerialNumber));

            //var onlyBusAndTruck2 = vehicles.Where(v => v is Bus || v is Truck)
            //    .Select(v => new                 {
            //        Power = v.Engine.Power,
            //        Type = v.Engine.Type,
            //        SerialNumber = v.Engine.SerialNumber,
            //    });


            dataStore.Save(onlyBusAndTruck.ToList(), @"car_and_truck_data.xml");

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

        }
    }
}