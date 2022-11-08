namespace AgendaMAUI.ViewModels;

[QueryProperty(nameof(Speaker), "Speaker")]
public partial class SpeakerDetailViewModel : BaseViewModel
{
	public SpeakerDetailViewModel()
	{
	}

    [ObservableProperty]
    Speaker speaker;
}

