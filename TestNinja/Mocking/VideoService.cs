using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        // EXAMPLE OF CONSTRUCTOR DEPENDENCY INJECTION
        private IFileReader _fileReader;
        private IVideoRepository _repository;

        // This ctor approach doesn't break the ctor of "Property Dependency Injection" example
        // But also allows us to use it for Constructor Dependency Injection for tests
        // So it preserves the production code and allows test code to work as well
        public VideoService(IFileReader fileReader = null, IVideoRepository repository = null) // AKA Poor man's dependency injection

        {
            // C# Null Coalescing - simplifies checking for null objects
            // reads as 
            // if fileReader is null create new FileReader();
            // else use fileReader parameter
            _fileReader = fileReader ?? new FileReader();
            _repository = repository ?? new VideoRepository();
        }

        public string ReadVideoTitle()
        {
            var str = _fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        // EXAMPLE OF PROPERTY DEPENDENCY INJECTION
        //public IFileReader FileReader { get; set; }

        //public VideoService()
        //{
        //    FileReader = new FileReader();
        //}

        //public string ReadVideoTitle()
        //{
        //    var str = FileReader.Read("video.txt");
        //    var video = JsonConvert.DeserializeObject<Video>(str);
        //    if (video == null)
        //        return "Error parsing the video.";
        //    return video.Title;
        //}

        // EXAMPLE OF METHOD PARAMETER DEPENDENCY INJECTION
        //public string ReadVideoTitle(IFileReader fileReader)
        //{
        //    var str = fileReader.Read("video.txt");
        //    var video = JsonConvert.DeserializeObject<Video>(str);
        //    if (video == null)
        //        return "Error parsing the video.";
        //    return video.Title;
        //}

        //Testing paths
        //[] => ""
        //[{}, {}, {}] => "1,2,3"
        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();

            var videos = _repository.GetUnprocessedVideos();

            foreach (var v in videos)
                videoIds.Add(v.Id);

            return String.Join(",", videoIds);
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}