using System.Diagnostics;
using AgendaMAUI.Services;

namespace AgendaMAUI.ViewModels;

public partial class XamarinDayViewModel: BaseViewModel
{
    public ObservableCollection<ConferenceDay> XamConfDay { get; } = new();
    ConferenceXAMARINService xamService;
    public XamarinDayViewModel(ConferenceXAMARINService xamService)
    {
        Title = "Choose your next big friend";
        this.xamService = xamService;

    }

    [ObservableProperty]        
    bool isRefreshing = true;

    [RelayCommand]
    async Task GetXamDayAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            Console.WriteLine("Buscando Conferencias");

            var xamConfDays = await xamService.GetConferenceDay();

            if (XamConfDay.Count != 0)
                XamConfDay.Clear();

            foreach (var XCD in xamConfDays)
                XamConfDay.Add(XCD);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get Conferences: {ex.Message}");
            Console.WriteLine("No encontramos Conferencias");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        }

    }

    
}