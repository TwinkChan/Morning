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
    /// Логика взаимодействия для AddEditFittingPage.xaml
    /// </summary>
    public partial class AddEditFittingPage : Page
    {
        private Fittings _currentFittings = new Fittings();
        public AddEditFittingPage(Fittings selectedFittings)
        {
            InitializeComponent();

            if (selectedFittings != null)
                _currentFittings = selectedFittings;

            DataContext = _currentFittings;
        }

        private void SaveFitting_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentFittings.Code))
                errors.AppendLine("Укажите артикул!");
            if (string.IsNullOrWhiteSpace(_currentFittings.Name))
                errors.AppendLine("Укажите наименование!");
            if (string.IsNullOrWhiteSpace(_currentFittings.Type))
                errors.AppendLine("Укажите тип!");
            if (_currentFittings.Weight <= 0)
                errors.AppendLine("Укажите вес!");
            if (TPrice.Text.Length < 0)
                errors.AppendLine("Укажите цену!");



            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentFittings.Id == 0)
                GarmentFactoryEntities.GetContext().Fittings.Add(_currentFittings);

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
