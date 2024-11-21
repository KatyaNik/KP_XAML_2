using MAUI_KP.Shared.Services;

namespace MAUI_KP.Client
{
    public partial class MainPage : ContentPage
    {
      
        
        
        public MainPage()
        {
            InitializeComponent();
        }
        public void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new Registration();//Открывает страничку риелтора
        }
        private void OnLoginButtonClicked(object sender, EventArgs e)
        {
            //Application.Current.MainPage = new Client();//Открывает страничку клиента
            Application.Current.MainPage = new Employer();//Открывает страничку риелтора
        }
    }

}
