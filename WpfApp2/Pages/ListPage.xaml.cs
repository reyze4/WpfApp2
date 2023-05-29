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
using WpfApp2Tests.Pages;
using WpfApp2Tests.Model;

namespace WpfApp2Tests.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListPage.xaml
    /// </summary>
    public partial class ListPage : Page
    {
        public ListPage()
        {
            InitializeComponent();
            LVProduct.ItemsSource = App.DB.Product.ToList();
        }

        private void BRemove_Click(object sender, RoutedEventArgs e)
        {
            var selectedRealtor = LVProduct.SelectedItem as Product;
            if (selectedRealtor == null)
            {
                MessageBox.Show("Выберите продукт");
                return;
            }
            MessageBoxResult result = MessageBox.Show("Вы точно хотите удалить продукт?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
                return;
            if (result == MessageBoxResult.Yes)
            {
                App.DB.Product.Remove(selectedRealtor);
                App.DB.SaveChanges();
            }

            LVProduct.ItemsSource = App.DB.Product.ToList();
        }

        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedRealtor = LVProduct.SelectedItem as Product;
            if (selectedRealtor == null)
            {
                MessageBox.Show("Выберите продукт");
                return;
            }
            NavigationService.Navigate(new EAPage(selectedRealtor));
        }

        private void BAdd_Click(object sender, RoutedEventArgs e)
        {          
            NavigationService.Navigate(new EAPage(new Product()));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LVProduct.ItemsSource = App.DB.Product.ToList();
        }
    }
}
