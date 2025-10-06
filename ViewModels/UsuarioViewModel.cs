using ProvaLuquinha.Services;
using System.Windows.Input;
using ProvaLuquinha.Models;
using ProvaLuquinha.Services;
using ProvaLuquinha.Views;
using System.Windows.Input;

namespace ProvaLuquinha.ViewModels
{
    public class UsuarioViewModel : BaseViewModel
    {
        //Importar a camada de Service
        //using Nome_Projeto.Services;

        //Instanciar a nossa camada de serviço
        UsuarioService carroService = new UsuarioService();

        //Precisamos herdar da classe BaseViewModel

        //Agora iremos implementar as propriedades dos campos que poderao ser usados em tela
        //Geralmente seguimos os atributos da classe referenciada, no caso a classe Carro
        //Mias conhecido como encapsulamento
        private string _nome;

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; OnPropertyChanged(); }
        }

        private string _cpf;

        public string CPF
        {
            get { return _cpf; }
            set { _cpf = value; OnPropertyChanged(); }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(); }
        }

        private string _senha;

        public string Senha
        {
            get { return _senha; }
            set { _senha = value; OnPropertyChanged(); }
        }

        private string _datanasc;

        public string DataNasc
        {
            get { return _datanasc; }
            set { _datanasc = value; OnPropertyChanged(); }
        }

        //Precisamos criar as telas envolvidas
        //Cadastro e Visualização
        //Tela ja criada

        //Iremos implementar a rotina de cadastro
        public ICommand CadastrarCommand { get; set; }

        void Cadastrar()
        {
            Usuario usuario = new Usuario();
            usuario.Nome = Nome;
            usuario.CPF = CPF;
            usuario.Email = Email;
            usuario.Senha = Senha;
            usuario.DataNasc = DataNasc;

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
