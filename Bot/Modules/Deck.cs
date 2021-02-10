using System;
using System.Collections.Generic;
using System.Text;
using Bot.Modules;

namespace Bot.Modules
{
    class Deck
    {
        public List<Cards> CardList = new List<Cards>(); //making a card list (can only be edited from methods)

        //method for initialising a deck
        public void initializeDeck()
        {
            Cards card = new Cards();
            CardList = new List<Cards>();
            
            for(int i = 1; i <= 13; i++)
            {
                for(int j = 1; j <= 4; j++)
                {
                    card = new Cards();
                    //checking if it's an ace
                    if (i == 1)
                    {
                        card.Points = 10;
                        card.Number = "Ace";
                    }
                    //checking it it's a number
                    if (i > 1 && i <= 10)
                    {
                        card.Points = i;
                        card.Number = i.ToString();
                    }
                    //checking if it's a jack
                    if (i == 11)
                    {
                        card.Points = 10;
                        card.Number = "Jack";
                    }
                    //checking if it's a queen
                    if (i == 12)
                    {
                        card.Points = 10;
                        card.Number = "Queen";
                    }
                    //checking if it's a king
                    if (i == 13)
                    {
                        card.Points = 10;
                        card.Number = "King";
                    }
                    if (j == 1)
                    {
                        card.Suit = "Clubs";
                        CardList.Add(card);
                    }
                    if (j == 2)
                    {
                        card.Suit = "Diamonds";
                        CardList.Add(card);
                    }
                    if (j == 3)
                    {
                        card.Suit = "Hearts";
                        CardList.Add(card);
                    }
                    if (j == 4)
                    {
                        card.Suit = "Spades";
                        CardList.Add(card);
                    }
                }
            }
        }

        //method for shuffling a deck
        public void shuffle()
        {
            List<Cards> newList = new List<Cards>(); //setting a new list
            Random rnd = new Random();

            while(CardList.Count > 1)
            {
                int cardIndex = rnd.Next(1, CardList.Count);
                newList.Add(CardList[cardIndex]);
                CardList.RemoveAt(cardIndex);
            }
            newList.Add(CardList[0]); //adding the last card as well
            CardList = newList;
        }

        public Cards draw()
        {
            Cards card = new Cards();
            card = CardList[CardList.Count - 1];//saving last card
            CardList.RemoveAt(CardList.Count - 1);
            return card;
        }
    }
}
