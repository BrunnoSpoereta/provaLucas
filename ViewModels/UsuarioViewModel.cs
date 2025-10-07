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
        UsuarioService usuarioService = new UsuarioService();

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

        private async void Cadastrar()
        {
            Usuario usuario = new Usuario();
            usuario.Nome = Nome;
            usuario.CPF = CPF;
            usuario.Email = Email;
            usuario.Senha = Senha;
            usuario.DataNasc = DataNasc;

            //Agora iremos chamar o método Adicionar da classe de serviço
            usuarioService.Adicionar(usuario);
            await Application.Current.MainPage.DisplayAlert("Sucesso", "Cadastro realizado com Sucesso", "Ok");



            //Iremos abrir a tela de visualização
            AbrirView(new UsuarioLoginView());
        }

        public ICommand RegistrarCommand { get; set; }

        private void Registrar()
        {
            AbrirView(new UsuarioCadastroView());
        }

        //Iremos implementar a rotina de consulta
        public ICommand ConsultarCommand { get; set; }

        public void Consultar()
        {
            //Instanciar o objeto carro para recuperar o registro cadastro e atribuir o cadastro salvo
            Usuario usuario = usuarioService.Consultar();

            //Iremos popular as propriedades com o objeto
            Nome = usuario.Nome;
            CPF = usuario.CPF;
            Email = usuario.Email;
            Senha = usuario.Senha;
            DataNasc = usuario.DataNasc;
        }

        // Atualização de cadastro
        public ICommand AtualizarCommand { get; set; }

       void Atualizar()
        {
            Consultar();
            AbrirView(new UsuarioCadastroView());
        }


        // Validação (login) por Email e Senha
        public ICommand ValidarCommand { get; set; }

        private async void Validar()
        {
            var usuarioExistente = usuarioService.Consultar();

            if(usuarioExistente != null && usuarioExistente.Email == Email && usuarioExistente.Senha == Senha)
            {
                AbrirView(new PgPrincipalView());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Erro", "Email ou senha invalido", "Ok");
            }
        }

        public ICommand SalvarCommand { get; set; }

        private async void Salvar()
        {
            if(string.IsNullOrWhiteSpace(Nome) || string.IsNullOrWhiteSpace(CPF) ||string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Senha) || string.IsNullOrWhiteSpace(DataNasc))
            {
                await Application.Current.MainPage.DisplayAlert("Erro", "Preencha todos os campos obrigatorios.", "Ok");
                return;
            }

            Usuario usuario = new Usuario
            {
                Nome = Nome,
                CPF = CPF,
                Email = Email,
                Senha = Senha,
                DataNasc = DataNasc
            };

            usuarioService.Adicionar(usuario);
            await Application.Current.MainPage.DisplayAlert("Sucesso", "Cadastro salvo com sucesso", "Ok");
            await Application.Current.MainPage.Navigation.PopAsync();
        }


        //Iremos vincular os métodos aos commands
        public UsuarioViewModel()
        {
            CadastrarCommand = new Command(Cadastrar);
            ConsultarCommand = new Command(Consultar);
            ValidarCommand = new Command(Validar);
            AtualizarCommand = new Command(Atualizar);
            SalvarCommand = new Command(Salvar);
            RegistrarCommand = new Command(Registrar);
        }

    }
}
