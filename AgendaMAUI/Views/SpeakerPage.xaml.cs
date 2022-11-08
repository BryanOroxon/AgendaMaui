
namespace AgendaMAUI.Views;

public partial class SpeakerPage : ContentPage
{
    public SpeakerViewModel viewModel;
    public SpeakerPage(SpeakerViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }

    private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        var speaker = ((VisualElement)sender).BindingContext as Speaker;

        if (speaker == null)
            return;
        await Shell.Current.GoToAsync(nameof(SpeakerDetailPage), true, new Dictionary<string, object>
        {
            {"Speaker", speaker }
        });
    }
}
