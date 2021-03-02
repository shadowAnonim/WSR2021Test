using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace WSR2021
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        WSR2021Entities db = new WSR2021Entities();
        public MainPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            db.UserView.Load();
            userViewDataGrid.DataContext = db.UserView.ToList();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            UserView select = userViewDataGrid.SelectedItem as UserView;
            if (select == null)
            {
                MessageBox.Show("Выберите");
                return;
            }
            db.User.Load();
            User user = db.User.FirstOrDefault(el => el.id == select.id);
            db.User.Remove(user);
            db.SaveChanges();
            Page_Loaded(null, null);
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            UserView select = userViewDataGrid.SelectedItem as UserView;
            if (select == null)
            {
                MessageBox.Show("Выберите");
                return;
            }
            db.User.Load();
            User user = db.User.FirstOrDefault(el => el.id == select.id);
            NavigationService.Navigate(new EditUserPage(user));
        }
    }
}
