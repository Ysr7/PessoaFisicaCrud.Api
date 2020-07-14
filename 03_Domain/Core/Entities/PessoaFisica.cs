using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class PessoaFisica
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Idade { get; set; }
        public DateTime Data { get; set; }
        public virtual IEnumerable<Telefone> Telefones { get; set; }
    }
}
