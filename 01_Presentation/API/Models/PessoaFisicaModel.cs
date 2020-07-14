using System;
using Core.Entities;

namespace API.Models
{
    public class PessoaFisicaModel 
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime? Data { get; set; }
        public int Idade { get; set; }

        public PessoaFisicaModel() { }

        public PessoaFisicaModel(PessoaFisica pessoaFisica)
        {
            Id = pessoaFisica.Id;
            Nome = pessoaFisica.Nome;
            Email = pessoaFisica.Email;
            Idade = pessoaFisica.Idade;
            Data = pessoaFisica.Data;
        }
    }
}