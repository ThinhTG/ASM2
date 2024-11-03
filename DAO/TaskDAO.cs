using BussinessObject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = BussinessObject.Task;

namespace DAO
{
    public class TaskDAO
    {
        private ArrayList tasks;

        public TaskDAO()
        {
            tasks = new ArrayList();
        }

        public ArrayList GetAllTasks()
        {
            return tasks;
        }

        public Task GetTaskById(int id)
        {
            foreach (Task task in tasks)
            {
                if (task.Id == id)
                    return task;
            }
            return null;
        }

        public void AddTask(Task task)
        {
            tasks.Add(task);
        }

        public void UpdateTask(Task task)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                if (((Task)tasks[i]).Id == task.Id)
                {
                    tasks[i] = task;
                    break;
                }
            }
        }

        public void DeleteTask(int id)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                if (((Task)tasks[i]).Id == id)
                {
                    tasks.RemoveAt(i);
                    break;
                }
            }
        }
        }
    }
