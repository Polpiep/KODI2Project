using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace KODI2Project.Form
{
    /// <summary>
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        private List<string> genders = new List<string>() { "Босс вертолет","Мужской","Женский","Республиканский","СепаратиСТСкий"};
        public AddUser()
        {
            InitializeComponent();
            this.Loaded += AddUser_Loaded;
            this.Closing += AddUser_Closed;
        }

        private void AddUser_Closed(object? sender, CancelEventArgs e)
        { 
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void AddUser_Loaded(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            cbGender.ItemsSource = genders;
            cbGender.SelectedIndex = random.Next(0, genders.Count);
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            #region

            if (string.IsNullOrEmpty(tbName.ToString()))
            {
                MessageBox.Show("Введите имя пользователя");
            }
            int age = 0;
            if (string.IsNullOrEmpty(tbAge.ToString()))
            {
                MessageBox.Show("Укажите возраст пользвателя");
            }

            try
            {
                age = Convert.ToInt32(tbAge.Text);
                if (age < 0)
                {
                    MessageBox.Show("Некорректный возраст");
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Вы указали не число в графе возраста", "вэээ братан, ты што творишь", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            #endregion

            DB.Users newUsers = new DB.Users() 
            {
                UserName = tbName.Text,  UserAge = age, Gender = cbGender.SelectedItem.ToString()
            };
            
            DB.MyContext myContext = new DB.MyContext();

            try
            {
                myContext.Users2.Add(newUsers);
                myContext.SaveChanges();
                MessageBox.Show($"Пользователь {newUsers.UserName} добавлен в базу данный");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ошибка добавления пользователя в бузу данных" + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnBackToTheStartWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
