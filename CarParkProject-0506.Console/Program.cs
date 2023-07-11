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

            //var results = carService.GetAutoByParameter<Bus>("Levels", "1");

            //foreach (var result in results)
            //{
            //    Console.WriteLine(result.GetDetails());
            //}

            var results = carService.GetAutoByParameter2("Volume", "250");

            foreach (var result in results)
            {
                Console.WriteLine(result.GetDetails());
                Console.WriteLine("------------");
            }
        }
    }
}