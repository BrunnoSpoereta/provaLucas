namespace ProvaLuquinha.Views;
using ProvaLuquinha.ViewModels;

public partial class PgPrincipalView : ContentPage
{
	public PgPrincipalView()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        
        if (BindingContext is UsuarioViewModel viewModel)
        {
            viewModel.Consultar();
        }
    }
}