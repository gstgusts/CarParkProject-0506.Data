using CarParkProject_0506.Data.Dto;

namespace CarParkProject_0506.Data.Services
{
    public interface ICarParkRepository
    {
        List<Vehicle> Load();

        void Save(List<Vehicle> vehicles, string fileName);

        void Save(List<ExportDto1> vehicles, string fileName);

        void Save(List<ExportDto2> vehicles, string fileName);
    }
}
