using QLKhachSan.Model;
using System;
using System.Collections.Generic;
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
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Login(p); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });
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
