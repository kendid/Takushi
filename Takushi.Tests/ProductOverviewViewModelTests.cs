using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;
using Takushi.App.Services;
using Takushi.App.ViewModel;
using Takushi.Model;
using Takushi.Tests.Mocks;

namespace Takushi.Tests
{
    [TestClass]
    public class ProductOverviewViewModelTests
    {
        private IProductDataService productDataService;
        private IDialogService dialogService;

        [TestInitialize]
        public void Init()
        {
            productDataService = new MockProductDataService(new MockRepository());
            dialogService = new MockDialogService();
        }

        [TestMethod]
        public void LoadAllCoffees()
        {
            ObservableCollection<Product> products = null;
            var expectedProducts = productDataService.GetAllProducts();

            var viewModel = new ProductOverviewViewModel(this.productDataService, this.dialogService);
            products = viewModel.Products;

            CollectionAssert.AreEqual(expectedProducts, products);
        }
    }
}
