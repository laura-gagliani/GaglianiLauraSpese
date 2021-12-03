using Spese.Core.Entities;
using Spese.Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spese.MockRepository
{
    public class UsersMockRepository : IUsersRepository
    {
        public User Add(User entity)
        {
            throw new NotImplementedException();
        }

        public User Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll(Func<User, bool> filter = null)
        {
            if (filter == null)
            {
                return InMemoryStorage.Users;
            }
            else
            {
                return InMemoryStorage.Users.Where(filter).ToList();
            }
        }

        public User Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
