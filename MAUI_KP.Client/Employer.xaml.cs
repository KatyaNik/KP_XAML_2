namespace MAUI_KP.Client;

public partial class Employer : ContentPage
{
	public Employer()
	{
		InitializeComponent();
        typePicker.ItemsSource = new string[] { "Квартира", "Участок" };
    }
    public void OnGoOutClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new MainPage();
    }
}