using Spese.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spese.MockRepository
{
    internal class InMemoryStorage
    {
        static List<User> Users = new List<User>()
        {
            new User() {Id = 1, Name = "Lorenzo", Surname = "Rossi"},
            new User() {Id = 2, Name = "Carla", Surname = "Donati"},
        };

        static List<Category> Categories = new List<Category>()
        {
            new Category() {Id = 1, Name = "Cibo"},
            new Category() {Id = 2, Name = "Casa"},
            new Category() {Id = 3, Name = "Salute"},
        };

        static List<Expense> Expenses = new List<Expense>()
        {
            new Expense() {Id = 1, Date = new DateTime(2021, 11, 27),Description = "Spesa supermercato", Amount = 130.54m, Approved = false, CategoryId = 1, UserId = 1 },
            new Expense() {Id = 2, Date = new DateTime(2021, 11, 14),Description = "Spesa supermercato", Amount = 187.02m, Approved = true, CategoryId = 1, UserId = 1 },
            new Expense() {Id = 3, Date = new DateTime(2021, 10, 2),Description = "Dentista", Amount = 130.54m, Approved = true, CategoryId = 3, UserId = 1 },
            new Expense() {Id = 4, Date = new DateTime(2021, 12, 2),Description = "Pagamento affitto", Amount = 600m, Approved = false, CategoryId = 2, UserId = 1 },

            new Expense() {Id = 5, Date = new DateTime(2021, 11, 21),Description = "Macellaio", Amount = 32.43m, Approved = false, CategoryId = 1, UserId = 2 },
            new Expense() {Id = 6, Date = new DateTime(2021, 12, 2),Description = "Spesa ortofrutta", Amount = 14m, Approved = false, CategoryId = 1, UserId = 2 },
            new Expense() {Id = 7, Date = new DateTime(2021, 11, 15),Description = "Supermercato", Amount = 90.72m, Approved = true, CategoryId = 1, UserId = 2 },
            new Expense() {Id = 8, Date = new DateTime(2021, 11, 27),Description = "Imbianchino", Amount = 1200m, Approved = true, CategoryId = 2, UserId = 2 },
            new Expense() {Id = 9, Date = new DateTime(2021, 11, 3),Description = "Analisi del sangue", Amount = 29.60m, Approved = true, CategoryId = 3, UserId = 2 },
        };
    }
}
