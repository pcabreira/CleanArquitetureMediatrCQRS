using MediatR;
using Microsoft.AspNetCore.Mvc;
using PessoasAptas.Application.Commands.CreateCriterio;
using PessoasAptas.Application.Queries.GetAllCriterios;
using System.Threading.Tasks;

namespace PessoasAptas.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CriterioController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CriterioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getAllPessoasQuery = new GetAllCriteriosQuery();

            var pessoas = await _mediator.Send(getAllPessoasQuery); 

            return Ok(pessoas);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCriterioCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(Get), new { id = id }, command);
        }
    }
}
