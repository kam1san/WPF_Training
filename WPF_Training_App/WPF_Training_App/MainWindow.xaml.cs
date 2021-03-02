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
using System.Data;

namespace WPF_Training_App
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach(UIElement el in MainGrid.Children)
            {
                if(el is Button)
                {
                    ((Button) el).Click += Button_Click;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (String)((Button)e.OriginalSource).Content;

            if (str == "AC")
                label_text.Text = "";
            else if(str == "=")
            {
                string value = new DataTable().Compute(label_text.Text, null).ToString();
                label_text.Text = value;
            }
            else
                label_text.Text += str;
        }
    }
}
