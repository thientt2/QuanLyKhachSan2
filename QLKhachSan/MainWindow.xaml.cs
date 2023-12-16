using QLKhachSan.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QLKhachSan
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

        private void CancelButton_Client(object sender, RoutedEventArgs e)
        {
            //txtMAKH.Text = "";
            txtTENKH.Text = "";
            txtGIOITINHKH.Text = "";
            txtSDTKH.Text = "";
            txtEMAILKH.Text = "";
            txtQUOCTICH.Text = "";
            txtSOCCCD.Text = "";
            txtDIACHIKH.Text = "";
            txtNGSINHKH.Text = "";
        }

        private void CancelButton_Staff(object sender, RoutedEventArgs e)
        {
            //txtMANV.Text = "";
            txtTENNV.Text = "";
            txtGIOITINHNV.Text = "";
            txtSDTNV.Text = "";
            txtEMAILNV.Text = "";
            txtDIACHINV.Text = "";
            txtVITRILAMVIECNV.Text = "";
            txtLUONGNV.Text = "";
            txtNGVLNV.Text = "";
            txtNGSINHNV.Text = "";
        }

        private void CancelButton_Service(object sender, RoutedEventArgs e)
        {
            //txtMADV.Text = "";
            txtTENDV.Text = "";
            txtDONGIA.Text = "";
        }
    }
}
