using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashyCards.Model.FlashCardModel
{
    public class FlashCard
    {
        public int userID { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
        public string images { get; set; }
    }
}
