using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab08_3
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList PlayerList = new ArrayList();



            while (true)
            {
                Console.WriteLine("Another batter? (y/n)");
                string UserChoice = Console.ReadLine();

                if (UserChoice.ToLower() == "no") break;



                for (int i = 0; i < PlayerList.Count; i++)
                {
                    Console.WriteLine("Results for player {0}", i);

                    foreach (int element in (int[])PlayerList[i])
                    {

                    }
                }
            }
        }
    }
}
