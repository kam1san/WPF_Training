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

namespace UsersDesktopApp
{
    public partial class MainWindow : Window
    {
        AppContext db;

        public MainWindow()
        {
            InitializeComponent();
            db = new AppContext();
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            string log = login.Text.Trim();
            string pass = password.Password.Trim();
            string pass_rep = password_repeat.Password.Trim();
            string mail = email.Text.Trim().ToLower();

            bool login_check = false;
            bool pass_check = false;
            bool pass_rep_check = false;
            bool email_check = false;

            if (log.Length < 6)
            {
                login.ToolTip = "Length of login is less than 6 symbols";
                login.Background = Brushes.LightGoldenrodYellow;
                login_check = false;
            }
            else
            {
                login.ToolTip = null;
                login.Background = Brushes.Transparent;
                login_check = true;
            }

            if (pass != pass_rep)
            {
                password.ToolTip = "Passwords do not match";
                password_repeat.ToolTip = "Passwords do not match";
                password.Background = Brushes.LightGoldenrodYellow;
                password_repeat.Background = Brushes.LightGoldenrodYellow;
                pass_check = false;
                pass_rep_check = false;
            }
            else
            {
                password.ToolTip = null;
                password.Background = Brushes.Transparent;
                password_repeat.ToolTip = null;
                password_repeat.Background = Brushes.Transparent;
                pass_check = true;
                pass_rep_check = true;
            }

            if(pass.Length < 6)
            {
                password.ToolTip = "Length of password is less than 6 symbols";
                password.Background = Brushes.LightGoldenrodYellow;
                pass_check = false;
            }
            else
            {
                password.ToolTip = null;
                password.Background = Brushes.Transparent;
                pass_check = true;
            }

            if(mail.Length<6 || !mail.Contains("@") || !mail.Contains("."))
            {
                email.ToolTip = "Wrong email input (Must contain '@','.'; Length should be at least 6 symbols;)";
                email.Background = Brushes.LightGoldenrodYellow;
                email_check = false;
            }
            else
            {
                email.ToolTip = null;
                email.Background = Brushes.Transparent;
                email_check = true;
            }

            if(login_check && pass_check && pass_rep_check && email_check)
            {
                login.ToolTip = null;
                login.Background = Brushes.Transparent;
                password.ToolTip = null;
                password.Background = Brushes.Transparent;
                password_repeat.ToolTip = null;
                password_repeat.Background = Brushes.Transparent;
                email.ToolTip = null;
                email.Background = Brushes.Transparent;
                
                db.Users.Add(new User(log, pass, mail));
                db.SaveChanges();

                AuthWindow auth = new AuthWindow();
                auth.Show();
                this.Hide();
            }
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow auth = new AuthWindow();
            auth.Show();
            this.Hide();
        }
    }
}
