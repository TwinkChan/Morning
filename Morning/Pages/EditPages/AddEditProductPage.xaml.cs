using Morning.Data;
using Morning.Logic;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

namespace Morning.Pages.EditPages
{
    /// <summary>
    /// Логика взаимодействия для AddEditProductPage.xaml
    /// </summary>
    public partial class AddEditProductPage : Page
    {
        private Products _currentProducts = new Products();
        public AddEditProductPage(Products selectedProducts)
        {
            InitializeComponent();

            if (selectedProducts != null)
                _currentProducts = selectedProducts;

            DataContext = _currentProducts;
        }

        private void SaveProduct_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentProducts.Code))
                errors.AppendLine("Укажите артикул!");
            if (string.IsNullOrWhiteSpace(_currentProducts.Name))
                errors.AppendLine("Укажите наименование!");
            if (_currentProducts.Width <= 0)
                errors.AppendLine("Укажите ширину!");
            if (_currentProducts.Length <= 0)
                errors.AppendLine("Укажите длину!");



            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentProducts.Id == 0)
                GarmentFactoryEntities.GetContext().Products.Add(_currentProducts);

            try
            {
                GarmentFactoryEntities.GetContext().SaveChanges();
                MessageBox.Show("Информиция сохранена!");
                SwapManager.ViewFrame.GoBack();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        MessageBox.Show(err.ErrorMessage + " ");
                    }
                }
            }
        }
    }
}
