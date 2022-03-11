﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AZSWebApi.Models.SupportModels
{
    /// <summary>
    /// Запрос на списание с карты
    /// </summary>
    public class PostRequestPayBank
    {
        public string Card { get; set; }
        public string CardHolder { get; set; }
        public string Code { get; set; }
        public float Price { get; set; }
        public string Organization { get; set; }
        public int StationId { get; set; }
        public string Session { get; set; }
        public string FuelType { get; set; }
        public float Litrs { get; set; }
    }
}