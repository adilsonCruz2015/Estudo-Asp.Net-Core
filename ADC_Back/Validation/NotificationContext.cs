using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace ADC_Back.Validation
{
    public class NotificationContext
    {
        private readonly List<Notification> _notifications;

        public IReadOnlyCollection<Notification> Notifications => _notifications;

        public bool HasNotifications => _notifications.Any();

        public NotificationContext()
        {
            this._notifications = new List<Notification>();
        }

        public void AddNotification(string key, string message, string referencia, object valor)
        {
            this._notifications.Add(new Notification(key, message, referencia, valor));
        }

        public void AddNotification(Notification notification)
        {
            this._notifications.Add(notification);
        }

        public void AddNotifications(IReadOnlyCollection<Notification> notifications)
        {
            this._notifications.AddRange(notifications);
        }

        public void AddNotifications(IList<Notification> notifications)
        {
            this._notifications.AddRange(notifications);
        }

        public void AddNotifications(ICollection<Notification> notifications)
        {
            this._notifications.AddRange(notifications);
        }

        public void AddNotifications(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                AddNotification(error.ErrorCode, error.ErrorMessage, error.PropertyName, error.AttemptedValue);
        }

        public void Clear()
        {
            this._notifications.Clear();
        }

    }
}
