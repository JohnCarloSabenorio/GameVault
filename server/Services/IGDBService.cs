using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using server.Interfaces;
using server.Models;

namespace server.Services;


public class IGDBService : IIGDBService
{
    private readonly HttpClient _httpClient;
    public IGDBService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string?> GetVideoGamesAsync()
    {

        var query = "fields name; limit 20;";
        var content = new StringContent(query, Encoding.UTF8, "text/plain");

        var response = await _httpClient.PostAsync("games", content);

        var jsonString = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {

            return jsonString;
        }

        return null;
    }
}