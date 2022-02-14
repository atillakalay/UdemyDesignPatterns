using BaseProject.Models;

namespace WebApp.Observer.Events
{
    public class UserCreatedEvent : INotification
    {
        public AppUser AppUser { get; set; }
    }
}