using MediatR;

namespace Identidade.Application.Events
{
    public class RegisterUserEventHandler : INotificationHandler<RegisterUserEvent>
    {
        //private readonly IMessageBus _bus;

        //public RegisterUserEventHandler(IMessageBus bus)
        //{
        //    _bus = bus;
        //}

        public async Task Handle(RegisterUserEvent message, CancellationToken cancellationToken)
        {
            //await _bus.PublishAsync(new PedidoRealizadoIntegrationEvent(message.ClienteId));
            Task.CompletedTask.Wait();
        }
    }
}
