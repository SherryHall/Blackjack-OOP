﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_OOP
{
	public enum Suit
	{
		Hearts,
		Clubs,
		Diamonds,
		Spades
	}

	public enum Rank
	{
		Ace,
		Deuce,
		Three,
		Four,
		Five,
		Six,
		Seven,
		Eight,
		Nine,
		Ten,
		Jack,
		Queen,
		King
	}


	public class Card
	{
		public Suit Suit { get; set; }
		public Rank Rank { get; set; }


		public Card(Suit s, Rank r)
		{
			this.Suit = s;
			this.Rank = r;
		}

		public int GetCardValue()
		{
			var rv = 0;
			switch (this.Rank)
			{
				case Rank.Ace:
					rv = 11;
					break;
				case Rank.Deuce:
					rv = 2;
					break;
				case Rank.Three:
					rv = 3;
					break;
				case Rank.Four:
					rv = 4;
					break;
				case Rank.Five:
					rv = 5;
					break;
				case Rank.Six:
					rv = 6;
					break;
				case Rank.Seven:
					rv = 7;
					break;
				case Rank.Eight:
					rv = 8;
					break;
				case Rank.Nine:
					rv = 9;
					break;
				case Rank.Ten:
					rv = 10;
					break;
				case Rank.Jack:
					rv = 10;
					break;
				case Rank.Queen:
					rv = 10;
					break;
				case Rank.King:
					rv = 10;
					break;
				default:
					break;
			}
			return rv;
		}



		public override string ToString()
		{
			return $"The {this.Rank} of {this.Suit}";
		}


		public int DealCard(Card currCard, int sum, string receiver, int count, bool hideCard)
		{

			if (hideCard)
			{
				Console.WriteLine($"{receiver} card #{count}: Face Down    - {receiver} showing {sum}");
				sum += currCard.GetCardValue();
			}
			else
			{
				sum += currCard.GetCardValue();
				Console.WriteLine($"{receiver} card #{count}: {currCard}    - {receiver} total {sum}");
			}
			return sum;
		}
	}
}
