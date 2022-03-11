using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolonkaModule.model.requests
{
    /// <summary>
    /// Запрос на возврат средств
    /// </summary>
    class PostRequestRefundBank
    {
        public string Card { get; set; }
        public int Transaction { get; set; }
        public float Refund { get; set; }
    }
}
