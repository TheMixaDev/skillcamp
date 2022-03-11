using KolonkaModule.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolonkaModule.controller
{
    class StationController
    {

        /// <summary>
        /// Получить данные о станции
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Данные о станции</returns>
        public static StationData GetStation(int id)
        {
            try
            {
                string result = NetworkController.GET(NetworkController.URL + "getStationInfo?id=" + id);
                StationData data = JsonConvert.DeserializeObject<StationData>(result);
                return data;
            }
            catch
            {
                return null;
            }
        }
    }
}
