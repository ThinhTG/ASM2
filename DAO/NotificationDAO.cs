using BussinessObject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class NotificationDAO
    {
        private ArrayList notifications;

        public NotificationDAO()
        {
            notifications = new ArrayList();
        }

        public ArrayList GetAllNotifications()
        {
            return notifications;
        }

        public Notification GetNotificationById(int id)
        {
            foreach (Notification notification in notifications)
            {
                if (notification.Id == id)
                    return notification;
            }
            return null;
        }

        public void AddNotification(Notification notification)
        {
            notifications.Add(notification);
        }

        public void UpdateNotification(Notification notification)
        {
            for (int i = 0; i < notifications.Count; i++)
            {
                if (((Notification)notifications[i]).Id == notification.Id)
                {
                    notifications[i] = notification;
                    break;
                }
            }
        }

        public void DeleteNotification(int id)
        {
            for (int i = 0; i < notifications.Count; i++)
            {
                if (((Notification)notifications[i]).Id == id)
                {
                    notifications.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
