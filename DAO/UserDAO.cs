using BussinessObject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class UserDAO
    {
        private ArrayList users;

        public UserDAO()
        {
            users = new ArrayList();
        }

        public ArrayList GetAllUsers()
        {
            return users;
        }

        public User GetUserById(int id)
        {
            foreach (User user in users)
            {
                if (user.UserId == id)
                    return user;
            }
            return null;
        }

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public void UpdateUser(User user)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (((User)users[i]).UserId == user.UserId)
                {
                    users[i] = user;
                    break;
                }
            }
        }

        public void DeleteUser(int id)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (((User)users[i]).UserId == id)
                {
                    users.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
