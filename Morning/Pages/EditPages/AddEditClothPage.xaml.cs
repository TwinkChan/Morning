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
    /// Логика взаимодействия для AddEditClothPage.xaml
    /// </summary>
    public partial class AddEditClothPage : Page
    {
        private Cloths _currentCloths = new Cloths();
        public AddEditClothPage(Cloths selectedCloths)
        {
            InitializeComponent();

            if (selectedCloths != null)
                _currentCloths = selectedCloths;

            DataContext = _currentCloths;
        }

        private void SaveCloth_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentCloths.Code))
                errors.AppendLine("Укажите артикул!");
            if (string.IsNullOrWhiteSpace(_currentCloths.Name))
                errors.AppendLine("Укажите наименование!");
            if (string.IsNullOrWhiteSpace(_currentCloths.Color))
                errors.AppendLine("Укажите цвет!");
            if (string.IsNullOrWhiteSpace(_currentCloths.Compound))
                errors.AppendLine("Укажите состав!");
            if (_currentCloths.Width <= 0)
                errors.AppendLine("Укажите ширину!");
            if (_currentCloths.Length <= 0)
                errors.AppendLine("Укажите длину!");
            if (TPrice.Text.Length <= 0)
                errors.AppendLine("Укажите цену!");



            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentCloths.Id == 0)
                GarmentFactoryEntities.GetContext().Cloths.Add(_currentCloths);

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
