namespace MauiAppLogin;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		try
		{

			List<DadosUsuario> list_usuarios = new List<DadosUsuario>()
			{
				new DadosUsuario()
				{
					Id = "José",
					senha = "123"
				},

				new DadosUsuario()
				{
					Id = "Maria",
					senha = "321"
				}
			};

			DadosUsuario dados_digitados = new DadosUsuario()
			{
				Id = text_usuario.Text,
				senha = text_senha.Text
			};

			//LINQ
			if (list_usuarios.Any(i => (dados_digitados.Id == i.Id && dados_digitados.senha == i.senha)))
			{
				await SecureStorage.Default.SetAsync("usuario_logado", dados_digitados.Id);

				App.Current.MainPage = new Protegida();
			}

			else
			{
				throw new Exception("Usuário ou senha incorretos.");
			}

		}
		catch(Exception ex) 
		{
			await DisplayAlertAsync("Ops", ex.Message, "Fechar");
		}
    }
}