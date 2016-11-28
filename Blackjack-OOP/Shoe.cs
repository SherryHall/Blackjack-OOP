using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_OOP
{
	class Shoe
	{
		List<Card> deck = new List<Card>();
		List<Card> randomDeck = new List<Card>();
		public int cardIndex = 0;

		public Shoe()
		{
			// Create the deck and load in the cards
			foreach (Rank r in Enum.GetValues(typeof(Rank)))
			{
				foreach (Suit s in Enum.GetValues(typeof(Suit)))
				{
					deck.Add(new Card(s, r));
				}
			}
			//Shuffle the Desk
			randomDeck = ShuffleDeck(deck);
		}

		public List<Card> ShuffleDeck(List<Card> deck)
		{
			return deck.OrderBy(x => Guid.NewGuid()).ToList();
		}
		public Card DealACard()
		{
			return randomDeck[cardIndex++];
		}

	}
}
