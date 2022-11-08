using AgendaMAUI.Views;

namespace AgendaMAUI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(SpeakerDetailPage), typeof(SpeakerDetailPage));
    }
}
