using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TheShop.Contracts;
using Moq;
using TheShop.Persistance;
using TheShop.Entities;

namespace TheShop.UnitTests
{
    [TestFixture]
    public class ShopServiceUnitTest
    {
        private const string name1 = "articleName1";
        private const string name2 = "articleName2";
        private const decimal price1 = 100;
        private const decimal price2 = 120;
        private const int buyerId = 1;
        private Mock<IDatabaseDriver> _mockDatabaseDriver;
        private List<ISupplier> _suppliers;

        [SetUp]
        public void Setup()
        {
            _mockDatabaseDriver = new Mock<IDatabaseDriver>();
            _suppliers = new List<ISupplier>();
        }

        [Test]
        public void ShouldThrowExceptionWhenSuppliersIsNull()
        {
            //arrange
            List<ISupplier> suppliers = null;
            
            void testDelegate() => new ShopService(suppliers, _mockDatabaseDriver.Object);

            //act
            var actual = Assert.Throws<ArgumentNullException>(testDelegate);

            //assert
            var expected = "ShopService constructor: List<ISupplier> type is null.";
            Assert.AreEqual(expected, actual.ParamName);
        }

        [Test]
        public void ShouldThrowExceptionWhenIDatabaseDriverIsNull()
        {
            //arrange
            IDatabaseDriver databaseDriver = null;
            void testDelegate() => new ShopService(_suppliers, databaseDriver);

            //act
            var actual = Assert.Throws<ArgumentNullException>(testDelegate);

            //assert
            var expected = "ShopService constructor: IDatabaseDriver type is null.";
            Assert.AreEqual(expected, actual.ParamName);
        }

        [Test]
        public void ShouldReturnNullWhenOrderArticleMethodIsCalled()
        {
            //arrange
            int id = 1;
            decimal expectedPrice = 90;
            var supplier1 = new Mock<ISupplier>();
            var supplier2 = new Mock<ISupplier>();

            supplier1.Setup(c => c.GetArticle(id)).Returns(BuildArticle(id, name1, price1));
            supplier2.Setup(c => c.GetArticle(id)).Returns(BuildArticle(id, name2, price2));

            var suppliers = BuildSuppliers(supplier1, supplier2);

            var shopService = new ShopService(suppliers, _mockDatabaseDriver.Object);

            //act
            var article = shopService.OrderArticle(id, expectedPrice);

            //assert
            Assert.IsNull(article);
        }

        [Test]
        public void ShouldReturnArticleWhenOrderArticleMethodIsCalled()
        {
            //arrange
            int id = 1;
            decimal expectedPrice = 110;
            
            var supplier1 = new Mock<ISupplier>();
            var supplier2 = new Mock<ISupplier>();

            supplier1.Setup(c => c.GetArticle(id)).Returns(BuildArticle(id, name1, price1));
            supplier2.Setup(c => c.GetArticle(id)).Returns(BuildArticle(id, name2, price2));

            var suppliers = BuildSuppliers(supplier1, supplier2);

            var shopService = new ShopService(suppliers, _mockDatabaseDriver.Object);

            //act
            var article = shopService.OrderArticle(id, expectedPrice);
            
            //assert
            Assert.IsNotNull(article);
            Assert.AreEqual(article.Price, price1);
            Assert.AreEqual(article.Name, name1);
            supplier1.Verify(c => c.GetArticle(id), Times.Once);
        }

        [Test]
        public void ShouldThrowExceptionWhenSellArticleMethodIsCalled()
        {
            //arrange
            Article article = null;
            var shopService = new ShopService(_suppliers, _mockDatabaseDriver.Object);
            
            //act
            var actual = Assert.Throws<ArgumentNullException>(() => shopService.SellArticle(buyerId, article));

            //assert
            var expected = "ShopService.SellArticle() method. No Article to sell.";
            Assert.AreEqual(expected, actual.ParamName);
        }

        [Test]
        public void ShouldSaveArticleWhenSellArticleMethodIsCalled()
        {
            //arrange
            var article = new Article();
            var shopService = new ShopService(_suppliers, _mockDatabaseDriver.Object);

            _mockDatabaseDriver.Setup(c => c.Save(article)).Verifiable();
            //act
            shopService.SellArticle(buyerId, article);

            //assert
            _mockDatabaseDriver.Verify(c => c.Save(article), Times.Once);
        }

        [Test]
        public void ShouldThrowExceptionWhenNoArticleExists()
        {
            //arrange
            int id = 1;
            var article = new Article { Id = id };
            var shopService = new ShopService(_suppliers, _mockDatabaseDriver.Object);
            _mockDatabaseDriver.Setup(c => c.GetById(id)).Returns(() => null);
            
            //act
            var actual = Assert.Throws<Exception>(() => shopService.DispalyArticle(article));

            //assert
            var expected = $"Article with id {id} not found.";
            Assert.AreEqual(expected, actual.Message);
            _mockDatabaseDriver.Verify(c => c.GetById(id), Times.Once);
        }

        [Test]
        public void ShouldBeInstanceOfIShopService()
        {
            Assert.IsInstanceOf<IShopService>(new ShopService(_suppliers, _mockDatabaseDriver.Object));
        }

        private Article BuildArticle(int id, string name, decimal price)
        {
            return new Article
            {
                Id = id,
                Name = name,
                Price = price
            };
        }

        private List<ISupplier> BuildSuppliers(Mock<ISupplier> supplier1, Mock<ISupplier> supplier2)
        {
            return new List<ISupplier>
            {
                supplier1.Object,
                supplier2.Object
            };
        }

    }
}
