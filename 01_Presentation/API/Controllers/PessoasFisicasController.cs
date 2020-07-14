using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoasFisicasController : ControllerBase 
    {
        private readonly IPessoaFisicaService _pessoaFisicaService;

        public PessoasFisicasController(IPessoaFisicaService pessoaFisicaService) => 
            _pessoaFisicaService = pessoaFisicaService;

        [HttpGet("{id}")]
        public  IActionResult ConsultarAsync(int id) => 
            Ok(new PessoaFisicaModel(_pessoaFisicaService.Consultar(id)));

        [HttpGet()]
        public  IActionResult ConsultarTotal() => 
            Ok(_pessoaFisicaService.ConsultarTotal().Select(pessoaFisica => new PessoaFisicaModel(pessoaFisica)));

        [HttpPost]
        public async Task<IActionResult> CadastrarAsync([FromBody] PessoaFisicaModel pessoaFisica) =>
             Ok(await _pessoaFisicaService.AdicionarAsync(pessoaFisica.Nome, pessoaFisica.Email, pessoaFisica.Idade));

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id) 
        {
            _pessoaFisicaService.Excluir(id);
            return Ok();
        } 

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarAsync(int id, [FromBody] PessoaFisicaModel pessoaFisica) {
            await _pessoaFisicaService.AtualizarAsync(
                id,
                pessoaFisica.Nome,
                pessoaFisica.Email,
                pessoaFisica.Idade
            );
            return Ok();
        }

        [HttpGet("{id}/telefones")]
        public IActionResult TelefonesAsync(int id, int skip, int take) =>
            Ok(
                (_pessoaFisicaService.ObterTelefones(id, skip, take))
                    .Select(item => new TelefoneModel(item))
            );

        [HttpPost("{id}/telefones")]
        public async Task<IActionResult> TelefonesAsync(int id, [FromBody]TelefoneModel telefone) =>
            Ok(await _pessoaFisicaService.AdicionarTelefoneAsync(
                id, telefone.Numero, telefone.DDD
            ));
    }
}
