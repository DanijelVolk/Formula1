using Formula1.Model;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Formula1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PregledPosamezneDirke : Page
    {



        public ObservableCollection<Result> VsiRezultiDirke { get; set; }
        public ObservableCollection<Race> VsiRaceDirke { get; set; }
        public ObservableCollection<Constructor> VsiKonstruktorjiDirke { get; set; }
        public ObservableCollection<Driver> VsiVoznikiDirke { get; set; }
        public PregledPosamezneDirke()
        {
            this.InitializeComponent();
            VsiRezultiDirke = new ObservableCollection<Result>();
            VsiRaceDirke = new ObservableCollection<Race>();
            VsiKonstruktorjiDirke = new ObservableCollection<Constructor>();
            VsiVoznikiDirke = new ObservableCollection<Driver>();
        }
        public async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            masterList4.ItemsSource = null;
            masterList3.ItemsSource = null;
            masterList2.ItemsSource = null;
            await KlicServisa.PopulateRezultati(VsiRezultiDirke, VsiRaceDirke, VsiVoznikiDirke, VsiKonstruktorjiDirke);
        }

        private void masterList1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var izbranaSezona = (Race)e.ClickedItem;
            masterList2.ItemsSource = null;
           masterList2.ItemsSource = VsiRezultiDirke;
            masterList3.ItemsSource = null;
            masterList3.ItemsSource = VsiVoznikiDirke;
            masterList4.ItemsSource = null;
            masterList4.ItemsSource = VsiKonstruktorjiDirke;
        }

    }
}
