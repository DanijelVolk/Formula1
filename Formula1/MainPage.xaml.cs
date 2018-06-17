﻿using Formula1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Media;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Formula1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<Driver> VsiDriverji { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            VsiDriverji = new ObservableCollection<Driver>();
        }

        public async void Page_Loaded(object sender, RoutedEventArgs e)
        {
              await KlicServisa.PopulateDrivers(VsiDriverji);
        }


        private void dsfasdfa_Click(object sender, RoutedEventArgs e)
        {
            mojFrame.Navigate(typeof(PregledDirkacov));
        }

        private void konstruktorji_Click(object sender, RoutedEventArgs e)
        {
            mojFrame.Navigate(typeof(PregeldDirk));
        }

        private void dirke_Click(object sender, RoutedEventArgs e)
        {
            mojFrame.Navigate(typeof(PregledPosamezneDirke));
        }
    }
}
