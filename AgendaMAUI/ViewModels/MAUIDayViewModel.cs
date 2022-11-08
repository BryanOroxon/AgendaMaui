using System.Diagnostics;
using AgendaMAUI.Services;

namespace AgendaMAUI.ViewModels;

public partial class MAUIDayViewModel: BaseViewModel
{
    public ObservableCollection<ConferenceDay> MauiConfDay { get; } = new();
    ConferenceMAUIService mauiService;
    public MAUIDayViewModel(ConferenceMAUIService speakerService)
    {
        Title = "Welcome to MAUI Day";
        this.mauiService = speakerService;

    }

    [ObservableProperty]
    bool isRefreshing = true;

    [ObservableProperty]
    ConferenceDay selectedDay;

    [RelayCommand]
    async Task GetMAUIDayAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            Console.WriteLine("Search for MAUI Schedule");

            var mauiConfDays = await mauiService.GetConferenceDay();  

            if (MauiConfDay.Count != 0)
                MauiConfDay.Clear();

            foreach (var MCD in mauiConfDays)
                MauiConfDay.Add(MCD);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get MAUI conferences: {ex.Message}");
            Console.WriteLine("No encontramos conferencias");
                        await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        }

    }

}
