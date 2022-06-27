using Morning.Data;
using Morning.Logic;
using Morning.Pages;
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
    /// Логика взаимодействия для AddEditUserPage.xaml
    /// </summary>
    public partial class AddEditUserPage : Page
    {
        private Users _currentUser = new Users();
        public AddEditUserPage(Users selectedUser)
        {
            InitializeComponent();

            if(selectedUser != null)
                _currentUser = selectedUser;

            DataContext = _currentUser;
        }

        private void SaveUser_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentUser.Name))
                errors.AppendLine("Укажите имя!");
            if (string.IsNullOrWhiteSpace(_currentUser.Surname))
                errors.AppendLine("Укажите фамилию!");
            if (_currentUser.Role == null)
                errors.AppendLine("Выберите должность!");
            if (string.IsNullOrWhiteSpace(_currentUser.Phone))
                errors.AppendLine("Укажите телефон!");
            if (_currentUser.Phone.Length < 11)
                errors.AppendLine("Укажите правильный номер!");
            if (string.IsNullOrWhiteSpace(_currentUser.Login))
                errors.AppendLine("Укажите логин!");
            if (string.IsNullOrWhiteSpace(_currentUser.Password))
                errors.AppendLine("Укажите пароль!");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentUser.Id == 0)
                GarmentFactoryEntities.GetContext().Users.Add(_currentUser);

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

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if(!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }
    }
}
