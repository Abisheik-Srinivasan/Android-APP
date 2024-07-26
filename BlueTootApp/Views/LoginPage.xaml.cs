namespace BlueTootApp.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void onLoginButton_Clicked(object sender, EventArgs e)
    {
        if (UsernameEntry.Text == null && PasswordEntry.Text == null)
        {
            await Navigation.PushAsync(new BluetoothManager());
        }
        else
        {
            await DisplayAlert("Login Failed", "Invalid username or password", "OK");
        }
    }
}