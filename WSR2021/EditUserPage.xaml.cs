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
    /// Логика взаимодействия для EditUserPage.xaml
    /// </summary>
    public partial class EditUserPage : Page
    {
        WSR2021Entities db = new WSR2021Entities();
        User _user;
        bool edit = true;
        public EditUserPage(User user)
        {
            InitializeComponent();
            nameComboBox.ItemsSource = db.Role.ToList();
            if (user != null)
            {
                _user = user;
                edit = true;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            grid1.DataContext = _user;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            db.User.Load();
            db.SaveChanges();
            NavigationService.GoBack();
        }
    }
}
