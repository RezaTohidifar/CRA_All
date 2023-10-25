﻿using DataLib;
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
using System.Windows.Shapes;

namespace CRAwpf
{
    /// <summary>
    /// Interaction logic for BatchAction.xaml
    /// </summary>
    public partial class BatchAction : Window
    {
        public BatchAction()
        {
            InitializeComponent();
            APIClient.ApiHelper();
            URLDictionary.URLMETHOD();
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            GetWindow(this).Close();
        }

    }
}
