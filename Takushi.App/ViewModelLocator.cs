using Takushi.App.Services;
using Takushi.App.ViewModel;
using Takushi.DAL;

namespace Takushi.App
{
    public class ViewModelLocator
    {
        private static IDialogService dialogService = new DialogService();

        private static IProductDataService productDataService =
            new ProductDataService(new ProductsRepository());

        private static ProductOverviewViewModel productOverviewViewModel =
            new ProductOverviewViewModel(productDataService, dialogService);
        private static ProductDetailViewModel productDetailViewModel =
            new ProductDetailViewModel(productDataService, dialogService);

        public static ProductDetailViewModel ProductDetailViewModel
        {
            get
            {
                return productDetailViewModel;
            }
        }

        public static ProductOverviewViewModel ProductOverviewViewModel
        {
            get
            {
                return productOverviewViewModel;
            }
        }
    }
}
