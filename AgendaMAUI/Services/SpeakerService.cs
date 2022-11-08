namespace AgendaMAUI.Services;
public class SpeakerService
{
    HttpClient httpClient;
    public SpeakerService()
    {
        this.httpClient = new HttpClient();
    }

    List<Speaker> conferenceSpeakerList;
    public async Task<List<Speaker>> GetSpeakers()
    {
        if (conferenceSpeakerList?.Count > 0)
            return conferenceSpeakerList;

        // Online
        var response = await httpClient.GetAsync("https://raw.githubusercontent.com/BryanOroxon/data/main/Speakers.JSON");
        if (response.IsSuccessStatusCode)
        {
            conferenceSpeakerList = await response.Content.ReadFromJsonAsync<List<Speaker>>();
        }

        return conferenceSpeakerList;
    }
}

