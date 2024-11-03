using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    public class Task
    {
        public int Id { get; set; }             
        public string Title { get; set; }        
        public string Description { get; set; }   
        public string Priority { get; set; }     
        public DateTime DueDate { get; set; }     
        public string Status { get; set; }        
        public   DateTime? Reminder { get; set; }   

        public int UserId { get; set; }         

        public List<Notification> Notifications { get; set; } = new List<Notification>(); 

        public Task() { }

        public Task(int id, string title, string description, string priority, DateTime dueDate, string status)
        {
            Id = id;
            Title = title;
            Description = description;
            Priority = priority;
            DueDate = dueDate;
            Status = status;
        }
    }
}
