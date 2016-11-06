using Microsoft.VisualStudio.TestTools.UnitTesting;
using Takushi.App.Services;
using Takushi.DAL;
using Takushi.Tests.Mocks;

namespace Takushi.Tests
{
    [TestClass]
    public class ProductDataServiceTest
    {
        private IProductRepository repository;

        [TestInitialize]
        public void Init()
        {
            this.repository = new MockRepository();
        }

        [TestMethod]
        public void GetProductDetailTest()
        {
            var service = new ProductDataService(repository);

            var product = service.GetProductDetail(1);

            Assert.IsNotNull(product);
        }
    }
}
