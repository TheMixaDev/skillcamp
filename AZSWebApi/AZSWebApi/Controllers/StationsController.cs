using AZSWebApi.Models;
using AZSWebApi.Models.SupportModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AZSWebApi.Controllers
{
    public class StationsController : ApiController
    {

        /// <summary>
        /// Запрос на установку станции
        /// </summary>
        /// <param name="value">Объект станции</param>
        /// <returns>Результат</returns>
        [Route("setStation")]
        public IHttpActionResult Post(PostRequestSetStation value)
        {
            AZSEntities context = new AZSEntities();
            if (value == null)
            {
                ModelState.AddModelError("Model", "Model is null");
                return BadRequest(ModelState);
            }
            GasStation station = context.GasStations.FirstOrDefault(x => x.Id == value.Id);
            if (station == null)
            {
                station = new GasStation { Id = value.Id, Address = value.Address };
                context.GasStations.Add(station);
            }
            station.Address = value.Address;
            foreach (PostRequestSetStation.Fueldata fueldata in value.FuelData)
            {
                StationFuel stationFuel = context.StationFuels.FirstOrDefault(x => x.GasStationId == station.Id && x.FuelTypeId == fueldata.Type);
                if (stationFuel == null)
                {
                    stationFuel = new StationFuel { GasStation = station, FuelTypeId = fueldata.Type, Price = fueldata.Price, AmountOfFuel = fueldata.Left };
                    context.StationFuels.Add(stationFuel);
                }
                stationFuel.Price = fueldata.Price;
                stationFuel.AmountOfFuel = fueldata.Left;
            }
            context.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Получить станции по типу топлива
        /// </summary>
        /// <param name="fuel">Топливо</param>
        /// <returns>Данные о станции</returns>
        [Route("stations")]
        public List<StationData> GetStation(string fuel)
        {
            AZSEntities context = new AZSEntities();
            return context.StationFuels.Where(x => x.FuelTypeId == fuel).Select(x => new StationData { Id = x.GasStationId, Address = x.GasStation.Address, Price = x.Price }).ToList();
        }

        /// <summary>
        /// Получить информацию по станции
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Объект, приемлемый для установки станции</returns>
        [Route("getStationInfo")]
        public PostRequestSetStation GetStationInfo(int id)
        {
            try
            {
                AZSEntities context = new AZSEntities();
                GasStation station = context.GasStations.FirstOrDefault(x => x.Id == id);
                List<PostRequestSetStation.Fueldata> fueldatas = new List<PostRequestSetStation.Fueldata>();
                foreach (StationFuel fuel in context.StationFuels.Where(x => x.GasStationId == station.Id))
                {
                    PostRequestSetStation.Fueldata fueldata = new PostRequestSetStation.Fueldata { Type = fuel.FuelTypeId, Price = (float)fuel.Price, Left = fuel.AmountOfFuel };
                    fueldatas.Add(fueldata);
                }
                return new PostRequestSetStation { Id = station.Id, Address = station.Address, FuelData = fueldatas.ToArray() };
            } catch
            {
                return null;
            }
        }

        /// <summary>
        /// Добавить историю использования колонки
        /// </summary>
        /// <param name="value">Тело запроса</param>
        /// <returns>Код ответа</returns>
        [Route("addStory")]
        public IHttpActionResult PostStory(PostRequestAddStoryStation value)
        {
            AZSEntities context = new AZSEntities();
            if (value == null)
            {
                ModelState.AddModelError("Model", "Model is null");
                return BadRequest(ModelState);
            }
            GasStation station = context.GasStations.FirstOrDefault(x => x.Id == value.StationId);
            if (station == null)
            {
                ModelState.AddModelError("Model", "Unknown station");
                return BadRequest(ModelState);
            }
            GasStationLog log = new GasStationLog {
                Date = DateTime.Now.ToString("yyyy-MM-dd") + "T" + DateTime.Now.ToString("hh:mm:ss"),
                GasStation = station,
                FuelType = value.Fuel,
                LitersCount = value.Liters,
                Price = value.Price,
                PaymentMethod = value.PaymentMethod,
                TimeInSecods = value.TimeInSeconds
            };
            context.GasStationLogs.Add(log);
            context.SaveChanges();
            return Ok();
        }
    }
}
