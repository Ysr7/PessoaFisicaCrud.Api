using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    public class TelefoneRepository : BaseRepository<Telefone>, ITelefoneRepository
    {
        public TelefoneRepository(DbSet<Telefone> entity, WG2RContext context) 
            : base(context, context.Telefones) { }
    }
}