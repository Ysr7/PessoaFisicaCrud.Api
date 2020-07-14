using System;

namespace Core.Entities
{
    public class Telefone 
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string DDD { get; set; }
        public int IdPessoaFisica { get; set; }
        public virtual PessoaFisica PessoaFisica { get; set; }
        public void Validar()
        {
            if (PessoaFisica == null)
                throw new ArgumentException("Pessoa é obrigatório para criar um telefone");

            if (string.IsNullOrEmpty(Numero))
                throw new ArgumentException("Número do telefone é obrigatório");

            if (string.IsNullOrEmpty(DDD))
                throw new ArgumentException("DDD do telefone é obrigatório");
        }
    }
}