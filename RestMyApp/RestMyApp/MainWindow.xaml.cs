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
using System.Net;
using System.IO;

namespace RestMyApp
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

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            var request = (HttpWebRequest)WebRequest.Create(tbInputData.Text);
            request.MaximumAutomaticRedirections = 4;
            request.MaximumResponseHeadersLength = 4;
            var response = (HttpWebResponse)request.GetResponse();
            var reciveStream = response.GetResponseStream();
            var readStream = new StreamReader(reciveStream, Encoding.UTF8);
            
        }
    }
}
