﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp4.pages
{
    /// <summary>
    /// Логика взаимодействия для login.xaml
    /// </summary>
    public partial class login : Page
    {
        public login()
        {
            InitializeComponent();
        }
        string kode;
        bool flagKode = false;

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                auth CurrentUser = BaseConnect.BaseModel.auth.FirstOrDefault(x => x.login == txtLogin.Text && x.password == txtPassword.Password);
                if (CurrentUser != null)
                {
                    if (flagKode == false)
                    {
                        generateKey();
                        flagKode = true;
                    }
                    else if (kode == txtKey.Text)
                    {
                        switch (CurrentUser.role)
                        {
                            case 1:
                                MessageBox.Show("Вы вошли как администратор");
                                LoadPages.MainFrame.Navigate(new PageUserList());
                                break;
                            case 2:
                            default:
                                MessageBox.Show("Вы вошли как обычный пользователь");
                                LoadPages.MainFrame.Navigate(new info(CurrentUser));
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введенный код не подходит");
                    }
                }
                else
                {
                    MessageBox.Show("Такого пользователя нет");
                }
            }
            catch
            {
                MessageBox.Show("Какая-то неизвестная ошибка");
            }

        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            LoadPages.MainFrame.Navigate(new reg());
        }
        Random random = new Random();
        private void generateKey()
        {
            imgRefresh.IsEnabled = false;
            kode = "";

            for (int i = 0; i < 8; i++)
            {
                kode += ((char)random.Next(33, 122)).ToString();
            }
            txtKey.Text = kode;
            MessageBox.Show(kode, "Введите код в соответствующее поле на форме.", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.RightAlign);
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Start();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            imgRefresh.IsEnabled = true;
            kode = ((char)random.Next(33, 122)).ToString();
        }
        private void Image_imgRefresh(object sender, MouseButtonEventArgs e)
        {
            txtKey.Text = " ";
            generateKey();
            flagKode = true;
        }

        private void txtKey_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnDiagr_Click(object sender, RoutedEventArgs e)
        {
            LoadPages.MainFrame.Navigate(new Diagrams());
        }

        private void btnAnims_Click(object sender, RoutedEventArgs e)
        {
            LoadPages.MainFrame.Navigate(new Animations());
        }
    }
}
