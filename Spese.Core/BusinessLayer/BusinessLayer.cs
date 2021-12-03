using Spese.Core.Entities;
using Spese.Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spese.Core.BusinessLayer
{
    public class BusinessLayer : IBusinessLayer
    {
        private readonly IExpensesRepository expensesRepository;
        private readonly ICategoriesRepository categoriesRepository;
        private readonly IUsersRepository usersRepository;

        public BusinessLayer(IExpensesRepository expensesRepo, ICategoriesRepository categoriesRepo, IUsersRepository usersRepo)
        {
            expensesRepository = expensesRepo;
            categoriesRepository = categoriesRepo;
            usersRepository = usersRepo;
        }

        public bool AddExpense(Expense ex)
        {
            Expense e = expensesRepository.Add(ex);
            if (e == null)
                return false;
            else
                return true;
        }

        public bool ApproveExpense(Expense ex)
        {
            ex.Approved = true;
            Expense returned = expensesRepository.Update(ex);
            if (returned == null)
                return false;
            else
                return true;
        }

        public decimal CalculateAmountByCategFromLastMonth(int categId)
        {
            DateTime min = new DateTime();
            DateTime max = new DateTime();
            DateTime today = DateTime.Today;

            if (DateTime.Now.Month == 1)
            {
                min = new DateTime(today.Year - 1, 12, 1);
                max = new DateTime(today.Year, today.Month, 1);
            }

            else
            {
                min = new DateTime(today.Year, today.Month - 1, 1);
                max = new DateTime(today.Year, today.Month, 1);
            }

            List<Expense> requiredExpenses = expensesRepository.GetAll(e => e.CategoryId == categId && e.Date >= min && e.Date < max);

            decimal sum = 0;
            foreach (Expense expense in requiredExpenses)
            {
                sum += expense.Amount;
            }
            return sum;

        }

        public Dictionary<string, decimal> CalculateAmountsForAllCategFromLastMonth()
        {
            List<int> categIds = expensesRepository.GetAll().Select(e => e.CategoryId).Distinct().ToList();

            Dictionary<string, decimal> dictionary = new Dictionary<string, decimal>();

            foreach (var item in categIds) 
            {
                Category category = GetCategoryById(item);
                decimal sum = CalculateAmountByCategFromLastMonth(item);

                dictionary.Add(category.Name, sum);
            }
            return dictionary;
        }

        public List<Category> GetAllCategories()
        {
            return categoriesRepository.GetAll();
        }

        public List<Expense> GetAllExpensesFromMostRecent()
        {
            return expensesRepository.GetAll().OrderByDescending(e => e.Date).ToList();
        }

        public List<Expense> GetAllUnapprovedExpenses()
        {
            return expensesRepository.GetAll(e => e.Approved == false);
        }

        public List<User> GetAllUsers()
        {
            return usersRepository.GetAll();
        }

        public Expense GetApprovedExpenseById(int expenseId)
        {
            return expensesRepository.GetAll(e => e.Approved == false && e.Id == expenseId).SingleOrDefault();
        }

        public List<Expense> GetApprovedExpensesFromLastMonth()
        {
            DateTime min = new DateTime();
            DateTime max = new DateTime();
            DateTime today = DateTime.Today;

            if (DateTime.Now.Month == 1)
            {
                min = new DateTime(today.Year - 1, 12, 1);
                max = new DateTime(today.Year, today.Month, 1);
            }

            else
            {
                min = new DateTime(today.Year, today.Month - 1, 1);
                max = new DateTime(today.Year, today.Month, 1);
            }

            return expensesRepository.GetAll(e => e.Date >= min && e.Date < max && e.Approved == true);
        }

        public Category GetCategoryById(int categId)
        {
            return categoriesRepository.GetAll(c => c.Id == categId).SingleOrDefault();
        }

        public Expense GetExpenseById(int expenseId)
        {
            return expensesRepository.GetAll(e => e.Id == expenseId).SingleOrDefault();
        }

        

        public List<Expense> GetExpensesByUser(int searchedUserId)
        {
            return expensesRepository.GetAll(e => e.UserId == searchedUserId);
        }

        public User GetUserById(int userId)

        {
            return usersRepository.GetAll(u => u.Id == userId).SingleOrDefault();
        }
    }
}
