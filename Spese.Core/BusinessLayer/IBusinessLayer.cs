using Spese.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spese.Core
{
    public interface IBusinessLayer
    {
        bool AddExpense(Expense ex);
        List<User> GetAllUsers();
        
        User GetUserById(int userId);
        Category GetCategoryById(int categId);

        List<Category> GetAllCategories();
        List<Expense> GetAllUnapprovedExpenses();
        Expense GetExpenseById(int expenseId);

        bool ApproveExpense(Expense ex);
        List<Expense> GetApprovedExpensesFromLastMonth();
        List<Expense> GetExpensesByUser(int searchedUserId);
        decimal CalculateAmountByCategFromLastMonth(int categId);
        List<Expense> GetAllExpensesFromMostRecent();
        Expense GetApprovedExpenseById(int expenseId);
        Dictionary<string, decimal> CalculateAmountsForAllCategFromLastMonth();
    }
}
