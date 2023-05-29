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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void BReg_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegPage());
        }

        private void BLogin_Click(object sender, RoutedEventArgs e)
        {
            var user = App.DB.User.FirstOrDefault(x => x.Login == TBLogin.Text);
            if (user == null)
            {
                MessageBox.Show("Логин неверный");
                return;
            }
            if (user.Password != TBPassword.Password || user.Password == null)
            {
                MessageBox.Show("Пароль неверный");
                return;
            }
            App.DB.SaveChanges();
            App.LoggedUser = user;
            NavigationService.Navigate(new ListPage());
        }

        private void TBLogin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
