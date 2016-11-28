using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_OOP
{
	class Player
	{
		public int cardSum = 0;
		public int showingSum = 0;
		List<Card> Hand = new List<Card>();

		public Player()
		{
			
		}

		public void ReceiveCard(Card currCard, string receiver, bool hideCard)
		{
			Hand.Add(currCard);
			cardSum += currCard.GetCardValue();
			if (hideCard)
			{
				Console.WriteLine($"{receiver} card #{Hand.Count}: Face Down    - {receiver} showing {showingSum}");
			}
			else
			{
				showingSum += currCard.GetCardValue();
				Console.WriteLine($"{receiver} card #{Hand.Count}: {currCard}    - {receiver} total {cardSum}");
			}


		}
	}
}
