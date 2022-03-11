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
    public class ClientController : ApiController
    {
        /// <summary>
        /// Данные клиента
        /// </summary>
        public class ClientData
        {
            int id;
            string cardholder;
            int balance;

            public int Id { get => id; set => id = value; }
            public string Cardholder { get => cardholder; set => cardholder = value; }
            public int Balance { get => balance; set => balance = value; }
        }
        // GET: api/Client
        public IEnumerable<ClientData> Get()
        {
            AZSEntities context = new AZSEntities();
            return context.LoyalityCards.Select(x => new ClientData { Id = x.Id, Cardholder = x.CardHolder, Balance = x.Balance });
        }

        /// <summary>
        /// Получить карты клиента
        /// </summary>
        /// <param name="id">Клиент</param>
        /// <returns>Список кард</returns>
        [Route("api/ClientCard")]
        public IEnumerable<string> GetCard(int id)
        {
            AZSEntities context = new AZSEntities();
            LoyalityCard loyality = context.LoyalityCards.FirstOrDefault(x => x.Id == id);
            if (loyality == null) return new List<string>();
            if(loyality.Cards.Count < 1) return new List<string>();
            return loyality.Cards.Select(x => x.CardNumber);
        }

        /// <summary>
        /// Списать бонусы клиента
        /// </summary>
        /// <param name="value">Тело запроса</param>
        /// <returns>Код операции</returns>
        [Route("api/ClientWithdraw")]
        public IHttpActionResult PostBonuses(PostRequestBonusClient value)
        {
            AZSEntities context = new AZSEntities();
            if (value == null)
            {
                ModelState.AddModelError("Model", "Model is null");
                return BadRequest(ModelState);
            }
            LoyalityCard card = context.LoyalityCards.FirstOrDefault(x => x.Id == value.Id);
            if(card == null)
            {
                return NotFound();
            }
            if(card.Balance < value.Amount)
            {
                ModelState.AddModelError("Model", "Client balance not enougth!");
                return BadRequest(ModelState);
            }
            card.Balance -= value.Amount;
            context.SaveChanges();
            return Ok(card.Balance);
        }
    }
}
