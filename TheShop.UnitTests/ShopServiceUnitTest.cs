using System;
using System.Collections.Generic;
using NUnit.Framework;
using TheShop.Contracts;
using Moq;
using TheShop.Entities;

namespace TheShop.UnitTests
{
    [TestFixture]
    public class ShopServiceUnitTest
    {
        //private const string name1 = "articleName1";
        //private const string name2 = "articleName2";
        //private const double price1 = 100;
        //private const double price2 = 120;
        //private const int buyerId = 1;
        //private Mock<IDatabaseDriver> _mockDatabaseDriver;
        //private Mock<IOrderService> _mockOrderService;
        //private List<ISupplier> _suppliers;
        //private ShopService _shopService;

        //[SetUp]
        //public void Setup()
        //{
        //    _mockDatabaseDriver = new Mock<IDatabaseDriver>();
        //    _mockOrderService = new Mock<IOrderService>();
        //    _suppliers = new List<ISupplier>();
        //    _shopService = new ShopService(_mockOrderService.Object, _mockDatabaseDriver.Object);
        //}

        //[Test]
        //public void ShouldThrowExceptionWhenSuppliersIsNull()
        //{
        //    //arrange
        //    OrderService orderService = null;
            
        //    void testDelegate() => new ShopService(orderService, _mockDatabaseDriver.Object);

        //    //act
        //    var actual = Assert.Throws<ArgumentNullException>(testDelegate);

        //    //assert
        //    var expected = "ShopService constructor: IOrderService type is null.";
        //    Assert.AreEqual(expected, actual.ParamName);
        //}

        //[Test]
        //public void ShouldThrowExceptionWhenIDatabaseDriverIsNull()
        //{
        //    //arrange
        //    IDatabaseDriver databaseDriver = null;
        //    void testDelegate() => new ShopService(_mockOrderService.Object, databaseDriver);

        //    //act
        //    var actual = Assert.Throws<ArgumentNullException>(testDelegate);

        //    //assert
        //    var expected = "ShopService constructor: IDatabaseDriver type is null.";
        //    Assert.AreEqual(expected, actual.ParamName);
        //}

        //[Test]
        //public void ShouldVerifyMethodIsCalledWithProperParameters()
        //{
        //    //arrange
        //    int id = 1;
        //    double maxExpectedPrice = 90;
        //    var supplier1 = new Mock<ISupplier>();
        //    var supplier2 = new Mock<ISupplier>();

        //    supplier1.Setup(c => c.GetArticle(id)).Returns(BuildArticle(id, name1, price1));
        //    supplier2.Setup(c => c.GetArticle(id)).Returns(BuildArticle(id, name2, price2));
            
        //    //act
        //    var article = _shopService.OrderArticle(id, maxExpectedPrice);

        //    //assert
        //    _mockOrderService.Verify(c => c.Order(It.Is<int>(p => p == id), It.Is<double>(p => p == maxExpectedPrice)));
        //}

        //[Test]
        //public void ShouldThrowExceptionWhenSellArticleMethodIsCalled()
        //{
        //    //arrange
        //    Article article = null;
            
        //    //act
        //    var actual = Assert.Throws<Exception>(() => _shopService.SellArticle(buyerId, article));

        //    //assert
        //    var expected = "ShopService.SellArticle() method. No Article to sell.";
        //    Assert.AreEqual(expected, actual.Message);
        //}

        //[Test]
        //public void ShouldSaveArticleWhenSellArticleMethodIsCalled()
        //{
        //    //arrange
        //    var article = new Article();
        //    _mockDatabaseDriver.Setup(c => c.Save(article)).Verifiable();

        //    //act
        //    _shopService.SellArticle(buyerId, article);

        //    //assert
        //    _mockDatabaseDriver.Verify(c => c.Save(article), Times.Once);
        //}

        //[Test]
        //public void ShouldThrowExceptionWhenNoArticleExists()
        //{
        //    //arrange
        //    int id = 1;
        //    var article = new Article { Id = id };
        //    _mockDatabaseDriver.Setup(c => c.GetById(id)).Returns(() => null);
            
        //    //act
        //    var actual = Assert.Throws<Exception>(() => _shopService.DispalyArticle(article));

        //    //assert
        //    var expected = $"Article with id {id} not found.";
        //    Assert.AreEqual(expected, actual.Message);
        //    _mockDatabaseDriver.Verify(c => c.GetById(id), Times.Once);
        //}

        //[Test]
        //public void ShouldBeInstanceOfIShopService()
        //{
        //    Assert.IsInstanceOf<IShopService>(new ShopService(_mockOrderService.Object, _mockDatabaseDriver.Object));
        //}

        //private Article BuildArticle(int id, string name, double price)
        //{
        //    return new Article
        //    {
        //        Id = id,
        //        Name = name,
        //        Price = price
        //    };
        //}
    }
}
