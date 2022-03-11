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
    public class BankController : ApiController
    {
        /// <summary>
        /// Проведение оплаты
        /// </summary>
        /// <param name="value">Тело запроса</param>
        /// <returns>Код ответа</returns>
        [Route("pay")]
        public IHttpActionResult Post(PostRequestPayBank value)
        {
            AZSEntities context = new AZSEntities();
            if (value == null)
            {
                ModelState.AddModelError("Model", "Model is null");
                return BadRequest(ModelState);
            }
            Card card = context.Cards.FirstOrDefault(x => x.CardNumber == value.Card);
            if(card == null)
            {
                ModelState.AddModelError("Model", "Unknown card");
                return BadRequest(ModelState);
            }
            int price = (int)Math.Floor(value.Price);
            if (card.Balance < price)
            {
                ModelState.AddModelError("Model", "Not enough balance");
                return NotFound();
            }
            card.Balance -= price;
            Pay pay = new Pay { CardNumber = value.Card, CardHolderId = card.CardHolderId, Code = value.Code, OrganisationName = value.Organization, StationId = value.StationId, Token = value.Session};
            //Integrated with adding purchase and loyality card balance
            LoyalityCard loyalityCard = context.LoyalityCards.FirstOrDefault(x => x.Id == card.CardHolderId);
            if (loyalityCard != null)
                loyalityCard.Balance += (int)Math.Floor(value.Price*0.03);
            Purchase purchase = new Purchase { CardHolderId = card.CardHolderId, PurchaseDate = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), GasStationId = value.StationId, FuelType = value.FuelType, Value = (int)Math.Floor(value.Litrs), Cost = price, PaymentType = "debit card"};
            context.SaveChanges();
            return Ok(card.Balance);
        }

        /// <summary>
        /// Произвести возврат средств
        /// </summary>
        /// <param name="value">Тело запроса</param>
        /// <returns>Код ответа</returns>
        [Route("refund")]
        public IHttpActionResult PostRefund(PostRequestRefundBank value)
        {
            AZSEntities context = new AZSEntities();
            if (value == null)
            {
                ModelState.AddModelError("Model", "Model is null");
                return BadRequest(ModelState);
            }
            Card card = context.Cards.FirstOrDefault(x => x.CardNumber == value.Card);
            if (card == null)
            {
                ModelState.AddModelError("Model", "Unknown card");
                return BadRequest(ModelState);
            }
            int price = (int)Math.Floor(value.Refund);
            card.Balance += price;
            Refund refund = new Refund { Card = value.Card, Value = price };
            context.SaveChanges();
            return Ok(card.Balance);
        }
    }
}
