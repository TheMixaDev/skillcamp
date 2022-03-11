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

        /// <summary>
        /// Добавить использование колонки в историю
        /// </summary>
        /// <param name="stationId">Станция</param>
        /// <param name="fuel">Топливо</param>
        /// <param name="liters">Литры</param>
        /// <param name="price">Цена</param>
        public static void AddStory(int stationId, string fuel, int liters, float price)
        {
            PostRequestAddStoryStation request = new PostRequestAddStoryStation { StationId = stationId, Fuel = fuel, Liters = liters, Price = price, PaymentMethod = "debit card", TimeInSeconds = (int)Math.Round((float)liters / 100f) };
            try
            {
                NetworkController.POST(NetworkController.URL + "addStory", JsonConvert.SerializeObject(request));
            }
            catch { }
        }
    }
}
