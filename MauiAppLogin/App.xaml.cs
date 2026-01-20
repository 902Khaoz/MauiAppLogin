namespace MauiAppLogin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Iniciamos a verificação assíncrona
            VerificarLogin();
        }

        private async void VerificarLogin()
        {
            try
            {
                // Busca o dado sem travar a interface
                string? usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");

                // Garante que a troca de página ocorra na Thread de UI
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    if (usuario_logado == null)
                    {
                        MainPage = new Login();
                    }
                    else
                    {
                        MainPage = new Protegida();
                    }
                });
            }
            catch (Exception ex)
            {
                // Tratamento de erro básico caso o SecureStorage falhe
                MainPage = new Login();
            }
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);

            window.Width = 400;
            window.Height = 600;

            return window;
        }
    }
}