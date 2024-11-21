

namespace MAUI_KP.Client;

public partial class Client : ContentPage
{
    public Client()
	{
		InitializeComponent();
        typePicker.ItemsSource = new string[] { "Квартира", "Участок" };
        real_estatePicker.ItemsSource = new string[] { "C#", "Java", "JavaScript" };
    }
   public void OnGoOutClicked(object sender, EventArgs e)
   {
        Application.Current.MainPage = new MainPage();
    }
}