using BaseProject.Models;

namespace WebApp.Observer.Events
{
    public class UserCreatedEvent
    {
        public AppUser AppUser { get; set; }
    }
}