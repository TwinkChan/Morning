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
            // загрузка данных в DataGrid
            DGridCloths.ItemsSource = GarmentFactoryEntities.GetContext().Cloths.ToList();
            DGridFittings.ItemsSource = GarmentFactoryEntities.GetContext().Fittings.ToList();
            DGridProducts.ItemsSource = GarmentFactoryEntities.GetContext().Products.ToList();
        }

        #region Cloth Data

        // Изменение выбраного элемента 
        private void EditClothsBtn_Click(object sender, RoutedEventArgs e)
        {
            SwapManager.ViewFrame.Navigate(new AddEditClothPage((sender as Button).DataContext as Cloths));
        }

        // Дабовление нового элемента
        private void AddCloths_Click(object sender, RoutedEventArgs e)
        {
            SwapManager.ViewFrame.Navigate(new AddEditClothPage(null));
        }

        // Удаление элемента
        private void DellCloths_Click(object sender, RoutedEventArgs e)
        {
            List<Cloths> ClothDelete = DGridCloths.SelectedItems.Cast<Cloths>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {ClothDelete.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    GarmentFactoryEntities.GetContext().Cloths.RemoveRange(ClothDelete);
                    GarmentFactoryEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGridCloths.ItemsSource = GarmentFactoryEntities.GetContext().Cloths.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        #endregion


        #region Fitting Data

        // Изменение выбраного элемента
        private void EditFittingsBtn_Click(object sender, RoutedEventArgs e)
        {
            SwapManager.ViewFrame.Navigate(new AddEditFittingPage((sender as Button).DataContext as Fittings));
        }

        // Дабовление нового элемента
        private void AddFittings_Click(object sender, RoutedEventArgs e)
        {
            SwapManager.ViewFrame.Navigate(new AddEditFittingPage(null));
        }

        // Удаление элемента
        private void DelFittings_Click(object sender, RoutedEventArgs e)
        {
            List<Fittings> FittingDelete = DGridFittings.SelectedItems.Cast<Fittings>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {FittingDelete.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    GarmentFactoryEntities.GetContext().Fittings.RemoveRange(FittingDelete);
                    GarmentFactoryEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGridFittings.ItemsSource = GarmentFactoryEntities.GetContext().Fittings.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        #endregion


        #region Product Data

        // Изменение выбраного элемента
        private void EditProductsBtn_Click(object sender, RoutedEventArgs e)
        {
            SwapManager.ViewFrame.Navigate(new AddEditProductPage((sender as Button).DataContext as Products));
        }

        // Дабовление нового элемента
        private void AddProducts_Click(object sender, RoutedEventArgs e)
        {
            SwapManager.ViewFrame.Navigate(new AddEditProductPage(null));
        }

        // Удаление элемента
        private void DelProducts_Click(object sender, RoutedEventArgs e)
        {
            List<Products> ProductsDelete = DGridProducts.SelectedItems.Cast<Products>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {ProductsDelete.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    GarmentFactoryEntities.GetContext().Products.RemoveRange(ProductsDelete);
                    GarmentFactoryEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGridProducts.ItemsSource = GarmentFactoryEntities.GetContext().Products.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        #endregion

        // обновление DataGrid
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                DGridCloths.ItemsSource = GarmentFactoryEntities.GetContext().Cloths.ToList();
                DGridFittings.ItemsSource = GarmentFactoryEntities.GetContext().Fittings.ToList();
                DGridProducts.ItemsSource = GarmentFactoryEntities.GetContext().Products.ToList();
            }
        }
    }
}
