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
using System.Windows.Shapes;

namespace BLG4MG_SZTGUI_2022_1_WPFClient
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BrandWindow BrandMainWindow = new BrandWindow();
            BrandMainWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CarWindow CarMainWindow = new CarWindow();
            CarMainWindow.Show();   
        }
    }
}
