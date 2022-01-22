using Core.Messages;
using FluentValidation;
using System.Runtime.Serialization;

namespace Identidade.Commands
{
    [DataContract]
    public class RegisterUserCommand : Command
    {
        public RegisterUserCommand(string name, string email, string document, string password)
        {
            Name = name;
            Email = email;
            Document = document;
            Password = password;
        }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "document")]
        public string Document { get; set; }

        [DataMember(Name = "password")]
        public string Password { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new RegisterUserValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class RegisterUserValidation : AbstractValidator<RegisterUserCommand>
        {
            public RegisterUserValidation()
            {
                RuleFor(x => x.Name)
                    .NotEmpty()
                    .WithMessage("Nome nao pode ser null");

                RuleFor(x => x.Email)
                    .NotEmpty()
                    .WithMessage("Email nao pode ser null");

                RuleFor(x => x.Password)
                    .NotEmpty()
                    .WithMessage("Pass nao pode ser empty");

                RuleFor(x => x.Password)
                    .NotNull()
                    .WithMessage("Pass nao pode ser null");
            }
        }
    }
}
