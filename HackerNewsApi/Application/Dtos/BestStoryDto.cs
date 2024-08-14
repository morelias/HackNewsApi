using System;

namespace HackersNewApi.Application.Dtos
{
    public class BestStoryDto
    {
        public string title { get; set; }
        public string uri { get; set; }
        public string postedBy { get; set; }
        public DateTime time { get; set; }
        public Int32 score { get; set; }
        public Int16 commentCount { get; set; }
    }
}
