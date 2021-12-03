using Spese.Core.Entities;
using Spese.Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spese.MockRepository
{
    public class ExpensesMockRepository : IExpensesRepository
    {
        public Expense Add(Expense entity)
        {
            entity.Id = InMemoryStorage.Expenses.Max(i => i.Id) + 1;

            InMemoryStorage.Expenses.Add(entity);
            return entity;
        }

        public Expense Delete(Expense entity)
        {
            throw new NotImplementedException();
        }

        public List<Expense> GetAll(Func<Expense, bool> filter = null)
        {
            if (filter == null)
            {
                return InMemoryStorage.Expenses;
            }
            else
            {
                return InMemoryStorage.Expenses.Where(filter).ToList();
            }
        }

        public Expense Update(Expense entity)
        {
            
            Expense expToUpdate = InMemoryStorage.Expenses.Where(e => e.Id == entity.Id).SingleOrDefault();
            expToUpdate.Approved = entity.Approved;

            return expToUpdate;
        }
    }
}
