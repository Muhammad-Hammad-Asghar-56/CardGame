using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame.BL;
using CardGame.UI;
namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            deck deckCard = new deck();
            int option;
            bool gameStart = false;
            //                         Shall we Start game
            while (true)
            {
                option = menus.mainmenu();
                if (option == 1) { gameStart = true; break; }
            }

            card PlayerCard = deckCard.dealCard();
            players P1 = new players(PlayerCard);
            card nextCard = new card();
            //                         Starts game
            bool IsWin = false;
            while (gameStart)
            {

                playersUI.displayGameStatus(P1.getCard(), deckCard.totalRemaningCardLeft());
                int Playeroption = menus.PlayerPrediction();
                deckCard.suffleDeck();
                nextCard = deckCard.dealCard();
                if (Playeroption == 1)
                {
                    if (card.isHigher(P1.getCard(), nextCard))
                    {
                        P1.incrementInScoring();
                        P1.setCard(nextCard);
                    }
                    else
                    {
                        IsWin = false;
                        break;
                    }
                }
                if (Playeroption == 2)
                {
                    if (!card.isHigher(P1.getCard(), nextCard))
                    {
                        P1.incrementInScoring();
                        P1.setCard(nextCard);
                    }
                    else
                    {
                        IsWin = false;
                        break;
                    }
                }
                if (deckCard.totalRemaningCardLeft() == 0)
                {
                    IsWin = true;
                }
            }
            //                                Results
            if (IsWin)
            {
                Console.WriteLine("You Win the match");
            }
            if (IsWin)
            {
                Console.WriteLine("You lose the match game ");
                Console.WriteLine("The previous card is {0} and next is {1}", P1.getCard().getStringOfCard(), nextCard.getStringOfCard());
                Console.Write("The Score is {0}", P1.getScore());
            }
            Console.ReadKey();
        }
    }
}

