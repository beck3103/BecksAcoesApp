using Infra.Http.Dtos;

namespace BecksAcoesApp.Views;

public partial class FundamentusDetailsPage : ContentPage
{
	public FundamentusDetailsPage(FundamentusDto fundamentusDto)
	{
		InitializeComponent();
		BindingContext = fundamentusDto;
    }
}