using Morning.Data;
using Morning.Logic;
using Morning.Pages.EditPages;
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

namespace Morning.Pages
{
    /// <summary>
    /// Логика взаимодействия для ManagerPage.xaml
    /// </summary>
    public partial class ManagerPage : Page
    {
        public ManagerPage()
        {
            InitializeComponent();
            DGridCloths.ItemsSource = GarmentFactoryEntities.GetContext().Cloths.ToList();
            DGridFittings.ItemsSource = GarmentFactoryEntities.GetContext().Fittings.ToList();
            DGridProducts.ItemsSource = GarmentFactoryEntities.GetContext().Products.ToList();
        }

        private void EditClothsBtn_Click(object sender, RoutedEventArgs e)
        {
            SwapManager.ViewFrame.Navigate(new AddEditClothPage());
        }

        private void AddCloths_Click(object sender, RoutedEventArgs e)
        {
            SwapManager.ViewFrame.Navigate(new AddEditClothPage());
        }

        private void DellCloths_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditFittingsBtn_Click(object sender, RoutedEventArgs e)
        {
            SwapManager.ViewFrame.Navigate(new AddEditFittingPage());
        }

        private void AddFittings_Click(object sender, RoutedEventArgs e)
        {
            SwapManager.ViewFrame.Navigate(new AddEditFittingPage());
        }

        private void DelFittings_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditProductsBtn_Click(object sender, RoutedEventArgs e)
        {
            SwapManager.ViewFrame.Navigate(new AddEditProductPage());
        }

        private void AddProducts_Click(object sender, RoutedEventArgs e)
        {
            SwapManager.ViewFrame.Navigate(new AddEditProductPage());
        }

        private void DelProducts_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
