using Morning.Logic;
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
using System.Windows.Shapes;

namespace Morning.Pages
{
    /// <summary>
    /// Логика взаимодействия для WindowHome.xaml
    /// </summary>
    public partial class WindowHome : Window
    {
        public WindowHome()
        {
            InitializeComponent();
            SwapManager.ViewFrame = ViewFrame;
        }

        MainWindow mainWindow = new MainWindow();

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SwapManager.ViewFrame.GoBack();
            }
            catch
            {
                MessageBox.Show("Вы в главном меню");
            }
        }

        private void ViewWindow_ContentRendered(object sender, EventArgs e)
        {
            if (ViewFrame.CanGoBack)
            {
                Back.Visibility = Visibility.Visible;
            }
            else
            {
                Back.Visibility = Visibility.Hidden;
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Вы действительно вы хотите выйти?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Close();
                mainWindow.Show();
            }
        }

        private void ViewMenu_Click(object sender, RoutedEventArgs e)
        {
            if(GridMenu.Visibility == Visibility.Hidden)
            {
                GridMenu.Visibility = Visibility.Visible;
            }
            else
            {
                GridMenu.Visibility = Visibility.Hidden;
            }
        }
    }
}
