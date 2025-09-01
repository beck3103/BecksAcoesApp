using BeckAcoesApp.Application.Interfaces.Services;
using BecksAcoesApp.Converters;

namespace BecksAcoesApp.Views;

public partial class MyDefaultPage : ContentPage
{
    private readonly IFundamentusAppService _fundamentusAppService;

    public MyDefaultPage(IFundamentusAppService fundamentusAppService)
    {
        InitializeComponent();
        _fundamentusAppService = fundamentusAppService;

        if (DeviceInfo.Platform == DevicePlatform.Android || DeviceInfo.Platform == DevicePlatform.iOS)
        {
            // Example: Change padding for mobile
            this.Padding = new Thickness(10, 40, 10, 10);
        }
    }

    private async void OnButtonClicked(object sender, EventArgs e)
    {
        var ticket = IbovespaTicket.Text;

        if (string.IsNullOrWhiteSpace(ticket))
        {
            await DisplayAlert("Error", "Ticket invalid", "OK");
            return;
        }

        var result = await _fundamentusAppService.GetFundamentusDataAsync(ticket);

        if (result == null)
        {
            await DisplayAlert("Error", "Failed to retrieve data", "OK");
            return;
        }

        decimal precoJusto = _fundamentusAppService.CalculateFairPrice(result.NetIncome, result.ShareholdersEquity, result.NumberOfShares);
        decimal precoTeto = _fundamentusAppService.CalculateMaximumPrice(result.DividendYield, result.CurrentPrice);

        var viewModel = result.ToFundamentusDetailsViewModel(precoJusto, precoTeto);
        await Shell.Current.Navigation.PushAsync(new FundamentusDetailsPage(viewModel));
    }
}