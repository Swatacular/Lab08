using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab08_2
{
    class Program
    {

        static string[,] dataList;
        static int numberOfPlayers;



        static void Main(string[] args)
        {

            Console.Write("Enter number of players: ");
            numberOfPlayers = GetIntInput();
            dataList = new string[numberOfPlayers, 8];

            for (int i = 0; i < dataList.GetLength(0); i++)
            {
                for (int ii = 0; ii < dataList.GetLength(1); ii++)
                {
                    dataList[i, ii] = "0";
                }
            }

            //6 represents Name, Outs, Singles, Doubles, Triples, HomeRuns, and then the last two are for hitting and slugging avg

            Console.WriteLine("-1 = end at-bats, 0 = out, 1 = single, 2 = double, 3 = triple, 4 = home run");


            // there are 6 types of data to give. and then 2 to calculate
            int playerNum = 0;
            for (int atBatNum = 0; playerNum < numberOfPlayers; atBatNum++)
            {
                Console.Write("Result for at-bat " + atBatNum + ": ");
                switch (GetIntInput())
                {
                    case -1:
                        DisplayStatus();
                        playerNum++;
                        atBatNum = -1; //set to -1 because the for loop will add one to it.
                        break;
                    case 0:
                        dataList[playerNum, 1] = ((int.Parse(dataList[playerNum, 1]) + 1).ToString());
                        break;
                    case 1:
                        dataList[playerNum, 2] = ((int.Parse(dataList[playerNum, 2]) + 1).ToString());
                        break;
                    case 2:
                        dataList[playerNum, 3] = ((int.Parse(dataList[playerNum, 3]) + 1).ToString());
                        break;
                    case 3:
                        dataList[playerNum, 4] = ((int.Parse(dataList[playerNum, 4]) + 1).ToString());
                        break;
                    case 4:
                        dataList[playerNum, 5] = ((int.Parse(dataList[playerNum, 5]) + 1).ToString());
                        break;



                    default:
                        Console.WriteLine("Invalid Input, please try again.");
                        atBatNum--;
                        break;
                }
            }




        }

        private static void DisplayStatus()
        {
            Console.WriteLine("Yada Yada heres your data.");
        }


        static int GetIntInput()
        {
            int input;
            while (!(int.TryParse(Console.ReadLine(), out input)))
            {
                return -2; //a invalid input
            }
            return input;
        }
    }
}
