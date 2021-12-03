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
            throw new NotImplementedException();
        }

        public Expense Delete(Expense entity)
        {
            throw new NotImplementedException();
        }

        public List<Expense> GetAll(Func<Expense, bool> filter = null)
        {
            throw new NotImplementedException();
        }

        public Expense Update(Expense entity)
        {
            throw new NotImplementedException();
        }
    }
}
