using System.Threading.Tasks;
using RideAway.Application.DTOs.Notification;

namespace RideAway.Application.IServices.INotification
{
    public interface INotificationService
    {
        Task SendNotificationAsync(NotificationDTO notification);
    }
}
