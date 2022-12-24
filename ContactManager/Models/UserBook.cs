using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Models
{
    public class UserBook
    {
        private List<User> _usersBook;
        public List<User> UsersBook => _usersBook;

        public List<User> GetUsersBook() { return _usersBook; }

        public void AddUserToBook(User user)
        {
            _usersBook.Add(user);
        }
    }
}
