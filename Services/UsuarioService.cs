using ProvaLuquinha.Models;

namespace ProvaLuquinha.Services
{
    public class UsuarioService
    {
        //Instanciar a classe singleton
        FakeDBSingleton dbSingleton = FakeDBSingleton.Instancia;

        public void Adicionar(Usuario value)
        {
            dbSingleton.Usuario = value;
        }

        public Usuario Consultar()
        {
            return dbSingleton.Usuario;
        }


    }
}
