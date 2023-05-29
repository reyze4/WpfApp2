﻿using System;
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
using WpfApp2Tests.Pages;
using WpfApp2Tests.Model;

namespace WpfApp2Tests.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        User user = new User();
        public RegPage()
        {
            InitializeComponent();
            DataContext = user;
        }

        private void BBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            SaveUser();
        }

        private void SaveUser()
        {
            string error = "";

            if (App.DB.User.FirstOrDefault(x => x.Login == user.Login) != null)
            {
                MessageBox.Show($"Пользователь с таким логином {user.Login} уже существует");
                return;
            }
            if (string.IsNullOrWhiteSpace(user.Login) == true
                || user.Login == null || user.Login == string.Empty)
            {
                error += "-Введите корректный логин\n";
                TBLogin.Text = string.Empty;
            }
            if (string.IsNullOrWhiteSpace(user.Password) == true
                || user.Password == null)
            {
                error += "-Введите корректный пароль\n(A-z0-9~!@#$%^&*()+`'\";:<>/\\|)\n";
                TBPassword.Text = string.Empty;
            }
            if (error != "")
            {
                MessageBox.Show(error, "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            App.DB.User.Add(user);
            App.DB.SaveChanges();
            MessageBox.Show($"Был зарегистрирован новый пользователь '{user.Login}'",
                "Добро пожаловать", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService.GoBack();

            
        }

        private void TBLogin_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
    }
}
