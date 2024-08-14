using HackersNewApi.Domian.Entities;
using HackersNewApi.Domian.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace HackersNewApi.Infrastructure
{
    public class HackerNewsApiService : IHackerNewsApiService
    {
        private readonly HttpClient _httpClient;
        private readonly AppConfigurations _appConfigurations;

        public HackerNewsApiService(HttpClient httpClient, AppConfigurations appConfigurations)
        {
            _httpClient = httpClient;
            _appConfigurations = appConfigurations;
        }

        public async Task<IEnumerable<Int64>> GetBestStoriesIdsAsync(Int16? limit)
        {
            var result = await _httpClient.GetAsync($"{_appConfigurations.hackBestStoriesUrl}?print=pretty&limitToFirst={limit}&orderBy=\"$key\"");
            var responseJson = result.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<IEnumerable<Int64>>(responseJson.Result);

            return response;
        }

        public async Task<HackersNewsItem> GetItemAsync(long id)
        {
            var result = await _httpClient.GetAsync($"{_appConfigurations.hackItemUrl}/{id}.json");
            var responseJson = result.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<HackersNewsItem>(responseJson.Result);

            return response;
        }
    }
}
