using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWeek8.Core.Interfaces;
using TestWeek8.Core.Models;

namespace TestWeek8.EF.Repository
{
    public class RepositoryUserEF : IRepositoryUser
    {
        private readonly MenuContext _ctx;

        public RepositoryUserEF(MenuContext context)
        {
            _ctx = context;
        }

        public bool AddItem(User item)
        {
            if (item == null)
                return false;
            _ctx.Users.Add(item);
            _ctx.SaveChanges();
            return true;
        }

        public bool DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Fetch(Func<User, bool> filter = null)
        {
            throw new NotImplementedException();
        }

        public User GetByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return null;
            return _ctx.Users.FirstOrDefault(u => u.Email.Equals(email));
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
