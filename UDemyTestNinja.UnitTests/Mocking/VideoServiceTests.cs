using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using UDemyTestNinja.Mocking;

namespace UDemyTestNinja.UnitTests.Mocking
{
    [TestFixture]
    class VideoServiceTests
    {

        // EXAMPLE OF USING MOQ
        private Mock<IFileReader> _fileReader;
        private Mock<IVideoRepository> _repository;
        private VideoService _videoService;


        [SetUp]
        public void SetUp()
        {
            _fileReader = new Mock<IFileReader>();
            _repository = new Mock<IVideoRepository>();
            _videoService = new VideoService(_fileReader.Object, _repository.Object);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnErrorMessage()
        {
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            var result = _videoService.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        // EXAMPLE OF CONSTRUCTOR DEPENDENCY INJECTION
        //public void ReadVideoTitle_EmptyFile_ReturnErrorMessage()
        //{
        //    var service = new VideoService(new FakeFileReader());

        //    var result = service.ReadVideoTitle();

        //    Assert.That(result, Does.Contain("error").IgnoreCase);
        //}

        // EXAMPLE OF PROPERTY DEPENDENCY INJECTION
        //public void ReadVideoTitle_EmptyFile_ReturnErrorMessage()
        //{
        //    var service = new VideoService();
        //    service.FileReader = new FakeFileReader();

        //    var result = service.ReadVideoTitle();

        //    Assert.That(result, Does.Contain("error").IgnoreCase);
        //}

        // EXAMPLE OF METHOD PARAMETER DEPENDENCY INJECTION
        //public void ReadVideoTitle_EmptyFile_ReturnErrorMessage()
        //{
        //    var service = new VideoService();

        //    var result = service.ReadVideoTitle(new FakeFileReader());

        //    Assert.That(result, Does.Contain("error").IgnoreCase);
        //}

        [Test]
        public void GetUnprocessedVideosAsCsv_AllVideosAreProcessed_ReturnAnEmptyString()
        {
            _repository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>());

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AFewUnprocessedVideos_ReturnAStringWithIdOfUnprocessedVideos()
        {
            _repository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>
            {
                new Video { Id = 1 },
                new Video { Id = 2 },
                new Video { Id = 3 }
            });

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("1,2,3"));
        }

    }
}
