using BussinessObject;
using DAO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository
    {
        private readonly UserDAO userDAO;

        public UserRepository()
        {
            userDAO = new UserDAO();
        }

        public ArrayList GetAllUsers()
        {
            return userDAO.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return userDAO.GetUserById(id);
        }

        public void AddUser(User user)
        {
            userDAO.AddUser(user);
        }

        public void UpdateUser(User user)
        {
            userDAO.UpdateUser(user);
        }

        public void DeleteUser(int id)
        {
            userDAO.DeleteUser(id);
        }
    }
}
