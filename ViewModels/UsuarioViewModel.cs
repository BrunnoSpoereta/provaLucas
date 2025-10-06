using System.Windows.Input;

namespace ProvaLuquinha.ViewModels
{
    public class UsuarioViewModel
    {
        //Importar a camada de Service
        //using Nome_Projeto.Services;

        //Instanciar a nossa camada de serviço
        CarroService carroService = new CarroService();

        //Precisamos herdar da classe BaseViewModel

        //Agora iremos implementar as propriedades dos campos que poderao ser usados em tela
        //Geralmente seguimos os atributos da classe referenciada, no caso a classe Carro
        //Mias conhecido como encapsulamento
        private string _marca;

        public string Marca
        {
            get { return _marca; }
            set { _marca = value; OnPropertyChanged(); }
        }

        private string _modelo;

        public string Modelo
        {
            get { return _modelo; }
            set { _modelo = value; OnPropertyChanged(); }
        }

        private string _cor;

        public string Cor
        {
            get { return _cor; }
            set { _cor = value; OnPropertyChanged(); }
        }

        //Precisamos criar as telas envolvidas
        //Cadastro e Visualização
        //Tela ja criada

        //Iremos implementar a rotina de cadastro
        public ICommand CadastrarCommand { get; set; }

        void Cadastrar()
        {
            Carro carro = new Carro();
            carro.Marca = Marca;
            carro.Modelo = Modelo;
            carro.Cor = Cor;

            //Agora iremos chamar o método Adicionar da classe de serviço
            carroService.Adicionar(carro);

            //Iremos abrir a tela de visualização
            AbrirView(new CarroVisualizacaoView());
        }

        //Iremos implementar a rotina de consulta
        public ICommand ConsultarCommand { get; set; }

        public void Consultar()
        {
            //Instanciar o objeto carro para recuperar o registro cadastro e atribuir o cadastro salvo
            Carro carro = carroService.Consultar();

            //Iremos popular as propriedades com o objeto
            Marca = carro.Marca;
            Modelo = carro.Modelo;
            Cor = carro.Cor;
        }

        //Iremos vincular os métodos aos commands
        public CarroViewModel()
        {
            CadastrarCommand = new Command(Cadastrar);
            ConsultarCommand = new Command(Consultar);
        }

    }
}
