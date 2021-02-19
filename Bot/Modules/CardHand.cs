using System;
using System.Collections.Generic;
using System.Text;
using Bot.Modules;

namespace Bot.Modules
{
    class CardHand
    {
        public int Points { get; set; }
        public List<Cards> CardList { get; set; }
        public string Owner { get; set; }

        public void addCard(Cards card)
        {
            Points += card.Points;
            CardList.Add(card);
        }
    }
}
