using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkProject_0506.Data.Dto
{
    public class ExportDto1
    {
        public ExportDto1()
        {
            
        }
        public ExportDto1(EngineTypeEnum typeEnum, int power, string serialNumber)
        {
            Type = typeEnum;
            Power = power;
            SerialNumber = serialNumber;
        }
        public EngineTypeEnum Type { get; set; }
        public int Power { get; set; }
        public string? SerialNumber { get; set; }
    }
}
