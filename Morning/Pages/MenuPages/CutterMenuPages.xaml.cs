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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Morning.Pages.MenuPages
{
    /// <summary>
    /// Логика взаимодействия для CutterMenuPages.xaml
    /// </summary>
    public partial class CutterMenuPages : Page
    {
        public CutterMenuPages()
        {
            InitializeComponent();
        }

        private void CatalogTable_Click(object sender, RoutedEventArgs e)
        {
            SwapManager.ViewFrame.Navigate(new CutterPage());
        }

        private void OrderTable_Click(object sender, RoutedEventArgs e)
        {
            SwapManager.ViewFrame.Navigate(new ViewOrderPage());
        }

        private void Calculations_Click(object sender, RoutedEventArgs e)
        {
            SwapManager.ViewFrame.Navigate(new CalculationPage());
        }
    }
}
