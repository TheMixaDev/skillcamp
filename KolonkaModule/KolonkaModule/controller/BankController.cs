using KolonkaModule.model;
using KolonkaModule.model.requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolonkaModule.controller
{
    /// <summary>
    /// Управление банком
    /// </summary>
    class BankController
    {
        /// <summary>
        /// Проведение оплаты
        /// </summary>
        /// <param name="card">Карта</param>
        /// <param name="client">Клиент</param>
        /// <param name="price">Сумма</param>
        /// <param name="stationId">Станция</param>
        /// <param name="fuelType">Топливо</param>
        /// <param name="litrs">Кол во литров</param>
        /// <returns>Статус проведения</returns>
        public static bool Pay(string card, ClientData client, float price, int stationId, string fuelType, float litrs)
        {
            PostRequestPayBank request = new PostRequestPayBank { Card = card, CardHolder = client.Cardholder, Code = "000", Price = price, Organization = "Тинькофф", StationId = stationId, Session = "MAINKEY", FuelType = fuelType, Litrs = litrs };
            try
            {
                NetworkController.POST(NetworkController.URL + "pay", JsonConvert.SerializeObject(request));
                return true;
            } catch
            {
                return false;
            }
        }
        /// <summary>
        /// Оформление возврата
        /// </summary>
        /// <param name="card">Карта</param>
        /// <param name="refund">Сумма</param>
        /// <returns></returns>
        public static bool Refund(string card, float refund)
        {
            PostRequestRefundBank request = new PostRequestRefundBank { Card = card, Transaction = (new Random()).Next(100000,999999), Refund = refund };
            try
            {
                NetworkController.POST(NetworkController.URL + "refund", JsonConvert.SerializeObject(request));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
