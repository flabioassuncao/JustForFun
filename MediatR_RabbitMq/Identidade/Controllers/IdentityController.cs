using Core.Mediator;
using Identidade.Commands;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Identidade.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly IMediatorHandler _mediator;
        private readonly ILogger<IdentityController> _logger;
        protected ICollection<string> Erros = new List<string>();

        public IdentityController(
            IMediatorHandler mediator,
            ILogger<IdentityController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] [Required] RegisterUserCommand body)
        {
            var command = new RegisterUserCommand(body.Name, body.Email, body.Document, body.Password);

            var result = await _mediator.EnviarComando(command);

            foreach (var erro in result.Errors)
            {
                Erros.Add(erro.ErrorMessage);
            }

            if (!Erros.Any())
            {
                return Ok(result);
            }

            var algo = new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Mensagens", Erros.ToArray() }
            });

            return BadRequest(algo);
        }
    }

    public class RegisterDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        public string Password { get; set; }
    }
}