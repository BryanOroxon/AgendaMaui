using System.Diagnostics;
using AgendaMAUI.Views;

namespace AgendaMAUI.ViewModels;

public partial class SpeakerViewModel : BaseViewModel
{
    public ObservableCollection<Speaker> SpeakersConf{ get; } = new();
    SpeakerService speakerService;
    public SpeakerViewModel(SpeakerService speakerService)
    {
        Title = "Our Amazing Speakers";
        this.speakerService = speakerService;

    }

    [ObservableProperty]
    bool isRefreshing = true;

    [ObservableProperty]
    Speaker selectedSpeaker;
  
    [RelayCommand]
    async Task GetSpeakerAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            Console.WriteLine("Search for Speakers");

            var speakerConf = await speakerService.GetSpeakers();

            if (SpeakersConf.Count != 0)
                SpeakersConf.Clear();

            foreach (var SC in speakerConf)
                SpeakersConf.Add(SC);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get Speakers conferences: {ex.Message}");
            Console.WriteLine("No encontramos Speakers");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        }

    }

    [RelayCommand]
    async Task GoToDetails()
    {
        if (selectedSpeaker == null)
            return;

        var data = new Dictionary<string, object>
        {
            {"Speaker", selectedSpeaker }
        };

        await Shell.Current.GoToAsync(nameof(SpeakerDetailPage), true, data);
    }

}
