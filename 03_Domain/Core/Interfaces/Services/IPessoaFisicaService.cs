using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Repositories 
{
    public interface IPessoaFisicaService {
        PessoaFisica Consultar(int idPessoaFisica);
        IEnumerable<PessoaFisica> ConsultarTotal();
        Task<int> AdicionarAsync(string nome, string email, int? idade);
        Task AtualizarAsync(int idPessoaFisicaAAtualizar, string nome, string email, int idade);
        void Excluir(int idPessoaFisica);
        Task<int> AdicionarTelefoneAsync(int idPessoaFisica, string numero, string ddd);
        IEnumerable<Telefone> ObterTelefones(int idPessoaFisica, int skip, int take);
    }
}