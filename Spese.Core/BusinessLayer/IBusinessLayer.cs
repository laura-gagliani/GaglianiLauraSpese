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
        void AddExpense(Expense ex);
    }
}
