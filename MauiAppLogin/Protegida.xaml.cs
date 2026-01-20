namespace MauiAppLogin;

public partial class Protegida : ContentPage
{
	public Protegida()
	{
		InitializeComponent();

		string? usuario_logado = null;

		Task.Run(async () =>
		{
			usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");
			lbl_boasVindas.Text = $"Bem-vindo(a) {usuario_logado}";
		});
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		bool confirmaçao = await DisplayAlertAsync("Tem certeza?", "Sair do App", "Sim", "Não");

		if (confirmaçao)
		{
			SecureStorage.Default.Remove("usuario_logado");
			App.Current.MainPage = new Login();	
		}
    }
}