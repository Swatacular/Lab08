using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab08
{
    class Program
    {

        static object[,] dataSheet;
        static int numberOfPlayers;
        static string[] playerNames;
        static int[] playerAB; //at bat
        static int[] playerSingles;
        static int[] playerDoubles;
        static int[] playerTriples;
        static int[] playerHomeruns;
        static double[] playerAvgHits;
        static double[] playerAvgSlugs;


        static void Main(string[] args)
        {

            Console.Write("Enter number of players: ");
            numberOfPlayers = GetIntInput();
            InitializeArrays(numberOfPlayers); //must be run first so that we have a table to fill out
            FillOutDataSheet();
            DisplayDataSheet(dataSheet);

        }
        
        static void DisplayDataSheet(object[,] arrayToDisplay)
        {
            //int row = 0;
            for (int row = 0; row < arrayToDisplay.GetLength(0); row++)
            {
                for (int column = 0; column < arrayToDisplay.GetLength(1); column++)
                {
                    if (column == 0)
                    {
                        Console.Write((arrayToDisplay[row, column]).ToString().PadRight(15));
                    }
                    else Console.Write(String.Format("{0:0.###     }",((arrayToDisplay[row, column])/*.ToString().PadRight(7)*/)));
                }
                Console.WriteLine();
            }
                //this is a replacement for a for loop.. it increases the row once we finish with all of the data.
                //if (column + 1 == arrayToDisplay.GetLength(1) - 1 && row != arrayToDisplay.GetLength(0) - 1)
                //{
                //    column = 0;
                //    row++;
                //    //goes to next line
                //    Console.WriteLine();
                //}
            
        }

        
        //if you don't run this all of the data will be null and unavaliable to write too
        static void InitializeArrays(int NumberOfPlayers)
        {
            dataSheet = new object[NumberOfPlayers, 8]; //6 for data, 2 for avg and slugging avg
            playerNames = new string[NumberOfPlayers];
            playerAB = new int[NumberOfPlayers];
            playerSingles = new int[NumberOfPlayers];
            playerDoubles = new int[NumberOfPlayers];
            playerTriples = new int[NumberOfPlayers];
            playerHomeruns = new int[NumberOfPlayers];
            playerAvgHits = new double[NumberOfPlayers];
            playerAvgSlugs = new double[NumberOfPlayers];
        }
        
        //this goes through each player and runs another method asking for all the data
        static void FillOutDataSheet()
        {
            int playerRow = 0;

            for (int i = 0; i < numberOfPlayers; i++)
            {
                GetPlayerData(playerRow);

                playerRow++;
            }
            
        }

        static double GetAvgHit(int PlayerRowInArray)
        {
            double hits = 0;
            hits = ((int)(dataSheet[PlayerRowInArray, 2]) //Singles
                + (int)(dataSheet[PlayerRowInArray, 3]) //Doubles
                + (int)(dataSheet[PlayerRowInArray, 4]) //Triples
                + (int)(dataSheet[PlayerRowInArray, 5])); //Homeruns

            return hits / (int)dataSheet[PlayerRowInArray, 1]; //Times at bat
        }

        static double GetAvgSlug(int PlayerRowInArray)
        {
            double hits = (int)dataSheet[PlayerRowInArray, 5]; //Homeruns

            return hits / (int)dataSheet[PlayerRowInArray, 1]; //Times at bat
        }

        //goes through each type of data and asks the user for input
        static void GetPlayerData(int PlayerRowInArray)
        {
            for (int tableType = 0; tableType < 6; tableType++) //6 represents Name, At-Bats, Singles, Doubles, Triples, HomeRuns
            {
                
                //just writes some stuff to the screen depending on what you are asking for
                PromptPlayerData(tableType);

                
                //if we are looking for a name, get a String instead of a Int
                if (tableType == 0) dataSheet[PlayerRowInArray, tableType] = GetStringInput();
                else dataSheet[PlayerRowInArray, tableType] = GetIntInput();
            }
            dataSheet[PlayerRowInArray, 6] = GetAvgHit(PlayerRowInArray);
            dataSheet[PlayerRowInArray, 7] = GetAvgSlug(PlayerRowInArray);
        }

        //all of the different prompts when you ask for data
        private static void PromptPlayerData(int tableType)
        {
            switch (tableType)
            {
                case 0:
                    Console.Write("Input player name: ");
                    break;
                case 1:
                    Console.Write("Input at-bats: ");
                    break;
                case 2:
                    Console.Write("Input singles: ");
                    break;
                case 3:
                    Console.Write("Input doubles: ");
                    break;
                case 4:
                    Console.Write("Input triples: ");
                    break;
                case 5:
                    Console.Write("Input homeruns: ");
                    break;
                default:
                    Console.WriteLine("I'm sorry dave, I can not do that right now. . .");
                    break;
            }
        }
        
        static string GetStringInput()
        {
            return Console.ReadLine();
        }
        static string GetIntInputAsString()
        {
            return int.Parse(Console.ReadLine()).ToString();
        }
        static int GetIntInput()
        {
            return int.Parse(Console.ReadLine());
        }




    }
}
