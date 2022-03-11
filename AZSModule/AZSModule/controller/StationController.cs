using AZSModule.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZSModule.controller
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
            } catch
            {
                return null;
            }
        }
        /// <summary>
        /// Установить данные о станции
        /// </summary>
        /// <param name="station">Станция</param>
        public static void SetStation(StationData station)
        {
            try
            {
                NetworkController.POST(NetworkController.URL + "setStation", JsonConvert.SerializeObject(station));
            }
            catch { }
        }
    }
}
