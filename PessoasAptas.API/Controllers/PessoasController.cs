using MediatR;
using Microsoft.AspNetCore.Mvc;
using PessoasAptas.Application.Commands.CreatePessoa;
using PessoasAptas.Application.Commands.CreatePessoaCriterio;
using PessoasAptas.Application.Queries.GetAllPessoas;
using System.Threading.Tasks;

namespace PessoasAptas.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PessoasController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PessoasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getAllPessoasQuery = new GetAllPessoasQuery();

            var pessoas = await _mediator.Send(getAllPessoasQuery); 

            return Ok(pessoas);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePessoaCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(Get), new { id = id }, command);
        }


        [HttpPost]
        public async Task<IActionResult> CreatePessoaCriterio([FromBody] CreatePessoaCriterioCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(Get), new { id = id }, command);
        }
    }
}
