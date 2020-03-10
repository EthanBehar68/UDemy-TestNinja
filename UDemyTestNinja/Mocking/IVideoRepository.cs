using System.Collections.Generic;

namespace UDemyTestNinja.Mocking
{
    public interface IVideoRepository
    {
        IEnumerable<Video> GetUnprocessedVideos();
    }
}