using System;
using System.Collections.Generic;
using System.Text;
using Bot.Modules;

namespace Bot.Modules
{
    class CardHand
    {
        public int Points = 0;
        public List<Cards> CardList = new List<Cards>();

        public void addCard(Cards card)
        {
            Points += card.Points;
            CardList.Add(card);
        }
    }
}
