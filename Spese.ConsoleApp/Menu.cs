using Spese.Core;
using Spese.Core.BusinessLayer;
using Spese.Core.Entities;
using Spese.MockRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spese.ConsoleApp
{
    internal class Menu
    {
        private static readonly IBusinessLayer bl = new BusinessLayer(new ExpensesMockRepository(), new CategoriesMockRepository(), new UsersMockRepository());
        internal static void Start()
        {
            bool quit = false;

            do
            {
                Console.WriteLine("----------- MENU -----------");
                Console.WriteLine("[1] Inserisci nuova spesa");
                Console.WriteLine("[2] Approva una spesa");
                Console.WriteLine("[3] Visualizza l'elenco delle spese del mese passato");
                Console.WriteLine("[4] Visualizza l'elenco delle spese per un utente");
                Console.WriteLine("[5] Visualizza il totale delle spese per categoria del mese passato");
                Console.WriteLine("[6] Visualizza tutte le spese a partire dalla più recente");
                Console.WriteLine("[0] Esci");

                int choice = GetMenuInt(0, 6);

                switch (choice)
                {
                    case 0:
                        quit = true;
                        Console.WriteLine("\nChiusura in corso...");
                        break;
                    case 1:
                        InserisciNuovaSpesa();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;

                }




            } while (!quit);
        }

        private static int GetMenuInt(int min, int max)
        {
            int choice;
            bool parse;
            do
            {
                parse = int.TryParse(Console.ReadLine(), out choice);
            } while (!(parse && choice >= min && choice <= max));

            return choice;
        }

        private static int GetInt()
        {
            int num;
            bool parse;
            do
            {
                parse = int.TryParse(Console.ReadLine(), out num);
            } while (!parse);

            return num;
        }

        private static DateTime GetDate()
        {
            DateTime date = new DateTime();
            bool parse;
            do
            {
                parse = DateTime.TryParse(Console.ReadLine(), out date);
            } while (!parse);

            return date;
        }
        //private static decimal GetDecimal()
        //{
        //    decimal num;
        //    bool parse;
        //    do
        //    {
        //        parse = int.TryParse(Console.ReadLine(), out num);
        //    } while (!parse);

        //    return num;
        //}

        private static void InserisciNuovaSpesa()
        {
            Expense ex = new Expense();

            ex.UserId = SelezionaUtente();
            ex.CategoryId = SelezionaCategoria();

            Console.Write("Data: ");
            ex.Date = GetDate();
            Console.Write("Descrizione: ");
            ex.Description = Console.ReadLine();
            Console.Write("Importo:");
            ex.Amount = (decimal)GetInt();

            bl.AddExpense(ex);
            

        }

        
    }
}
