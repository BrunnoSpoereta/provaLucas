namespace ProvaLuquinha.Views;
using ProvaLuquinha.ViewModels;

public partial class PgPrincipalView : ContentPage
{
    public PgPrincipalView()
    {
        InitializeComponent();
        // Instanciar o ViewModel no code-behind para ter controle sobre quando os dados s�o carregados
        BindingContext = new UsuarioViewModel();
    }
}