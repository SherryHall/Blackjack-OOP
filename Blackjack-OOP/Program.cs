using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_OOP
{
	class Program
	{
		static string DetermineWinner(int patronSum, int dealerSum)
		{
			if (patronSum > 21)
			{
				return "\nYou busted.  You lose!\n";
			}
			else if (dealerSum > 21)
			{
				return "\nDealer busted.  You win!\n";
			}
			else if (patronSum > dealerSum)
			{
				return "\nYour hand is higher. You Win!\n";
			}
			else if (patronSum < dealerSum)
			{
				return "\nDealer hand is higher. You Lose!\n";
			}
			else
			{
				return "\nYou tied so this is a push. No one wins.\n";
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
						patron.PatronPlays(currShoe, dealer.showingSum);
						if (patron.cardSum <= 21)
						{
							// *** DEALERS TURN
							dealer.DealerPlays(currShoe);
						}
						// *** DETERMINE WHO WON ***
						Console.WriteLine(DetermineWinner(patron.cardSum, dealer.cardSum));
					}
				}
				Console.ReadLine();
			}

		}
	}
}
