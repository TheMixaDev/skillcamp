using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AZSWebApi.Models.SupportModels
{
    /// <summary>
    /// Запрос на возврат средств
    /// </summary>
    public class PostRequestRefundBank
    {
        public string Card { get; set; }
        public int Transaction { get; set; }
        public float Refund { get; set; }
    }
}