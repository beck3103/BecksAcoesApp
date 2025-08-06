using BeckAcoesApp.Application.Interfaces.Http;

namespace BecksAcoesApp.Views;

public partial class MyDefaultPage : ContentPage
{
    private readonly IBeckAcoesApiClient _httpClient;

    public MyDefaultPage(IBeckAcoesApiClient beckAcoesApiClient)
    {
        InitializeComponent();
        _httpClient = beckAcoesApiClient;
        if (DeviceInfo.Platform == DevicePlatform.Android || DeviceInfo.Platform == DevicePlatform.iOS)
        {
            // Example: Change padding for mobile
            this.Padding = new Thickness(10, 40, 10, 10);
        }
    }

    private async void OnButtonClicked(object sender, EventArgs e)
    {
        var responseToken = await _httpClient.GetBearerToken("your_username", "your_password");

        if (responseToken is null)
        {
            await DisplayAlert("Error", "Token invalid", "OK");
            return;
        }

        var ticket = IbovespaTicket.Text;

        if (string.IsNullOrWhiteSpace(ticket))
        {
            await DisplayAlert("Error", "Ticket invalid", "OK");
            return;
        }

        var result = await _httpClient.GetFundamentusDataAsync(ticket, responseToken.Token);

        if (result == null)
        {
            await DisplayAlert("Error", "Failed to retrieve data", "OK");
            return;
        }

        await Shell.Current.Navigation.PushAsync(new FundamentusDetailsPage(result));
    }
}