using Core.Mediator;
using Core.Messages;
using FluentValidation.Results;
using Identidade.Application.Events;
using MediatR;

namespace Identidade.Commands
{
    public class RegisterUserCommandHandler :
        CommandHandler, IRequestHandler<RegisterUserCommand, ValidationResult>
    {
        private readonly IMediatorHandler _mediatorHandler;

        public RegisterUserCommandHandler(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        public async Task<ValidationResult> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            // Validação do comando
            if (!command.EhValido()) return command.ValidationResult;

            var @event = new RegisterUserEvent(command.Name, command.Email, command.Document, command.Password);

            await _mediatorHandler.PublicarEvento(@event);

            return new ValidationResult();
        }
    }
}