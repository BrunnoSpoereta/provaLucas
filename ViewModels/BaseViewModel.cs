using System.Windows.Input;

namespace ProvaLuquinha.ViewModels
{
    public class BaseViewModel : BaseNotifyViewModel
    {
        public ICommand VoltarCommand { get; set; }

        private async void Voltar()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        //O voltar será privado pois não é necessario acessa-lo diretamente, pois temos o  VoltarCommand.
        //Executado direto pelo botão em tela, já o método abrirView precisa ser public pois não tem um Command e iremos chama-lo via backEnd e não via tela.

        public async void AbrirView(ContentPage View)
        {
            //Abriremos a tela recebida via parametro
            await Application.Current.MainPage.Navigation.PushAsync(View);
        }

        //Agora iremos vincular o método voltar com o Command
        public BaseViewModel()
        {
            VoltarCommand = new Command(Voltar);
        }
    }
}
