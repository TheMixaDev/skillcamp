using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZSModule.model
{
    /// <summary>
    /// Данные станции
    /// </summary>
    public class StationData
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public Fueldata[] FuelData { get; set; }
        public class Fueldata
        {
            public string Type { get; set; }
            public float Price { get; set; }
            public int Left { get; set; }
        }

    }
}
