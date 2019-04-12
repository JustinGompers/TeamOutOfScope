using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlashyCards.DAL.FlashCardDeckDAL;
using FlashyCards.Model.FlashCardDeckModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlashyCards.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class DeckController : ControllerBase
    {
        private DeckOptionsDAL deckOptionsDAL;
        public DeckController(DeckOptionsDAL deckOptionsDAL)
        {
            this.deckOptionsDAL = deckOptionsDAL;
        }

        //Returns List of Categories Get API(url = api/Deck)
        [HttpGet(Name = "GetCategoriesList")]
        public ActionResult<List<Category>> GetCategoriesList()
        {
            List<Category> categories = deckOptionsDAL.GetCategoryList();
            if (categories != null)
            {
                return categories;
            }
            return NotFound();
        }
    }
}