﻿using QLKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using static QLKhachSan.ViewModel.BasicViewModel;

namespace QLKhachSan.ViewModel
{

    public class MainViewModel : BasicViewModel
    {
        private ObservableCollection<NHANVIEN> _ListNV;
        public ObservableCollection<NHANVIEN> ListNV { get { return _ListNV; } set { _ListNV = value; OnPropertyChanged(); } }
        private string _MANV;
        public string MANV { get { return _MANV; } set { _MANV = value; OnPropertyChanged(); } }
        private string _MMANV;
        public string MMANV { get { return _MMANV; } set { _MMANV = value; OnPropertyChanged(); } }
        private string _TENNV;
        public string TENNV { get { return _TENNV; } set { _TENNV = value; OnPropertyChanged(); } }
        private string _GIOITINH;
        public string GIOITINH { get { return _GIOITINH; } set { _GIOITINH = value; OnPropertyChanged(); } }
        private string _DIACHI;
        public string DIACHI { get { return _DIACHI; } set { _DIACHI = value; OnPropertyChanged(); } }
        private string _SDT;
        public string SDT { get { return _SDT; } set { _SDT = value; OnPropertyChanged(); } }
        private string _EMAIL;
        public string EMAIL { get { return _EMAIL; } set { _EMAIL = value; OnPropertyChanged(); } }
        private string _VITRILAMVIEC;
        public string VITRILAMVIEC { get { return _VITRILAMVIEC; } set { _VITRILAMVIEC = value; OnPropertyChanged(); } }
        private DateTime? _NGSINH;
        public DateTime? NGSINH { get { return _NGSINH; } set { _NGSINH = value; OnPropertyChanged(); } }
        private string _ImagePath;
        public string ImagePath { get { return _ImagePath; } set { _ImagePath = value; OnPropertyChanged(); } }

        public bool IsLoaded = false;
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand DatPhongCommand { get; set; }
        public ICommand LogOutCommand { get; set; }
        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
            IsLoaded = true;
            if (p == null)
                return;
            p.Hide();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();
            if (loginWindow.DataContext == null)
                return;
            var loginVM = loginWindow.DataContext as LoginViewModel;
            if (loginVM.IsLogin)
            {
                ListNV = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs);
                MANV = loginVM.MANV;
                var info = DataProvider.Ins.DB.NHANVIENs.FirstOrDefault(x => x.MANV == MANV);
                MMANV = MANV;
                TENNV = info.TENNV;
                GIOITINH = info.GIOITINH;
                SDT = info.SDT;
                DIACHI = info.DIACHI;
                NGSINH = info.NGSINH;
                EMAIL = info.EMAIL;
                VITRILAMVIEC = info.VITRILAMVIEC;
                if (TENNV == "Nguyễn Hữu Trường")
                {
                    ImagePath = "Images/HT.jpg";
                }
                if (TENNV == "Trần Trung Thông")
                {
                        ImagePath = "Images/3T.jpg";
                    }
                    if (TENNV == "Tăng Thanh Thiện")
                    {
                        ImagePath = "Images/TT.jpg";
                    }
                    p.Show();
                }
                else p.Close();
            }
        );
            LogOutCommand = new RelayCommand<object>((p) => { return true; }, (p) => { LogOut(); });
        }

        void LogOut()
        {
            IsLoaded = false;
            ListNV.Clear();
            MANV = MMANV = TENNV = GIOITINH = DIACHI = SDT = EMAIL = VITRILAMVIEC = ImagePath = null;
            // Thực hiện các bước cần thiết để thoát và khởi động lại chương trình
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
    }
}