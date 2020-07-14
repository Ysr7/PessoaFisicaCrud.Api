using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories {
    public class PessoaFisicaRepository : BaseRepository<PessoaFisica>, IPessoaFisicaRepository 
    {

        public PessoaFisicaRepository (DbSet<PessoaFisica> entity, WG2RContext context)
            : base (context, entity) 
            { 
            }
    }
}