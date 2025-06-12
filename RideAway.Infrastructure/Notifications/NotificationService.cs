using System.Threading.Tasks;
using RideAway.Application.DTOs.Notification;
using RideAway.Application.IServices.INotification;

namespace RideAway.Infrastructure.Notifications
{
    public class NotificationService : INotificationService
    {
        public Task SendNotificationAsync(NotificationDTO notification)
        {
            // TODO: Integrate with real notification system (SignalR, push, etc.)
            // For now, just simulate async notification delivery
            return Task.CompletedTask;
        }
    }
}
