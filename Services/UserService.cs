using BussinessObject;
using Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService
    {
        private readonly UserRepository userRepository;

        public UserService()
        {
            userRepository = new UserRepository();
        }

        public ArrayList GetAllUsers()
        {
            return userRepository.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return userRepository.GetUserById(id);
        }

        public void AddUser(User user)
        {
            userRepository.AddUser(user);
        }

        public void UpdateUser(User user)
        {
            userRepository.UpdateUser(user);
        }

        public void DeleteUser(int id)
        {
            userRepository.DeleteUser(id);
        }
    }
}
