using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolonkaModule.model.requests
{
    /// <summary>
    /// Запрос на списание бонусов
    /// </summary>
    class PostRequestBonusClient
    {
        public int Id { get; set; }
        public int Amount { get; set; }
    }
}
