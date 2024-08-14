using HackersNewApi.Domian.Entities;
using HackersNewApi.Domian.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HackersNewApiTest
{
    [TestFixture]
    public class HackerNewsApiTest
    {

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Get_Single_Story()
        {
            //Arrange
            var mockHackersNewApiService = new Mock<IHackerNewsApiService>();

            mockHackersNewApiService.Setup(s => s.GetBestStoriesIdsAsync(It.IsAny<short?>()))
                                    .ReturnsAsync((Int16 limit) => new List<Int64>() { 1 });
            //Act
            var service = mockHackersNewApiService.Object;
            var result = service.GetBestStoriesIdsAsync(1);

            //Assert
            Assert.AreEqual(result.Result.Count(), 1);
        }

        [Test]
        public void Get_Multiple_Stories()
        {
            //Arrange
            var mockHackersNewApiService = new Mock<IHackerNewsApiService>();

            mockHackersNewApiService.Setup(s => s.GetBestStoriesIdsAsync(It.IsAny<short?>()))
                                    .ReturnsAsync((Int16 limit) => new List<Int64>() { 1, 2, 3 });
            //Act
            var service = mockHackersNewApiService.Object;
            var result = service.GetBestStoriesIdsAsync(1);

            //Assert
            Assert.Greater(result.Result.Count(), 0);
        }

        [Test]
        public void Get_Story_Details()
        {
            //Arrange
            var mockHackersNewApiService = new Mock<IHackerNewsApiService>();

            mockHackersNewApiService.Setup(s => s.GetItemAsync(It.IsAny<long>()))
                                    .ReturnsAsync((Int64 id) => new HackersNewsItem() {
                                        id = 1000,
                                        deleted = false,
                                        type = "story",
                                        by = "jhonDoe",
                                        time = 10000000,
                                        text = "This os for testing purpose",
                                        dead = false,
                                        parent = 1,
                                        poll = 500,
                                        kids = new List<Int64>() { 1001,1002,1003 },
                                        url = "www.fakeData.com",
                                        score = 500,
                                        title = "Hacker News Test",
                                        parts = new List<int>() { 100,200,300 },
                                        descendants = 100
                                     });
            //Act
            var service = mockHackersNewApiService.Object;
            var result = service.GetItemAsync(1);

            //Assert
            Assert.IsNotNull(result);
        }
    }
}