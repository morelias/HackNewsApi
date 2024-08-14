using HackersNewApi.Application.Dtos;
using HackersNewApi.Domian.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackersNewApi.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class BestStoriesController : ControllerBase
    {

        private readonly ILogger<BestStoriesController> _logger;
        private readonly IHackerNewsApiService _hackerNewsApiService;

        public BestStoriesController(ILogger<BestStoriesController> logger, IHackerNewsApiService hackerNewsApiService)
        {
            _logger = logger;
            _hackerNewsApiService = hackerNewsApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Int16? limit)
        {
            if(!limit.HasValue)
                return BadRequest("Please provide a limit of records to return");

            if (limit <= 0)
                return NoContent();

            try
            {
                List<BestStoryDto> bestStories = new List<BestStoryDto>();

                var bestStoriesIdsList = await _hackerNewsApiService.GetBestStoriesIdsAsync(limit);

                foreach (Int64 id in bestStoriesIdsList)
                {
                    var storyItem = await _hackerNewsApiService.GetItemAsync(id);

                    DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(storyItem.time);

                    bestStories.Add(new BestStoryDto()
                    {
                        title = storyItem.title,
                        uri = storyItem.url,
                        postedBy = storyItem.by,
                        time = dateTime,
                        score = storyItem.score,
                        commentCount = storyItem.descendants
                    });
                }

                return Ok(bestStories.OrderByDescending(obj => obj.score).ToList());
            }
            catch (Exception)
            {

                return BadRequest("The service could not been provided, Try later please!");
            }            
        }
    }
}
