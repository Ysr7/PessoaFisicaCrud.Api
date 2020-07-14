using Core.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using Repository.Repositories;

namespace Repository {

    public class UnitOfWork : IUnitOfWork {
        private readonly IConfiguration _configuration;
        private readonly WG2RContext _context;
        private IPessoaFisicaRepository _PessoaFisicaRepository;
        private ITelefoneRepository _TelefoneRepository;
        public IPessoaFisicaRepository PessoaFisicaRepository
        {
            get {
                if (_PessoaFisicaRepository == null)
                    _PessoaFisicaRepository = new PessoaFisicaRepository(_context.PessoaFisicas, _context);
                return _PessoaFisicaRepository;
            }
            set { _PessoaFisicaRepository = value; }
        }

        public ITelefoneRepository TelefoneRepository
        {
            get {
                if (_TelefoneRepository == null)
                    _TelefoneRepository = new TelefoneRepository(_context.Telefones, _context);
                return _TelefoneRepository;
            }
            set { _TelefoneRepository = value; }
        }

         public UnitOfWork(WG2RContext context, IConfiguration configuration) 
        {
            _configuration = configuration;
            _context = context;
        }

         public void Commit() => _context.SaveChanges();

    }

}