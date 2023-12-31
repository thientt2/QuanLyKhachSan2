﻿using QLKhachSan.Model;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace QLKhachSan.ViewModel
{
    public class PhieuDatPhongViewModel : BasicViewModel
    {
        //Phòng
        private ObservableCollection<PHONG> _ListPhong;
        public ObservableCollection<PHONG> ListPhong { get { return _ListPhong; } set { _ListPhong = value; OnPropertyChanged(); } }
        
        private List<string> _MMALOAI;
        public List<string> MMALOAI { get { return _MMALOAI; } set { _MMALOAI = value; OnPropertyChanged(); } }
        private string _MALOAI;
        public string MALOAI { get { return _MALOAI; } set { _MALOAI = value; OnPropertyChanged(); } }
        private string _TINHTRANG;
        public string TINHTRANG { get { return _TINHTRANG; } set { _TINHTRANG = value; OnPropertyChanged(); } }
        private string _SOPHONG;
        public string SOPHONG { get { return _SOPHONG; } set { _SOPHONG = value; OnPropertyChanged(); } }
        private List<string> _MaLoai;
        public List<string> MaLoai { get { return _MaLoai; } set { _MaLoai = value; OnPropertyChanged(); } }
        private List<string> _SSOPHONG;
        public List<string> SSOPHONG { get { return _SSOPHONG; } set { _SSOPHONG = value; OnPropertyChanged(); } }
        private List<string> _SoPhong;
        public List<string> SoPhong { get { return _SoPhong; } set { _SoPhong = value; OnPropertyChanged(); } }

        //Khách hàng
        private ObservableCollection<KHACHHANG> _ListKH;
        public ObservableCollection<KHACHHANG> ListKH { get { return _ListKH; } set { _ListKH = value; OnPropertyChanged(); } }
        private List<string> _TTENKH;
        public List<string> TTENKH { get { return _TTENKH; } set { _TTENKH = value; OnPropertyChanged(); } }
        private string _MAKH;
        public string MAKH { get { return _MAKH; } set { _MAKH = value; OnPropertyChanged(); } }
        private string _TENKH;
        public string TENKH { get { return _TENKH; } set { _TENKH = value; OnPropertyChanged(); } }
        private string _GIOITINH;
        public string GIOITINH { get { return _GIOITINH; } set { _GIOITINH = value; OnPropertyChanged(); } }
        private string _DIACHI;
        public string DIACHI { get { return _DIACHI; } set { _DIACHI = value; OnPropertyChanged(); } }
        private string _SDT;
        public string SDT { get { return _SDT; } set { _SDT = value; OnPropertyChanged(); } }
        private string _EMAIL;
        public string EMAIL { get { return _EMAIL; } set { _EMAIL = value; OnPropertyChanged(); } }
        private string _SOCCCD;
        public string SOCCCD { get { return _SOCCCD; } set { _SOCCCD = value; OnPropertyChanged(); } }
        private string _QUOCTICH;
        public string QUOCTICH { get { return _QUOCTICH; } set { _QUOCTICH = value; OnPropertyChanged(); } }
        private DateTime? _NGSINH;
        public DateTime? NGSINH { get { return _NGSINH; } set { _NGSINH = value; OnPropertyChanged(); } }

        //Nhân viên
        private string _MANV;
        public string MANV { get { return _MANV; } set { _MANV = value; OnPropertyChanged(); } }


        //Phiếu đặt phòng
        private ObservableCollection<PHIEUDATPHONG> _ListPDP;
        public ObservableCollection<PHIEUDATPHONG> ListPDP { get { return _ListPDP; } set { _ListPDP = value; OnPropertyChanged(); } }
        private string _MAPDP;
        public string MAPDP { get { return _MAPDP; } set { _MAPDP = value; OnPropertyChanged(); } }
        private DateTime? _NGDAT;
        public DateTime? NGDAT { get { return _NGDAT; } set { _NGDAT = value; OnPropertyChanged(); } }
        private DateTime? _NGNHAN;
        public DateTime? NGNHAN { get { return _NGNHAN; } set { _NGNHAN = value; OnPropertyChanged(); } }
        private DateTime? _NGTRA;
        public DateTime? NGTRA { get { return _NGTRA; } set { _NGTRA = value; OnPropertyChanged(); } }


        //
        public ICommand AddCommand { get; set; }
        public ICommand ShowCommand { get; set; }
        public ICommand ShowCommand1 { get; set; }
        public ICommand CancelCommand { get; set; }

        public PhieuDatPhongViewModel()
        {
            ListKH = new ObservableCollection<KHACHHANG>(DataProvider.Ins.DB.KHACHHANGs);
            ListPhong = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs);
            SSOPHONG = new List<string>();

            ShowCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                try
                {
                    foreach (var kh in ListKH)
                    {
                        if (kh.TENKH == TENKH)
                        {
                            MAKH = kh.MAKH.ToString();
                            GIOITINH = kh.GIOITINH.ToString();
                            if (kh.SOCCCD != null)
                                SOCCCD = kh.SOCCCD.ToString();
                            QUOCTICH = kh.QUOCTICH.ToString();
                            DIACHI = kh.DIACHI.ToString();
                            if (kh.EMAIL != null)
                                EMAIL = kh.EMAIL.ToString();
                            SDT = kh.SDT.ToString();
                            NGSINH = kh.NGSINH;
                        }
                    }
                }                
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });


            ShowCommand1 = new RelayCommand<ComboBox>((p) => { return true; }, (p) =>
            {
                try
                {
                    SoPhong = new List<string>();

                    foreach (var phong in ListPhong)
                    {
                        if (phong.MALOAI == MALOAI && phong.TINHTRANG == "Trống")
                        {
                            SoPhong.Add(phong.SOPHONG);
                        }
                    }
                    SSOPHONG = SoPhong;
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            MessageBox.Show($"Lỗi: {validationError.ErrorMessage}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show($"Lỗi cập nhật cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });


            ListPDP = new ObservableCollection<PHIEUDATPHONG>(DataProvider.Ins.DB.PHIEUDATPHONGs);

            AddCommand = new RelayCommand<object>((p) =>
            {
                int maxCode = ListPDP.Max(dp => int.Parse(dp.MAPDP.Substring(2)));
                MAPDP = $"DP{maxCode + 1:000}";
                if (TENKH == null || MANV == null || MAPDP == null || MALOAI == null || SOPHONG == null || NGDAT == null || NGNHAN == null || NGTRA == null)
                    return false;
                return true;
            }, (p) =>
            {
                try
                {
                    
                    if (NGDAT != NGNHAN)
                    {
                        TimeSpan newTime = new TimeSpan(18, 0, 0);
                        NGNHAN = NGNHAN.Value.Date.Add(newTime);    
                    }
                    TimeSpan newTime1 = new TimeSpan(12, 0, 0);
                    NGTRA = NGTRA.Value.Date.Add(newTime1);
                    if (NGNHAN >= NGTRA)
                        throw new Exception("Ngày trả phải lớn hơn ngày nhận.");
                    if (NGDAT > NGNHAN)
                        throw new Exception("Ngày đặt phải nhỏ hơn ngày nhận.");
                    var pdp = new PHIEUDATPHONG() { MAPDP = MAPDP, MAKH = MAKH, MANV = MANV, NGDAT = NGDAT, NGNHAN = NGNHAN, NGTRA = NGTRA };
                    DataProvider.Ins.DB.PHIEUDATPHONGs.Add(pdp);
                    foreach (var phong in ListPhong)
                    {
                        if (phong.SOPHONG == SOPHONG && phong.TINHTRANG == "Trống")
                        {
                            phong.TINHTRANG = "Đã đặt";
                            phong.MAPDP = MAPDP;
                            break;
                        }
                    }
                    foreach (var phong in ListPhong)
                    {
                        if (phong.SOPHONG == SOPHONG)
                        {
                            MAPDP = phong.MAPDP;
                            break;
                        }
                    }
                    //ListPDP.Add(pdp);
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Đặt phòng thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    TENKH = GIOITINH = SOCCCD = QUOCTICH = DIACHI = EMAIL = MALOAI = MAKH = SDT = "";
                    NGSINH = null;
                    SOPHONG = null;
                    NGDAT = NGNHAN = NGTRA = null;
                    FrameworkElement window = p as FrameworkElement;
                    var w = window as Window;
                    if (w != null)
                    {
                        w.Close();
                    }
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            MessageBox.Show($"Lỗi: {validationError.ErrorMessage}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show($"Lỗi cập nhật cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    NGNHAN = null;
                    NGDAT = null;
                    NGTRA = null;

                }
            });
            CancelCommand = new RelayCommand<object>((p) =>
            {
                if (TENKH == null && MANV == null && MALOAI == null && SOPHONG == null && NGDAT == null && NGNHAN == null && NGTRA == null)
                    return false;
                return true;
            }, (p) =>
            {
                try
                {
                    TENKH = GIOITINH = SOCCCD = QUOCTICH = DIACHI = EMAIL = MALOAI = "";
                    MAKH = SDT = SOPHONG = null;
                    NGSINH = null;
                    NGDAT = NGNHAN = NGTRA = null;
                }                
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });        
        }
    }
}
