using CarParkProject_0506.Data.Dto;

namespace CarParkProject_0506.Data.Services
{
    public interface ICarParkRepository
    {
        List<Vehicle> Load();

        void Save<T>(List<T> vehicles, string fileName) where T : ISaveItem;

        //List<T> Load<T>(); 

    }
}
