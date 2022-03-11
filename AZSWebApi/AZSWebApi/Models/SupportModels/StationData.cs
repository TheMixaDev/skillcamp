using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AZSWebApi.Models.SupportModels
{
    /// <summary>
    /// Данные о станции
    /// </summary>
    public class StationData
    {
        int id;
        string address;
        double price;

        public int Id { get => id; set => id = value; }
        public string Address { get => address; set => address = value; }
        public double Price { get => price; set => price = value; }
    }
}