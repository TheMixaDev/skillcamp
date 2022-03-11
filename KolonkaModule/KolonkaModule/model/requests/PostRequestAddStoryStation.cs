using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolonkaModule.model.requests
{
    /// <summary>
    /// Запрос на добавление истории
    /// </summary>
    class PostRequestAddStoryStation
    {
        public int StationId { get; set; }
        public string Fuel { get; set; }
        public int Liters { get; set; }
        public float Price { get; set; }
        public string PaymentMethod { get; set; }
        public int TimeInSeconds { get; set; }
    }
}
