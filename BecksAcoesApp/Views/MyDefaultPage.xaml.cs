namespace BecksAcoesApp.Views;

public partial class MyDefaultPage : ContentPage
{
	public MyDefaultPage()
	{
		InitializeComponent();
        if (DeviceInfo.Platform == DevicePlatform.Android || DeviceInfo.Platform == DevicePlatform.iOS)
        {
            // Example: Change padding for mobile
            this.Padding = new Thickness(10, 40, 10, 10);
        }
    }
}