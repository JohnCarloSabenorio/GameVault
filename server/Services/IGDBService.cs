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

        var query = "fields age_ratings,aggregated_rating,aggregated_rating_count,alternative_names,artworks,bundles,category,checksum,collection,collections,cover,created_at,dlcs,expanded_games,expansions,external_games,first_release_date,follows,forks,franchise,franchises,game_engines,game_localizations,game_modes,game_status,game_type,genres,hypes,involved_companies,keywords,language_supports,multiplayer_modes,name,parent_game,platforms,player_perspectives,ports,rating,rating_count,release_dates,remakes,remasters,screenshots,similar_games,slug,standalone_expansions,status,storyline,summary,tags,themes,total_rating,total_rating_count,updated_at,url,version_parent,version_title,videos,websites; limit 20;";

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