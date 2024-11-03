using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    public class Notification
    {
        public int Id { get; set; }                
        public string Message { get; set; }       
        public string Type { get; set; }           
        public DateTime Date { get; set; }         

  
        public Task Task { get; set; }         
    }
}
