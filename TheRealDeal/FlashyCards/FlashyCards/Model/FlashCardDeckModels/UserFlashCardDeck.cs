using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashyCards.Model.FlashCardDeckModels
{
    public class UserFlashCardDeck
    {
        public string deckName { get; set; }
        public string isOpen { get; set; }
        public int category_id { get; set; }
        public int person_id { get; set; }
        public bool isSharing
        {
            get
            {
                return isOpen == "on";
            }
            set
            {
                
            }
        }
    }
}
