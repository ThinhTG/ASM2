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
    public class NotificationRepository
    {
        private readonly NotificationDAO notificationDAO;

        public NotificationRepository()
        {
            notificationDAO = new NotificationDAO();
        }

        public ArrayList GetAllNotifications()
        {
            return notificationDAO.GetAllNotifications();
        }

        public Notification GetNotificationById(int id)
        {
            return notificationDAO.GetNotificationById(id);
        }

        public void AddNotification(Notification notification)
        {
            notificationDAO.AddNotification(notification);
        }

        public void UpdateNotification(Notification notification)
        {
            notificationDAO.UpdateNotification(notification);
        }

        public void DeleteNotification(int id)
        {
            notificationDAO.DeleteNotification(id);
        }
    }
}
