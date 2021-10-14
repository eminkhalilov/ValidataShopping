using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ValidataShopping.Application.Service;

namespace ValidataShopping.API.Service
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase 
    {
        public IMediator _mediator;

        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> PopulateDb()
        {
            await _mediator.Send(new PopulateDbCommand());
            return Created(string.Empty, null);
        }
    }
}