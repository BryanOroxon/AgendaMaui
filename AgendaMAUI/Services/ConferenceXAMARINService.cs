namespace AgendaMAUI.Services;

public class ConferenceXAMARINService
{
    HttpClient httpClient;
    public ConferenceXAMARINService()
    {
        this.httpClient = new HttpClient();
    }

    List<ConferenceDay> conferenceDayXMList;
    public async Task<List<ConferenceDay>> GetConferenceDay()
    {
        if (conferenceDayXMList?.Count > 0)
            return conferenceDayXMList;

        // Online
        var response = await httpClient.GetAsync("https://raw.githubusercontent.com/BryanOroxon/data/main/XamarinDay.JSON");
        if (response.IsSuccessStatusCode)
        {
            conferenceDayXMList = await response.Content.ReadFromJsonAsync<List<ConferenceDay>>();
        }

        return conferenceDayXMList;
    }
}