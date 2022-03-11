using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AZSWebApi.Models.SupportModels
{
    /// <summary>
    /// Запрос на списание бонусов
    /// </summary>
    public class PostRequestBonusClient
    {
        public int Id { get; set; }
        public int Amount { get; set; }
    }
}