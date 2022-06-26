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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
            DGridUsers.ItemsSource = GarmentFactoryEntities.GetContext().Users.ToList();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            SwapManager.ViewFrame.Navigate(new AddEditUserPage(null));
        }

        private void DelUser_Click(object sender, RoutedEventArgs e)
        {
            var UserDelete = DGridUsers.SelectedItems.Cast<Users>().ToList();

            if(MessageBox.Show($"Вы точно хотите удалить следующие {UserDelete.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    //GarmentFactoryEntities.GetContext().Users.RemoveRange(UserDelete);
                    GarmentFactoryEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGridUsers.ItemsSource = GarmentFactoryEntities.GetContext().Users.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void EditUsersBtn_Click(object sender, RoutedEventArgs e)
        {
            SwapManager.ViewFrame.Navigate(new AddEditUserPage((sender as Button).DataContext as Users));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
                DGridUsers.ItemsSource = GarmentFactoryEntities.GetContext().Users.ToList();
        }
    }
}
