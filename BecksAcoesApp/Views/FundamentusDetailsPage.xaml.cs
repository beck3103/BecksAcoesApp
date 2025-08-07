using BecksAcoesApp.ViewModels;

namespace BecksAcoesApp.Views;

public partial class FundamentusDetailsPage : ContentPage
{
	internal FundamentusDetailsPage(FundamentusDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}