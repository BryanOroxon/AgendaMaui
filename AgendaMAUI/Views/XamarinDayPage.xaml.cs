namespace AgendaMAUI.Views;

public partial class XamarinDayPage : ContentPage
{
    public XamarinDayViewModel viewModel;

	public XamarinDayPage(XamarinDayViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}