using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;


namespace Services
{
    public class PessoaFisicaService : IPessoaFisicaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PessoaFisicaService(
            IUnitOfWork unitOfWork
        )
        {
            _unitOfWork = unitOfWork;
        }

        public PessoaFisica Consultar(int idPessoaFisica) =>
            _unitOfWork.PessoaFisicaRepository.FirstOrDefault(item => item.Id == idPessoaFisica);

        public IEnumerable<PessoaFisica> ConsultarTotal() =>
            _unitOfWork.PessoaFisicaRepository.GetAll();

        public async Task<int> AdicionarAsync(string nome, string email, int? idade) 
        {
            if (!idade.HasValue)
                throw new ArgumentException("Idade é obrigatória");

            var pessoaFisica = new PessoaFisica {
                Nome = nome,
                Email = email,
                Data = DateTime.Now,
                Idade = idade.Value
            };

            await _unitOfWork.PessoaFisicaRepository.AddAsync(pessoaFisica);
            _unitOfWork.Commit();

            return pessoaFisica.Id;
        }

        public async Task AtualizarAsync(int idPessoaFisica, string nome, string email, int idade) 
        {
            PessoaFisica pessoa = Consultar(idPessoaFisica);

            pessoa.Nome = nome;
            pessoa.Email = email;
            pessoa.Idade = idade;

            await  _unitOfWork.PessoaFisicaRepository.UpdateAsync(pessoa);
            _unitOfWork.Commit();
        }

        public void Excluir(int idPessoaFisica) 
        {
            PessoaFisica pessoa = Consultar(idPessoaFisica);
            _unitOfWork.PessoaFisicaRepository.Delete(pessoa);
            _unitOfWork.Commit();
        }

        public async Task<int> AdicionarTelefoneAsync(int idPessoaFisica, string numero, string ddd) 
        {
            PessoaFisica pessoa = Consultar(idPessoaFisica)
                ?? throw new ArgumentNullException("Pessoa física não encontrada");

            var telefone = new Telefone {
                PessoaFisica = pessoa,
                Numero = numero,
                DDD = ddd
            };

            telefone.Validar();

            await _unitOfWork.TelefoneRepository.AddAsync(telefone);
            _unitOfWork.Commit();

            return telefone.Id;
        }

        public IEnumerable<Telefone> ObterTelefones(int idPessoaFisica, int skip, int take) 
        {
            if (!_unitOfWork.PessoaFisicaRepository.Exists(item => item.Id == idPessoaFisica))
                throw new ArgumentNullException("Pessoa física não encontrada");

            return _unitOfWork.TelefoneRepository.Where(item => item.IdPessoaFisica == idPessoaFisica);
        }
    }
}
