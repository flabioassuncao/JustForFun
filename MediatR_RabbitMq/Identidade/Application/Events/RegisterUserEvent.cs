using Core.Messages;

namespace Identidade.Application.Events
{
    public class RegisterUserEvent : Event
    {
        public RegisterUserEvent(string name, string email, string document, string password)
        {
            Name = name;
            Email = email;
            Document = document;
            Password = password;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        public string Password { get; set; }
    }
}
