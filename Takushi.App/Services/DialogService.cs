using System.Windows;
using Takushi.App.View;

namespace Takushi.App.Services
{
    public class DialogService
    {
        Window productDetailView = null;

        public void ShowDetailDialog()
        {
            productDetailView = new ProductDetailView();
            productDetailView.ShowDialog();
        }

        public void CloseDetailDialog()
        {
            if (productDetailView != null)
                productDetailView.Close();
        }
    }
}
