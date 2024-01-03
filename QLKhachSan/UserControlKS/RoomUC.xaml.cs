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
                            DataContext = new InfoViewModel
                            {
                                MAPDP = phong.MAPDP,
                                NGDAT = phong.PHIEUDATPHONG.NGDAT,
                                NGNHAN = phong.PHIEUDATPHONG.NGNHAN,
                                NGTRA = phong.PHIEUDATPHONG.NGTRA,
                                TENKH = phong.PHIEUDATPHONG.KHACHHANG.TENKH,
                                GIOITINH = phong.PHIEUDATPHONG.KHACHHANG.GIOITINH,
                                SDT= phong.PHIEUDATPHONG.KHACHHANG.SDT,
                                QUOCTICH= phong.PHIEUDATPHONG.KHACHHANG.QUOCTICH,
                                SOCCCD= phong.PHIEUDATPHONG.KHACHHANG.SOCCCD,
                                NGSINH= phong.PHIEUDATPHONG.KHACHHANG.NGSINH,
                                EMAIL= phong.PHIEUDATPHONG.KHACHHANG.EMAIL,
                                DIACHI= phong.PHIEUDATPHONG.KHACHHANG.DIACHI

                            }
                        };
                        wd.ShowDialog();
                    }  
                   else
                    {
                        MessageBox.Show("Phòng trống!", "Thông báo", MessageBoxButton.OK);
                    }    
                    //if (phong.MAPDP != null)
                    //{
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