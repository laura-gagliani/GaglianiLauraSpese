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
                Console.WriteLine("[3] Visualizza l'elenco delle spese approvate del mese passato");
                Console.WriteLine("[4] Visualizza l'elenco delle spese per un utente");
                Console.WriteLine("[5] Visualizza il totale (euro) delle spese per categoria del mese passato");
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
                        ApprovaUnaSpesa();
                        break;
                    case 3:
                        VisualizzaSpeseApprovateDelMeseScorso();
                        break;
                    case 4:
                        VisualizzaSpesePerUtente();
                        break;
                    case 5:
                        VisualizzaAmmontareDelMeseScorsoPerCategoria();
                        break;
                    case 6:
                        break;

                }




            } while (!quit);
        }

        private static void VisualizzaAmmontareDelMeseScorsoPerCategoria()
        {
            int categId = SelezionaCategoria();
            decimal sum = bl.CalculateAmountByCategFromLastMonth(categId);

            Console.WriteLine($"La spesa ammonta a {sum} euro");
        }

        private static void VisualizzaSpesePerUtente()
        {
            int searchedUserId = SelezionaUtente();

            List<Expense> requestedExpenses = bl.GetExpensesByUser(searchedUserId);
            foreach (var item in requestedExpenses)
            {
                Console.WriteLine(item);
            }
        }

        private static void VisualizzaSpeseApprovateDelMeseScorso()
        {
            List<Expense> requestedExpenses = bl.GetApprovedExpensesFromLastMonth();
            foreach (var item in requestedExpenses)
            {
                Console.WriteLine(item);
            }

        }

        private static void ApprovaUnaSpesa()
        {
            Console.WriteLine("\nLe spese ancora in attesa di approvazione sono:");
            List<Expense> unapproved = bl.GetAllUnapprovedExpenses();
            foreach (Expense expense in unapproved)
            {
                Console.WriteLine(expense);
            }

            Console.WriteLine("\nInserisci l'id della spesa da approvare:");
            Expense e;
            int expenseId;

            do
            {
                expenseId = GetInt();
                e = bl.GetExpenseById(expenseId);
                if (e == null)
                {
                    Console.WriteLine("\nId non in elenco! Inserisci un id corretto:");
                }

            } while (e == null);

            bool isApproved = bl.ApproveExpense(e);
            if (isApproved)
                Console.WriteLine("\nSpesa correttamente approvata");
            else
                Console.WriteLine("\nErrore nell'aggiornamento dati");


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

        private static DateTime GetPastDate()
        {
            DateTime date = new DateTime();
            bool parse;
            
            do
            {
                parse = DateTime.TryParse(Console.ReadLine(), out date);
            } while (!(parse && date <= DateTime.Today));

            return date;
        }
        private static decimal GetDecimal()
        {
            decimal num;
            bool parse;
            do
            {
                parse = decimal.TryParse(Console.ReadLine(), out num);
            } while (!parse);

            return num;
        }

        private static void InserisciNuovaSpesa()
        {
            Expense ex = new Expense();

            ex.UserId = SelezionaUtente();
            ex.CategoryId = SelezionaCategoria();

            Console.Write("Data: ");
            ex.Date = GetPastDate();
            Console.Write("Descrizione: ");
            ex.Description = Console.ReadLine();
            Console.Write("Importo:");
            ex.Amount = GetDecimal();

            bool isAdded = bl.AddExpense(ex);
            if (isAdded)
            {
                Console.WriteLine("\nSpesa correttamente inserita");
            }
            else
            {
                Console.WriteLine("\nErrore nel processo di inserimento!");

            }


        }

        private static int SelezionaCategoria()
        {
            Console.WriteLine("\nLe categorie in elenco sono:");
            List<Category> categories = bl.GetAllCategories();
            foreach (var item in categories)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nInserisci l'id della categoria da selezionare:");
            Category categById;
            int categId;
            do
            {
                categId = GetInt();
                categById = bl.GetCategoryById(categId);
                if (categById == null)
                {
                    Console.WriteLine("\nId non in elenco! Inserisci un id corretto:");
                }


            } while (categById == null);

            return categId;
        }

        private static int SelezionaUtente()
        {
            Console.WriteLine("\nGli utenti in elenco sono:");
            List<User> users = bl.GetAllUsers();
            foreach (var item in users)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nInserisci l'id dell'utente da selezionare:");
            User userById;
            int userId;
            do
            {
                userId = GetInt();
                userById = bl.GetUserById(userId);
                if (userById == null)
                {
                    Console.WriteLine("\nId non in elenco! Inserisci un id corretto:");
                }
               

            } while (userById == null);

            return userId;
            


            
        }
    }
}
