namespace Core.Interfaces.Repositories {
    public interface IUnitOfWork {
        IPessoaFisicaRepository PessoaFisicaRepository { get; set; }
        ITelefoneRepository TelefoneRepository { get; set; }
        void Commit ();
    }
}