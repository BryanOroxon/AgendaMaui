using System;
using System.Net.Http.Json;
using AgendaMAUI.Models;

namespace AgendaMAUI.Services;

public class ConferenceMAUIService
{
    HttpClient httpClient;
    public ConferenceMAUIService()
    {
        this.httpClient = new HttpClient();
    }

    List<ConferenceDay> conferenceDayMAList;
    public async Task<List<ConferenceDay>> GetConferenceDay()
    {
        if (conferenceDayMAList?.Count > 0)
            return conferenceDayMAList;

        // Online
        var response = await httpClient.GetAsync("https://raw.githubusercontent.com/BryanOroxon/data/main/MauiDay.JSON");
        if (response.IsSuccessStatusCode)
        {
            conferenceDayMAList = await response.Content.ReadFromJsonAsync<List<ConferenceDay>>();
        }

        return conferenceDayMAList;
    }
}
