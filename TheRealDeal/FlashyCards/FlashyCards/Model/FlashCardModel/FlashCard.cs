using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashyCards.Model.FlashCardModel
{
    public class FlashCard
    {
        public int cardID { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
        public string image { get; set; }
        public string tag { get; set; }
    }
}
