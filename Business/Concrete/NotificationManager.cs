﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class NotificationManager : INotificationService
    {
        private INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }
        public void Add(Notification notification)
        {
            _notificationDal.Add(notification);
        }

        public void Delete(int id)
        {
            var notification=_notificationDal.Get(p=>p.NotificationId==id);
            _notificationDal.Delete(notification);
        }

        public List<Notification> GetAll()
        {
            return _notificationDal.GetList().ToList();
        }

        public Notification GetById(int id)
        {
            return _notificationDal.Get(p => p.NotificationId == id);

        }

        public Notification GetNotificationByStudentId(int studentId)
        {
            Notification _notification= new Notification();
            var notificationList = _notificationDal.GetList().ToList();
            foreach (var notification in notificationList)
            {
                if (notification.RecieverId == studentId)
                {
                    _notification = notification;
                    break;
                }

            }
            if(_notification==null)
            {
                throw new Exception("Kullanıcıya ait bir bildirim yok");
            }

            return _notification;
        }

        public void Update(Notification notification)
        {
            throw new NotImplementedException();
        }
    }
}
