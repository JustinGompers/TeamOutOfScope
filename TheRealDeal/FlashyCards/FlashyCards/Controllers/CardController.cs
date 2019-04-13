using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlashyCards.DAL.FlashCardDAL;
using FlashyCards.Model.FlashCardModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlashyCards.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private CardOptionsDAL Dal;
        public CardController(CardOptionsDAL Dal)
        {
            this.Dal = Dal;

        }

        // GET: api/Card/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Card
        [HttpPost]
        public ActionResult InsertCard([FromBody] FlashCard flashCard)
        {
            Dal.createCard(flashCard);
            return CreatedAtRoute("Get", new { Id = flashCard.cardID }, flashCard);
        }

        // PUT: api/Card/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
