using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Features.Users.Commands;

namespace ProductCenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : BaseController
    {

        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(SignUpCommand command)
        {
            await _mediator.Send(command);
            return Ok("User registered successfully.");
        }



    }
}
