using Core.Entities;

namespace API.Models
{
    public class TelefoneModel 
    {
        public int? Id { get; set; }
        public string Numero { get; set; }
        public string DDD { get; set; }

        public TelefoneModel() { }

        public TelefoneModel(Telefone telefone)
        {
            Id = telefone.Id;
            Numero = telefone.Numero;
            DDD = telefone.DDD;
        }
    }
}