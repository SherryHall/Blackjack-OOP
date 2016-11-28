using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_OOP
{
	class Program
	{
		static void PatronPlays(Player patron, Shoe currShoe, int showingSum)
		{
			var hitMe = "Y";
			var validAnswer = false;

			Console.WriteLine($"\nYour current total is {patron.cardSum} and the dealer is showing {showingSum}");
			//Player asks for card (hits) until stops or goes over 21
			while (patron.cardSum <= 21 && hitMe == "Y")
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
							patron.ReceiveCard(currShoe.DealACard(), "Patron", false);
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

		static void DealerPlays(Player dealer, Shoe currShoe)
		{
			// *** DEALERS TURN ***
			Console.WriteLine($"\nDealers current total is {dealer.cardSum}.  ");
			while ((dealer.cardSum < 16))
			//while ((dealerSum < 16) || (dealerSum < playerSum))      alternate logic
			{
				Console.WriteLine("Dealer Hits");
				dealer.ReceiveCard(currShoe.DealACard(), "Dealer", false);
			}
		}
		static void Main(string[] args)
		{
			var wantToPlay = true;

			while (wantToPlay)
			{
				Shoe currShoe = new Shoe();
				Player dealer = new Player();
				Player patron = new Player();

				//Initial Deal
				patron.ReceiveCard(currShoe.DealACard(), "Patron", false);
				dealer.ReceiveCard(currShoe.DealACard(), "Dealer", false);
				patron.ReceiveCard(currShoe.DealACard(), "Patron", false);
				dealer.ReceiveCard(currShoe.DealACard(), "Dealer", true);

				if (patron.cardSum == 21)
				{
					Console.WriteLine("\nYou have Blackjack. You win!  Congratulations.\n");
				}
				else
				{
					if (dealer.cardSum == 21)
					{
						Console.WriteLine("\nDealer has Blackjack. You lose!  Sorry.\n");
					}
					else
					{
						// *** PATRONS TURN ***
						PatronPlays(patron, currShoe, dealer.showingSum);
						if (patron.cardSum <= 21)
						{
							// *** DEALERS TURN
							DealerPlays(dealer, currShoe);
						}
						// *** DETERMINE WHO WON ***
						if (patron.cardSum > 21)
						{
							Console.WriteLine("\nYou busted.  You lose!\n");
						}
						else if (dealer.cardSum > 21)
						{
							Console.WriteLine("\nDealer busted.  You win!\n");
						}
						else if (patron.cardSum > dealer.cardSum)
						{
							Console.WriteLine("\nYour hand is higher. You Win!\n");
						}
						else if (patron.cardSum < dealer.cardSum)
						{
							Console.WriteLine("\nDealer hand is higher. You Lose!\n");
						}
						else
						{
							Console.WriteLine("\nYou tied so this is a push. No one wins.\n");
						}

					}
				}
				Console.ReadLine();
			}

		}
	}
}
