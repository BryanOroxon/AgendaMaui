using AgendaMAUI.ViewModels;

namespace AgendaMAUI.Views;

public partial class MauiDayPage : ContentPage
{
    public MAUIDayViewModel viewModel;

	public MauiDayPage(MAUIDayViewModel vm)
	{
		InitializeComponent();
		BindingContext =vm;
	}
}