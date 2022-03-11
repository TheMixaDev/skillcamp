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
    class ClientController
    {
        /// <summary>
        /// Получить данные о клиентах
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Данные о станции</returns>
        public static List<ClientData> GetClients()
        {
            try
            {
                string result = NetworkController.GET(NetworkController.URL + "/api/Client");
                List<ClientData> data = JsonConvert.DeserializeObject<List<ClientData>>(result);
                return data;
            }
            catch
            {
                return new List<ClientData>();
            }
        }

        /// <summary>
        /// Получить карты клиента
        /// </summary>
        /// <param name="client">Клиент</param>
        /// <returns>Номера карт</returns>
        public static List<string> GetCards(int client)
        {
            try
            {
                string result = NetworkController.GET(NetworkController.URL + "/api/ClientCard?id="+client);
                List<string> data = JsonConvert.DeserializeObject<List<string>>(result);
                return data;
            }
            catch
            {
                return new List<string>();
            }
        }

        /// <summary>
        /// Списать бонусы
        /// </summary>
        /// <param name="client">Клиент</param>
        /// <param name="amount">Количество</param>
        /// <returns>Статус операции</returns>
        public static bool TakeBonuses(int client, int amount)
        {
            try
            {
                PostRequestBonusClient request = new PostRequestBonusClient { Id = client, Amount = amount };
                NetworkController.POST(NetworkController.URL + "api/ClientWithdraw", JsonConvert.SerializeObject(request));
                return true;
            } catch
            {
                return false;
            }
        }
    }
}
