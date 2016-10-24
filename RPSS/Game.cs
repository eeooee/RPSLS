using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSS
{
    class Game
    {


        const int win = 1;
        const int lose = 0;
        const int tie = 2;
        string input;
        public GameItems[,] logic = new GameItems[5, 5]

        //scissors-0
        //rock - 1
        //spock -2
        //paper - 3
        //lizard -4
        // win 1, lose 0, tie = 2
        //TODO: fill in string argument in constructor with message

        {   { new GameItems(tie, "tie"), new GameItems(lose, "rock crushes scissors"),new GameItems(lose, "spock smashes scissors"),new GameItems(win, "scissors cut paper"),new GameItems(win, "scissors decapitate lizard") },
            { new GameItems(win, "rock crushes scissors"), new GameItems(tie, "tie"),new GameItems(0, "tie"),new GameItems(0, "tie"),new GameItems(1, "tie") },
            { new GameItems(win, "spock smashes scissors"), new GameItems(1, "tie"),new GameItems(2, "tie"),new GameItems(0, "tie"),new GameItems(0, "tie") },
            { new GameItems(lose, "scissors cut paper"), new GameItems(1, "tie"),new GameItems(1, "tie"),new GameItems(2, "tie"),new GameItems(0, "tie") },
            { new GameItems(lose, "scissors decapitate lizard"), new GameItems(0, "tie"),new GameItems(1, "tie"),new GameItems(1, "tie"),new GameItems(2, "tie") },

        };

        public int winFunction;
        public int gamesPlayed;
        public Player Player1;
        public Player Player2;
        public string computerName = "Hal";


        public string WhichOne(int num, Player player)
        {

            switch (num)
            {
                case 0: return "scissors";
                case 1: return "rock";
                case 2: return "spock";
                case 3: return "paper";
                case 4: return "lizard";
                default: TrySelection(player);
                    return "\tTry again!";
            }

        }


        public void CountWins(Player player1, Player player2)
        {
            winFunction = player1.wins - player2.wins;
            while (gamesPlayed >= 3)
            {
                if (winFunction >= 1)
                {
                    Console.WriteLine("{0} has won enough times to be considered the winner! {1} of {2}.", player1.name, player1.wins, gamesPlayed);
                    break;
                }
                else if (winFunction <= -1)
                {
                    Console.WriteLine("{0} has won enough times to be considered the winner! {1} of {2}.", player2.name, player2.wins, gamesPlayed);
                    break;
                }
                else if (winFunction == 0)
                {
                    Console.WriteLine("Currently, both players are tied!");
                    break;
                }
            }
        }



        public void WhoWins(Player firstPlayer, Player secondPlayer)
        {

            Console.WriteLine("\n\t{0} has chosen {1} and {2} has chosen {3}. \n Fight!", firstPlayer.GetName(), WhichOne(firstPlayer.selection, firstPlayer), secondPlayer.GetName(), WhichOne(secondPlayer.selection,secondPlayer));

            switch ((logic[firstPlayer.selection, secondPlayer.selection].win))
            {
                case 0:
                    Console.WriteLine("\t{0} has won this round! Great job!", secondPlayer.GetName());
                    secondPlayer.AddWin();
                    gamesPlayed++;
                    break;
                case 1:
                    Console.WriteLine("\t{0} has won this round!  Great job!", firstPlayer.GetName());
                    firstPlayer.AddWin();
                    gamesPlayed++;
                    break;
                case 2:
                    Console.WriteLine("\tBoth players have tied!  No one wins. ");
                    break;

            }
            CountWins(firstPlayer, secondPlayer);

        }


        public void PlayFriend()
        {
            Console.WriteLine("\t{0}, make a selection!", Player1.name);
            SelectInput(Player1);
            Console.WriteLine("\tNow for {0}...", Player2.name);
            SelectInput(Player2);
            this.WhoWins(Player1, Player2);
            Console.WriteLine("type quit to exit, enter for the next game");

        }


        public void SelectInput(Player player)
        {
            Console.WriteLine("\t{0}, make a selection!", player.name);
            TrySelection(player);

        }

        public void PlayComputer()
        {
            Console.WriteLine("\tYou're now playing against the computer.");
            SelectInput(Player1);
            Player2.MakeSelection();
            this.WhoWins(Player1, Player2);
            Console.WriteLine("\ttype quit to exit, enter for the next game");
        }

        public void TrySelection(Player player)
        {
            try
            {
                input = Console.ReadLine();
                player.selection = int.Parse(input);
                


            }
            catch (Exception e)
            {
                Console.WriteLine("\tYou entered {0}.  Please enter 0, 1, 2, 3 or 4. \n", input);
                TrySelection(player);
                
            }

        }

        public void CreatePlayer( bool isComputer, string message) {
            if (isComputer) {
                Player1 = new Human();
                Player2 = new Computer();
                Player1.SetName();
            }
            else {
                Player2 = new Human();
                Player2.SetName();
            }
      
        }

        public void StartGame()
        {
            Console.WriteLine("Welcome to Rock Paper Scissor Lizard Spock!");
            Console.WriteLine("\tTo play alone, hit any key.  To play with a friend, type friend. ");
            Console.WriteLine("\t0:Scissors. \t1:Rock \t2:Spock \t3:Paper \t4:Lizard");
            input = Console.ReadLine();

            if (input.Contains("friend"))
            {
                CreatePlayer( false, "your friend");
                while (!input.Contains("quit"))
                {
                    PlayFriend();
                    input = Console.ReadLine();
                }
            }
            else
            {

                CreatePlayer(true, "the computer");
                while (!input.Contains("quit"))
                {

                    
                    PlayComputer();
                    input = Console.ReadLine();
                }
            }


        }
    }
}

