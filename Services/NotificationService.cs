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
    public class NotificationService
    {
        private readonly NotificationRepository notificationRepository;

        public NotificationService()
        {
            notificationRepository = new NotificationRepository();
        }

        public ArrayList GetAllNotifications()
        {
            return notificationRepository.GetAllNotifications();
        }

        public Notification GetNotificationById(int id)
        {
            return notificationRepository.GetNotificationById(id);
        }

        public void AddNotification(Notification notification)
        {
            notificationRepository.AddNotification(notification);
        }

        public void UpdateNotification(Notification notification)
        {
            notificationRepository.UpdateNotification(notification);
        }

        public void DeleteNotification(int id)
        {
            notificationRepository.DeleteNotification(id);
        }
    }
}
