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
using Morning.Logic;
using Morning.Pages;
using Morning.Data;
using Morning.Pages.MenuPages;

namespace Morning
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ViewPwd_Click(object sender, RoutedEventArgs e)
        {

            string pwd;

            if (ViewPwd.IsChecked == true)
            {
                pwd = Convert.ToString(PwdBox.Password);
                ViewPwdBox.Text = pwd;
                PwdBox.Visibility = Visibility.Hidden;
                ViewPwdBox.Visibility = Visibility.Visible;
            }
            else
            {
                pwd = Convert.ToString(ViewPwdBox.Text);
                PwdBox.Password = pwd;
                ViewPwdBox.Visibility = Visibility.Hidden;
                PwdBox.Visibility = Visibility.Visible;
            }

        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {

            string login = LoginBox.Text.Trim();
            string pwd = PwdBox.Password.Trim();
            string pwd2 = ViewPwdBox.Text.Trim();
            UserHistory userHistory = new UserHistory();
            WindowHome windowHome = new WindowHome();

            if (LoginBox.Text.Length > 0)
            {
                if (PwdBox.Password.Length > 0 || ViewPwdBox.Text.Length > 0)
                {
                    Users authUser = null;
                    using (GarmentFactoryEntities db = new GarmentFactoryEntities())
                    {
                        authUser = db.Users.Where(x => x.Login == login && x.Password == pwd).FirstOrDefault();
                    }

                    if (authUser != null)
                    {
                        GarmentFactoryEntities db = new GarmentFactoryEntities();

                        string uName = authUser.Name;
                        DateTime dTime = DateTime.Now;
                        
                        userHistory.UserName = uName;
                        userHistory.Data = dTime;

                        try
                        {
                            GarmentFactoryEntities.GetContext().UserHistory.Add(userHistory);
                            GarmentFactoryEntities.GetContext().SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }


                        if (authUser.Role == "admin")
                        {
                            windowHome.ViewFrame.Navigate(new AdminPage());
                            windowHome.Show();
                            windowHome.MenuFrame.Navigate(new AdminMenuPages());
                        }
                        else if (authUser.Role == "manager")
                        {
                            windowHome.ViewFrame.Navigate(new ManagerPage());
                            windowHome.Show();
                            windowHome.MenuFrame.Navigate (new ManagerMenuPages());
                        }
                        else if (authUser.Role == "cutter")
                        {
                            windowHome.ViewFrame.Navigate(new CutterPage());
                            windowHome.Show();
                            windowHome.MenuFrame.Navigate(new CutterMenuPages());
                        }
                        else
                        {
                            MessageBox.Show("Ошибка обратитесь к администратору!");
                        }
                        MessageBox.Show("Добро пожаловать " + authUser.Name);
                        Close();   
                    }
                    else
                    {
                        MessageBox.Show("Введены неправельные данные!");
                    }
                }
                else
                {
                    MessageBox.Show("Вы не ввели пароль!");
                }
            }
            else
            {
                MessageBox.Show("Вы не ввели логин!");
            }

        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно вы хотите выйти?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
