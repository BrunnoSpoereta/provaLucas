namespace ProvaLuquinha.Models
{
    public sealed class FakeDBSingleton
    {
        static FakeDBSingleton _instancia;

        public static FakeDBSingleton Instancia
        {
            get { return _instancia ?? (_instancia = new FakeDBSingleton()); }
        }

        //Atributo que ira armazenar o objeto com as informações de Carro (classe Carro)
        public Usuario Usuario { get; set; }
    }
}
