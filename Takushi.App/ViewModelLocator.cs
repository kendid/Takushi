using Takushi.App.ViewModel;

namespace Takushi.App
{
    public class ViewModelLocator
    {
        private static ProductOverviewViewModel productOverviewViewModel = new ProductOverviewViewModel();
        private static ProductDetailViewModel productDetailViewModel = new ProductDetailViewModel();

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
