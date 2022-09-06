using KODI2Project.DB;
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

namespace KODI2Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            Form.AddUser addUser = new Form.AddUser();
            addUser.Show();
            Close();
        }

        private void btnMadeManyUsers_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteDB_Click(object sender, RoutedEventArgs e)
        {
            MyContext myContext = new MyContext();
            myContext.Users2.RemoveRange(myContext.Users2);
            myContext.SaveChanges();
            MessageBox.Show("ВЫ удалили БД", "Капец что творится", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
