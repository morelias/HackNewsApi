using HackersNewApi.Domian.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HackersNewApi.Domian.Interfaces
{
    public interface IHackerNewsApiService
    {
        Task<IEnumerable<Int64>> GetBestStoriesIdsAsync(Int16? limit);
        Task<HackersNewsItem> GetItemAsync(Int64 id);
    }
}
