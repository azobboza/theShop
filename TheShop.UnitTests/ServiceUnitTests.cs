using System;
using NUnit.Framework;
using Moq;
using TheShop.Contracts;
using TheShop.Entities;

namespace TheShop.UnitTests
{
    public class ServiceUnitTests
    {
        private readonly int Id = 1;
        private readonly double maxExpectedPrice = 100;
        private Mock<IOrderService> _mockOrderService;
        private Mock<IDatabaseDriver> _mockDatabaseDriver;
        private ShopService _shopService;
        private Service _service;
        private Buyer _buyer;

        [SetUp]
        public void SetUp()
        {
            _buyer = new Buyer(Id, maxExpectedPrice);
            _mockOrderService = new Mock<IOrderService>();
            _mockDatabaseDriver = new Mock<IDatabaseDriver>();
            _shopService = new ShopService(_mockOrderService.Object, _mockDatabaseDriver.Object);
            _service = new Service(_shopService);
        }

        [Test]
        public void ShouldThrowExceptionWhenIShopServiceIsNull()
        {
            //arrange
            IShopService shopSerice = null;

            void testDelegate() => new Service(shopSerice);

            //act
            var actual = Assert.Throws<ArgumentNullException>(testDelegate);

            //assert
            var expected = "Service constructor: IShopService type is null.";
            Assert.AreEqual(expected, actual.ParamName);
        }

        [Test]
        public void ShouldThrowExceptionWhenNoArticleExists()
        {
            //arrange
            var article = BuildArticle(Id);

            _mockOrderService.Setup(c => c.Order(article.Id, _buyer.MaxExpectedPrice)).Returns(() => null);
            
            //act
            void testDelegate() => _service.Run(article.Id, _buyer);
            var actual = Assert.Throws<Exception>(testDelegate);

            //assert
            var expected = "ShopService.SellArticle() method. No Article to sell.";
            Assert.AreEqual(expected, actual.Message);
            _mockOrderService.Verify(c => c.Order(Id, _buyer.MaxExpectedPrice));
        }

        [Test]
        public void ShouldThrowExceptionWhenNoArticleFound()
        {
            //arrange
            var article = BuildArticle(Id);
            
            _mockOrderService.Setup(c => c.Order(article.Id, _buyer.MaxExpectedPrice)).Returns(() => article);
            _mockDatabaseDriver.Setup(c => c.GetById(Id)).Returns(() => null);

            //act
            void testDelegate() => _service.Run(article.Id, _buyer);
            var actual = Assert.Throws<Exception>(testDelegate);

            //assert
            var expected = $"Article with id {Id} not found.";
            Assert.AreEqual(expected, actual.Message);
            _mockOrderService.Verify(c => c.Order(Id, _buyer.MaxExpectedPrice), Times.Once);
            _mockDatabaseDriver.Verify(c => c.Save(article), Times.Once);
        }

        [Test]
        public void ShouldTestHappyPath()
        {
            //arrange
            var article = BuildArticle(Id);

            _mockOrderService.Setup(c => c.Order(Id, _buyer.MaxExpectedPrice)).Returns(() => article);
            _mockDatabaseDriver.Setup(c => c.GetById(Id)).Returns(() => article);

            //act
            _service.Run(article.Id, _buyer);
            
            //assert
            _mockOrderService.Verify(c => c.Order(Id, _buyer.MaxExpectedPrice), Times.Once);
            _mockDatabaseDriver.Verify(c => c.Save(article), Times.Once);
            _mockDatabaseDriver.Verify(c => c.GetById(article.Id), Times.Once);
        }
        
        private Article BuildArticle(int id)
        {
            return new Article { Id = id };
        }
    }
}
