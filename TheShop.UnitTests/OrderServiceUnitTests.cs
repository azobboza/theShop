using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using TheShop.Contracts;
using TheShop.Entities;

namespace TheShop.UnitTests
{
    public class OrderServiceUnitTests
    {
        private const string name1 = "articleName1";
        private const string name2 = "articleName2";
        private const double price1 = 100;
        private const double price2 = 120;
        private Mock<ISupplier> _supplier1;
        private Mock<ISupplier> _supplier2;

        [SetUp]
        public void SetUp()
        {
            _supplier1 = new Mock<ISupplier>();
            _supplier2 = new Mock<ISupplier>();
        }

        [Test]
        public void ShouldThrowExceptionWhenSuppliersIsNull()
        {
            //arrange
            List<ISupplier> suppliers = null;

            void testDelegate() => new OrderService(suppliers);

            //act
            var actual = Assert.Throws<ArgumentNullException>(testDelegate);

            //assert
            var expected = "ShopService constructor: List<ISupplier> type is null.";
            Assert.AreEqual(expected, actual.ParamName);
        }

        [Test]
        public void ShouldReturnNullWhenOrderArticleMethodIsCalled()
        {
            //arrange
            int id = 1;
            double expectedPrice = 90;
            
            _supplier1.Setup(c => c.GetArticle(id)).Returns(BuildArticle(id, name1, price1));
            _supplier2.Setup(c => c.GetArticle(id)).Returns(BuildArticle(id, name2, price2));

            var suppliers = BuildSuppliers(_supplier1, _supplier2);
            var orderService = new OrderService(suppliers);

            //act
            var article = orderService.Order(id, expectedPrice);

            //assert
            Assert.IsNull(article);
        }

        [Test]
        public void ShouldReturnArticleWhenOrderArticleMethodIsCalled()
        {
            //arrange
            int id = 1;
            double expectedPrice = 110;

            _supplier1.Setup(c => c.GetArticle(id)).Returns(BuildArticle(id, name1, price1));
            _supplier2.Setup(c => c.GetArticle(id)).Returns(BuildArticle(id, name2, price2));

            var suppliers = BuildSuppliers(_supplier1, _supplier2);
            var orderService = new OrderService(suppliers);

            //act
            var article = orderService.Order(id, expectedPrice);

            //assert
            Assert.IsNotNull(article);
            Assert.AreEqual(article.Price, price1);
            Assert.AreEqual(article.Name, name1);
            _supplier1.Verify(c => c.GetArticle(id), Times.Once);
        }

        private Article BuildArticle(int id, string name, double price)
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
