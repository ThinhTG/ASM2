using BussinessObject;
using Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = BussinessObject.Task;

namespace Services
{
    public class TaskService
    {
        private readonly TaskRepository taskRepository;

        public TaskService()
        {
            taskRepository = new TaskRepository();
        }

        public ArrayList GetAllTasks()
        {
            return taskRepository.GetAllTasks();
        }

        public Task GetTaskById(int id)
        {
            return taskRepository.GetTaskById(id);
        }

        public void AddTask(Task task)
        {
            taskRepository.AddTask(task);
        }

        public void UpdateTask(Task task)
        {
            taskRepository.UpdateTask(task);
        }

        public void DeleteTask(int id)
        {
            taskRepository.DeleteTask(id);
        }
    }
    }
