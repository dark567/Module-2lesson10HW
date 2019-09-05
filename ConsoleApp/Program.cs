using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        public static string[] MenuItems =
            {
            "\t Invalid input. Try again:\n \t Please make your choice...",
            "\n Please choose one of the options:",
            "\t [1] Show ALL Goods",
            "\t [2] Add goods",
            "\t [3] Del goods",
            "\t [4] Exit the program"
        };

        static void Main(string[] args)
        {
            bool MQuit = false;
            int ChoiceNomMenu = 0;

            //first filling
            AddNEWListGoodsForExample();

            //show menu
            ShowMenuInConsole();

            while (!MQuit)
            {
                if (!Int32.TryParse(Console.ReadLine(), out ChoiceNomMenu) || !(ChoiceNomMenu >= 1 && ChoiceNomMenu <= 4))
                {
                    // Console.WriteLine("\t Invalid input. Try again:");
                    // Console.WriteLine("\t Please make your choice...");
                    Console.WriteLine(MenuItems[0]);
                    ShowMenuInConsole();
                    continue;
                }

                switch (ChoiceNomMenu)
                {
                    case 1: //Show ALL Groups

                        int index = 0;
                        Console.WriteLine($"{new string('-', 4)}ID{new string('-', 35)}Name{new string('-', 3)}Price{new string('-', 3)}ShelLife{new string('-', 2)}Produced{new string('-', 7)}BestBefore");
                        foreach (Goods spw in GoodsLogic.GetGoods)
                        {
                            Console.WriteLine($"[{index++}] {spw.Id} {spw.Name}\t{spw.Price}\t{spw.ExpirationCountDays}\t{spw.DateAddGoodsToStorePlace.ToString("dd-MM-yyyy")}\t {GoodsLogic.CalcLimitExpirationDate(spw.ExpirationCountDays, spw.DateAddGoodsToStorePlace).ToString("dd-MM-yyyy")}");
                        }

                        ShowMenuInConsole();
                        break;
                    case 2: //add
                        addNewGoods();
                        ShowMenuInConsole();
                        break;
                    case 3: //del
                        DelGoods();
                        ShowMenuInConsole();
                        break;
                    case 4: //quit
                        Console.WriteLine("\t Quitting...");
                        MQuit = true;
                        break;
                    default:
                        Console.WriteLine("Please make your choice...");
                        break;
                }
            }
        }

        /// <summary>
        /// Add new goods
        /// </summary>
        private static void addNewGoods()
        {
            string _name;
            double _price;
            int _expirationCountDays;

            Console.Write("\tWrite Goods Name:");
            _name = Console.ReadLine();

            bool pr = false;
            do
            {
                Console.Write("\tWrite Goods Price:");
                pr = double.TryParse(Console.ReadLine(), out _price);
            } while (!pr);

            do
            {
                Console.Write("\tWrite Goods Expiration Days:");
                pr = int.TryParse(Console.ReadLine(), out _expirationCountDays);
            } while (!pr);

            try
            {
                GoodsLogic.AddGoods(new Goods(_name, _price, _expirationCountDays));
                Console.WriteLine("\tSuccessfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("\tError. Something went wrong!)", e.Message);
            }
        }

        /// <summary>
        /// void for delete goods
        /// </summary>
        private static void DelGoods()
        {
            int index = 0;
            foreach (Goods spw in GoodsLogic.GetGoods)
            {
                Console.WriteLine($"[{index++}] \t {spw.Id} \t {spw.Name}");
            }

            int GoodsIdDel;
            do
            {
                Console.Write("\t Write № who Delete:");
            } while (!Int32.TryParse(Console.ReadLine(), out GoodsIdDel));

            try
            {
                GoodsLogic.RemoveGoods(GoodsIdDel);

                Console.WriteLine("\tSuccessfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("\tError. Something went wrong!)", e.Message);
            }
        }

        /// <summary>
        /// First Insert Goods for example
        /// </summary>
        private static void AddNEWListGoodsForExample()
        {
            GoodsLogic.AddGoods(new Goods("Bread", 10, 5));
            GoodsLogic.AddGoods(new Goods("Milk", 10, 10));
            GoodsLogic.AddGoods(new Goods("Eage", 10, 15));
        }

        /// <summary>
        /// Show Menu
        /// </summary>
        private static void ShowMenuInConsole()
        {
            for (int i = 1; i < MenuItems.Length; i++)
            {
                Console.WriteLine(MenuItems[i]);
            }
        }
    }
}
