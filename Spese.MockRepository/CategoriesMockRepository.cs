using Spese.Core.Entities;
using Spese.Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spese.MockRepository
{
    public class CategoriesMockRepository : ICategoriesRepository
    {
        public Category Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public Category Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll(Func<Category, bool> filter = null)
        {
            if (filter == null)
            {
                return InMemoryStorage.Categories;
            }
            else
            {
                return InMemoryStorage.Categories.Where(filter).ToList();
            }
        }

        public Category Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
