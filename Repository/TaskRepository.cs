using BussinessObject;
using DAO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = BussinessObject.Task;

namespace Repository
{
    public class TaskRepository
    {
        private  TaskDAO taskDAO;

        public TaskRepository()
        {
            taskDAO = new TaskDAO();
        }

        public ArrayList GetAllTasks()
        {
            return taskDAO.GetAllTasks();
        }

        public Task GetTaskById(int id)
        {
            return taskDAO.GetTaskById(id);
        }

        public void AddTask(Task task)
        {
            taskDAO.AddTask(task);
        }

        public void UpdateTask(Task task)
        {
            taskDAO.UpdateTask(task);
        }

        public void DeleteTask(int id)
        {
            taskDAO.DeleteTask(id);
        }
    }
}
