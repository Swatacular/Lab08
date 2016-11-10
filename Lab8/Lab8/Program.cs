using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList PlayerList = new ArrayList();
            Console.WriteLine("Welcome to the Batting Average Calculator!");

            GetData(PlayerList);
            DisplayData(PlayerList);

        }

        private static void DisplayData(ArrayList PlayerList)
        {
            for (int i = 0; i < PlayerList.Count; i++)
            {
                Console.WriteLine("Results for player {0}", i);

                foreach (int element in (int[])PlayerList[i])
                {
                    Console.Write(" {0} ", element);

                }
                Console.WriteLine("\n===================");
            }
        }

        private static void GetData(ArrayList PlayerList)
        {
            while (true)
            {
                GetAndProcessData(PlayerList);

                Console.WriteLine("Another batter? (y/n)");
                string UserChoice = Console.ReadLine();
                if (UserChoice.ToLower() == "no")
                    break;
            }
        }

        private static void GetAndProcessData(ArrayList PlayerList)
        {
            int NumberAtBats;
            int[] AtBats;
            GenerateAtBats(out NumberAtBats, out AtBats);

            // input 
            InputData(NumberAtBats, AtBats);

            // Processing
            CalculateAvgs(NumberAtBats, AtBats);

            // adds the AtBats array to the PlayerList 
            PlayerList.Add(AtBats);
        }

        private static void CalculateAvgs(int NumberAtBats, int[] AtBats)
        {
            int Count = 0;
            int Sum = 0;
            double SluggingPercentage = 0;
            double BattingAverage = 0;

            for (int i = 0; i < NumberAtBats; i++)
            {

                if (AtBats[i] >= 1) Count++;
                Sum = Sum + AtBats[i];


            }

            SluggingPercentage = (double)Sum / NumberAtBats;
            BattingAverage = (double)Count / NumberAtBats;
        }

        private static void GenerateAtBats(out int NumberAtBats, out int[] AtBats)
        {
            Console.Write("Enter number of times at bat: ");
            NumberAtBats = int.Parse(Console.ReadLine());

            AtBats = new int[NumberAtBats];
        }

        private static void InputData(int NumberAtBats, int[] AtBats)
        {
            for (int i = 0; i < NumberAtBats; i++)
            {
                Console.Write("Result for at-bat {0}: ", i);
                AtBats[i] = int.Parse(Console.ReadLine());
            }
        }
    }
}
