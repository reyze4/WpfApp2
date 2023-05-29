using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp2Tests.Model;

namespace WpfApp2Tests.Pages
{
    /// <summary>
    /// Логика взаимодействия для EAPage.xaml
    /// </summary>
    public partial class EAPage : Page
    {
        Product contextProduct;
        public EAPage(Product product)
        {
            InitializeComponent();
            contextProduct = product;
            DataContext = contextProduct;

        }

        private void BBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            if(contextProduct.ID == 0)
            {
                App.DB.Product.Add(contextProduct);
            }
            App.DB.SaveChanges();
            NavigationService.GoBack();
        }
    }
}
