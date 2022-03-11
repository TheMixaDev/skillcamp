using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AZSWebApi.Models.SupportModels
{
    /// <summary>
    /// Добавление истории использования колонки
    /// </summary>
    public class PostRequestAddStoryStation
    {
        public int StationId { get; set; }
        public string Fuel { get; set; }
        public int Liters { get; set; }
        public float Price { get; set; }
        public string PaymentMethod { get; set; }
        public int TimeInSeconds { get; set; }
    }
}