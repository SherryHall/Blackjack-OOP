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
		public void DealerPlays(Shoe currShoe)
		{
			// *** DEALERS TURN ***
			Console.WriteLine($"\nDealers current total is {this.cardSum}.  ");
			while ((this.cardSum < 16))
			//while ((dealerSum < 16) || (dealerSum < playerSum))      alternate logic
			{
				Console.WriteLine("Dealer Hits");
				this.ReceiveCard(currShoe.DealACard(), "Dealer", false);
			}
		}
		public void PatronPlays(Shoe currShoe, int showingSum)
		{
			var hitMe = "Y";
			var validAnswer = false;

			Console.WriteLine($"\nYour current total is {this.cardSum} and the dealer is showing {showingSum}");
			//Player asks for card (hits) until stops or goes over 21
			while (this.cardSum <= 21 && hitMe == "Y")
			{
				do
				// Ask player if he wants to hit until you get a valid answer
				{
					Console.Write("Do you want to hit?  (Y/N)  ");
					hitMe = Console.ReadLine().ToUpper();
					switch (hitMe[0])
					{
						case 'Y':
							validAnswer = true;
							this.ReceiveCard(currShoe.DealACard(), "Patron", false);
							break;

						case 'N':
							validAnswer = true;
							break;
						default:
							Console.WriteLine("Invalid answer. Try again.");
							validAnswer = false;
							break;
					}
				}
				while (!validAnswer);
			}
		}
	}
}
