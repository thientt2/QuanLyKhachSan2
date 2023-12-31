﻿using QLKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace QLKhachSan.ViewModel
{
    class LoginViewModel : BasicViewModel
    {
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; OnPropertyChanged(); } }
        private string _MATKHAU;
        public string MATKHAU { get { return _MATKHAU; } set { _MATKHAU = value; OnPropertyChanged(); } }

        public bool IsLogin { get; set; }
        private string _username;
        public string UserName { get { return _username; } set { _username = value; OnPropertyChanged(); } }

        private int? _IDPHANQUYEN;
        public int? IDPHANQUYEN { get { return _IDPHANQUYEN; } set { _IDPHANQUYEN = value; OnPropertyChanged(); } }
        private string _password;
        public string Password { get { return _password; } set { _password = value; OnPropertyChanged(); } }
        private string _MANV;
        public string MANV { get { return _MANV; } set { _MANV = value; OnPropertyChanged(); } }

        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public LoginViewModel()
        {
            IsLogin = false;
            Password = "";
            UserName = "";
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {try
                {
                    Login(p);
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
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { try
                {
                    Password = p.Password;
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
        }
        void Login(Window p)
        {
            if (p == null)
                return;
            
            var accCount = DataProvider.Ins.DB.DANGNHAPs.Where(x => x.TAIKHOAN == UserName && x.MATKHAU == Password).Count();
            var loggedInUser = DataProvider.Ins.DB.DANGNHAPs.FirstOrDefault(x => x.TAIKHOAN == UserName && x.MATKHAU == Password);

            if (accCount > 0)
            {
                IsLogin = true;
                IDPHANQUYEN = loggedInUser.IDPHANQUYEN;
                MANV = loggedInUser.MANV;
                ID = loggedInUser.ID;
                MATKHAU = loggedInUser.MATKHAU;
                p.Close();
            }
            else
            {
                IsLogin = false;
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }
            
        }     

    }
}
