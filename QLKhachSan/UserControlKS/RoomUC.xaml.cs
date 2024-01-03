using QLKhachSan.Model;
using QLKhachSan.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace QLKhachSan.UserControlKS
{
    public partial class RoomUC : UserControl
    {
        public RoomUC()
        {
            InitializeComponent();
        }

        // Event handler cho sự kiện Click
        private void ShowSOPHONGButtonClick(object sender, RoutedEventArgs e)
        {
            // Lấy giá trị SOPHONG từ DataContext và hiển thị trong MessageBox
            try
            {
                if (DataContext is PHONG phong)
                {
                   if(phong.MAPDP != null)
                    {
                        InfoWindow wd = new InfoWindow
                        {
                            DataContext = new InfoViewModel { MAPDP = phong.MAPDP, NGDAT = phong.PHIEUDATPHONG.NGDAT, NGNHAN = phong.PHIEUDATPHONG.NGNHAN, NGTRA = phong.PHIEUDATPHONG.NGTRA, TENKH = phong.PHIEUDATPHONG.KHACHHANG.TENKH }
                        };
                        wd.ShowDialog();
                    }  
                   else
                    {
                        MessageBox.Show("Phòng trống!", "Thông báo", MessageBoxButton.OK);
                    }    
                    //if (phong.MAPDP != null)
                    //{
                    //    MessageBox.Show($"SOPHONG: {phong.PHIEUDATPHONG.KHACHHANG.TENKH}", "Thông tin phòng", MessageBoxButton.OK, MessageBoxImage.Information);
                    //}
                    //else
                    //{
                    //    MessageBox.Show("KHACHHANG không tồn tại!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}