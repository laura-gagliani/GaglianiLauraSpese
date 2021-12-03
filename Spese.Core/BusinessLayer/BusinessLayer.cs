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


    }
}
