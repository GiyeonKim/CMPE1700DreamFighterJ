using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMPE1700GiyeonKimICAs05
{
    class Program
    {
        /* Group of name : Dream Figher J
          Name of the group: Giyeon Kim, Jing Li

            Add extra feature: Change the suit to symbols and made the cards looks like 
            classing game feature (like make a box so it looks like a card)
            and change the color of the text of the computer and player cards hand so
            it easily to see the different of both players
        */

        static void Main(string[] args)
        {
            bool exit = false;
            Players player = new Players(); // first players
            Players computer = new Players(); // computer 
            Console.ForegroundColor = ConsoleColor.White; // change the color of the first player

            player.GenerateHand(); // calls the card of hand method of first player
            computer.GenerateHand(); // calls the card of the hand method for computer
            // the introduction
            Console.WriteLine("Welcome to poker game!");
            Console.WriteLine("\nReady to play? (y/n)");
            string userinput = Console.ReadLine();
            if (userinput == "N" || userinput == "n")
                exit = true;
            // putting the face and suit in different arrays
            string[] x = new string[5];
            string[] su = new string[5];
            string[] group = new string[5];
            // ranking the player and computer
            int player_rank = 0;
            int computer_rank = 0;
            // putting in a loop so it doesnt exit
            while (!exit)
            {
                Console.WriteLine("\nYour cards are:\n");
                for (int i = 0; i < 5; i++)
                {
                    
                    // putting face in one array and putting suit in another array and also put together in one array
                    x[i] = player.hand[i].Face.ToString();
                    su[i] = player.hand[i].Suits.ToString();
                    group[i] = player.hand[i].Face.ToString() + " of " + player.hand[i].Suits.ToString();
                }
                //sort them first 
                Array.Sort(x);
                Array.Sort(su);
                Array.Sort(group);
                
                // rank them  
                player_rank = num(x, su);
                // putting them in descending order so number first them letters
                organize(player_rank, x, su, group);
                Console.WriteLine("The rank of player is " + player_rank);
                // put into rank name
                HandRank(player_rank);
                // putting them in colors
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nComputer Cards are: \n");
                Console.ForegroundColor = ConsoleColor.White;
                
                // this is computer. so creating 3 arrays for it
                string[] d = new string[5];
                string[] y = new string[5];
                string[] su1 = new string[5];
                for (int j = 0; j < 5; j++)
                {
                    // add face to one array. add suit to another array. then add both to another array
                    y[j] = computer.hand[j].Face.ToString();
                    su1[j] = computer.hand[j].Suits.ToString();
                    d[j] = (computer.hand[j].Face.ToString()+" of "+ computer.hand[j].Suits.ToString()) ;
                }
                // sort them first
                Array.Sort(d);
                Array.Sort(y);
                Array.Sort(su1);
                // rank the computer
                computer_rank = num(y, su1);
                // print them out in order
                organize(computer_rank, y, su1, d);
                // put into rank name
                HandRank(computer_rank);
                Console.WriteLine("The computer rank is " + computer_rank);
                // tell which one wins
                if (player_rank < computer_rank)
                    Console.WriteLine("player wins");
                if (player_rank > computer_rank)
                    Console.WriteLine("computer wins");
                if (player_rank == computer_rank)
                    Console.WriteLine("They are tie");

                // exit the loop
                exit = true;
            }

            Console.WriteLine("\nThank you for Playing the Game! \nPress any key to exit the game!");

            Console.ReadKey();
        }
        // rank the player and computer
        public static int num(string[]face, string[] suit)
        {
            
            int count = 0;
            int c = 0;
            int j = 0;
            int count1 = 0;
            int c1 = 0;
            int j1 = 0;
            int rank = 0;    
            // this one is count how many pairs of face    
            for (int i = 0; i < 5; i++)
            {
                j = i + 1;
                if (j < 5)
                {
                    if (face[i] == face[j])
                    {
                        c++;
                        count += c;
                    }
                    else
                        c = 0;
                }
            }
            // this one is count how many pairs of suit
            for (int i = 0; i < 5; i++)
            {
                j1 = i + 1;
                if (j1 < 5)
                {
                    if (suit[i] == suit[j1])
                    {
                        c1++;
                        count1 += c1;
                    }
                    else
                        c1 = 0;
                }

            }
            int e = 0;
            // this is the card that need for rank 1
            if (face[0] == "Ace" && face[1] == "Jack" && face[2] == "King" && face[3] == "Queen" && face[4] == "Ten" && count1 == 10)
            {
                rank = 1;

            }
            // this is the card that needed for rank 2
            else if ((face[0] == "Five" && face[1] == "Four" && face[2] == "Six" && face[3] == "Three" & face[4] == "Two" & count1 == 10) || (
                (face[0] == "Five" && face[1] == "Four" && face[2] == "Seven" && face[3] == "Six" & face[4] == "Three" & count1 == 10) ||
                (face[0] == "Eight" && face[1] == "Five" && face[2] == "Four" && face[3] == "Seven" & face[4] == "Six" & count1 == 10) ||
                (face[0] == "Eight" && face[1] == "Five" && face[2] == "Nine" && face[3] == "Seven" & face[4] == "Six" & count1 == 10) ||
                (face[0] == "Eight" && face[1] == "Nine" && face[2] == "Seven" && face[3] == "Six" & face[4] == "Ten" & count1 == 10)))
            {
                rank = 2;
            }

            // this is the suit that need for rank 5
            else if (count1 == 10)
            {
                rank = 5;
            }
            // identify rank 6
            else if (face[0] == "Ace" && face[1] == "Five" && face[2] == "Four" && face[3] == "Three" && face[4] == "Two")
                rank = 6;
            // other ranks that only need pairs to identify
            else if (count == 6)
                rank = 3;
            else if (count == 4)
                rank = 4;
            else if (count == 3)
                rank = 7;
            else if (count == 2)
                rank = 8;
            else if (count == 1)
                rank = 9;
            else if (count == 0)
                rank = 10;
            // return the rank
            return rank;
        }
        // organize and print out the cards
        public static void organize(int rank, string[]face, string []suit, string[]group)
        {
            // change the face into numbers
            for (int i = 0; i < 5; i++)
            {
                if (face[i] == "Two")
                {
                    face[i] = "2";
                }
                if (face[i] == "Three")
                {
                    face[i] = "3";
                }
                if (face[i] == "Four")
                {
                    face[i] = "4";
                }
                if (face[i] == "Five")
                {
                    face[i] = "5";
                }
                if (face[i] == "Six")
                {
                    face[i] = "6";
                }
                if (face[i] == "Seven")
                {
                    face[i] = "7";
                }
                if (face[i] == "Eight")
                {
                    face[i] = "8";
                }
                if (face[i] == "Nine")
                {
                    face[i] = "9";
                }
                if (face[i] == "Ten")
                {
                    face[i] = "10";
                }
            }
            if (rank == 1)
            {
                // print out the cards
                string[] card = new string[5] { "A", "K", "Q", "J", "10" };
                string s = suit[0];
                foreach (string x in card)
                    // draw the card
                    draw(x, s, group);
            }
            else if (rank == 2)
            {
                // sort the face first
                Array.Sort(face);

                string w = suit[0];
                // print the cards out
                foreach (string x in face)
                    draw(x, w, group);
            }
            else if (rank == 5)
            {
                // switch face into numbers
                string q = suit[0];
                for (int i = 0; i < 5; i++)
                {
                    if (group[i].Contains("Two"))
                    {
                        face[i] = "2";
                    }
                    if (group[i].Contains("Three"))
                    {
                        face[i] = "3";
                    }
                    if (group[i].Contains("Four"))
                    {
                        face[i] = "4";
                    }
                    if (group[i].Contains("Five"))
                    {
                        face[i] = "5";
                    }
                    if (group[i].Contains("Six"))
                    {
                        face[i] = "6";
                    }
                    if (group[i].Contains("Seven"))
                    {
                        face[i] = "7";
                    }
                    if (group[i].Contains("Eight"))
                    {
                        face[i] = "8";
                    }
                    if (group[i].Contains("Nine"))
                    {
                        face[i] = "9";
                    }
                    if (group[i].Contains("Ten"))
                    {
                        face[i] = "A";
                    }
                    if (group[i].Contains("Jack"))
                        face[i] = "B";
                    if (group[i].Contains("Queen"))
                        face[i] = "E";
                    if (group[i].Contains("King"))
                        face[i] = "F";
                    if (group[i].Contains("Ace"))
                        face[i] = "G";

                }
               
                // sort the face
                Array.Sort(face);
                // switch the symbols back
                for (int i = 0; i < 5; i++)
                {
                    if (face[i] == "A")
                        face[i] = "10";
                    if (face[i] == "B")
                        face[i] = "J";
                    if (face[i] == "E")
                        face[i] = "Q";
                    if (face[i] == "F")
                        face[i] = "K";
                    if (face[i] == "G")
                        face[i] = "A";

                }
                // draw the card
                foreach (string x in face)
                    draw(x, q, group);
            }
            else
            {
                // replace all the face with numbers and letters
                for (int i = 0; i < 5; i++)
                {
                    if (group[i].Contains("Two"))
                    {
                        group[i] = group[i].Replace("Two","2");
                    }
                    if (group[i].Contains("Three"))
                    {
                        group[i] = group[i].Replace("Three", "3");
                    }
                    if (group[i].Contains("Four"))
                    {
                        group[i] = group[i].Replace("Four", "4");
                    }
                    if (group[i].Contains("Five"))
                    {
                        group[i] = group[i].Replace("Five", "5");
                    }
                    if (group[i].Contains("Six"))
                    {
                        group[i] = group[i].Replace("Six", "6");
                    }
                    if (group[i].Contains("Seven"))
                    {
                        group[i] = group[i].Replace("Seven", "7");
                    }
                    if (group[i].Contains("Eight"))
                    {
                        group[i] = group[i].Replace("Eight", "8");
                    }
                    if (group[i].Contains("Nine"))
                    {
                        group[i] = group[i].Replace("Nine", "9");
                    }
                    if (group[i].Contains("Ten"))
                    {
                        group[i] = group[i].Replace("Ten", "A");
                    }
                    if (group[i].Contains("Jack"))
                        group[i] = group[i].Replace("Jack", "B");
                    if (group[i].Contains("Queen"))
                        group[i] = group[i].Replace("Queen", "E");
                    if (group[i].Contains("King"))
                        group[i] = group[i].Replace("King", "F");
                    if (group[i].Contains("Ace"))
                        group[i] = group[i].Replace("Ace", "G");


                }
                // sort the array
                Array.Sort(group);
                // reverse them
                Array.Reverse(group);
                // put it into faces
                for (int i = 0; i < 5; i++)
                {
                    if (group[i].Contains("2"))
                    {
                        face[i] = "2";
                    }
                    if (group[i].Contains("3"))
                    {
                        face[i] = "3";
                    }
                    if (group[i].Contains("4"))
                    {
                        face[i] = "4";
                    }
                    if (group[i].Contains("5"))
                    {
                        face[i] = "5";
                    }
                    if (group[i].Contains("6"))
                    {
                        face[i] = "6";
                    }
                    if (group[i].Contains("7"))
                    {
                        face[i] = "7";
                    }
                    if (group[i].Contains("8"))
                    {
                        face[i] = "8";
                    }
                    if (group[i].Contains("9"))
                    {
                        face[i] = "9";
                    }
                    if (group[i].Contains("A"))
                    {
                        face[i] = "10";
                    }
                    if (group[i].Contains("B"))
                        face[i] = "J";
                    if (group[i].Contains("E"))
                        face[i] = "Q";
                    if (group[i].Contains("F"))
                        face[i] = "K";
                    if (group[i].Contains("G"))
                        face[i] = "A";
                }
                
                // putting all the suit into suit array
                for (int i = 0; i < 5; i++)
                {
                    if (group[i].Contains("Clubs"))
                        suit[i] = "Clubs";
                    if (group[i].Contains("Diamonds"))
                        suit[i] = "Diamonds";
                    if (group[i].Contains("Spades"))
                        suit[i] = "Spades";
                    if (group[i].Contains("Hearts"))
                        suit[i] = "Hearts";
                }
                // draw the cards
                for (int i = 0; i < 5; i++)
                {
                    draw(face[i], suit[i], group);
                }
               
            }
        }
        // draw the cards
        public static void draw(string face, string suit, string[] group)
        {
            int s = 0;
            // putting it in char
            if (suit == "Diamonds")
            {
                char c = '♦';

                s = 4;

                Console.ForegroundColor = ConsoleColor.Red;
            }
            if (suit == "Hearts")
            {
                suit = @"♥";
                s = 3;

                Console.ForegroundColor = ConsoleColor.Red;
            }
            if (suit == "Spades")
            {
                s = 6;

                Console.ForegroundColor = ConsoleColor.White;
            }
            if (suit == "Clubs")
            {
                suit = @"♣";
                s = 5;
                Console.ForegroundColor = ConsoleColor.White;
            }
            // creating the card
            Console.WriteLine("______________");
            if (face.Length == 1)
            { 
                // draw the suit symbol in char
                Console.WriteLine("| {0}{1}         |", face, ((char)s));
            }
            else
                Console.WriteLine("| {0}{1}        |", face, ((char)s));

            for (int i =0; i< 8;i++)
            {
                Console.WriteLine("|            |");
            }
            // draw the bottom line
            Console.WriteLine("______________");
            Console.ForegroundColor = ConsoleColor.White;
        }
        // telling the name of the rank
        public static void HandRank(int rank)
        {
            string rule = null;
            if (rank == 1)
            {
                rule = "Royal flush";
            }
            if (rank == 2)
            {
                rule = "Straight flush";
            }
            if (rank == 3)
            {
                rule = "Four of a kind";
            }
            if (rank == 4)
            {
                rule = "Full house";
            }
            if (rank == 5)
            {
                rule = "Flush";
            }
            if (rank == 6)
            {
                rule = "Straight";
            }
            if (rank == 7)
            {
                rule = "Three of a kind";
            }
            if (rank == 8)
            {
                rule = "Two pair";
            }
            if (rank == 9)
            {
                rule = "One pair";
            }
            if (rank == 10)
            {
                rule = "High card";
            }
            Console.WriteLine("The rank name is " + rule);
        }
    }
}
