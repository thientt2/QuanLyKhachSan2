using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QLKhachSan.ViewModel.BasicViewModel;
using System.Windows.Input;
using System.Windows;
using QLKhachSan.Model;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace QLKhachSan.ViewModel
{
    public class ChangePasswordViewModel : BasicViewModel
    {
        private ObservableCollection<DANGNHAP> _ListDN;
        public ObservableCollection<DANGNHAP> ListDN { get { return _ListDN; } set { _ListDN = value; OnPropertyChanged(); } }
        private int _IID;
        public int IID { get { return _IID; } set { _IID = value; OnPropertyChanged(); } }
        private int _IIID;
        public int IIID { get { return _IIID; } set { _IIID = value; OnPropertyChanged(); } }
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; OnPropertyChanged(); } }
        private string _MATKHAU;
        public string MATKHAU { get { return _MATKHAU; } set { _MATKHAU = value; OnPropertyChanged(); } }
        private string _oldpassword;
        public string OldPassword { get { return _oldpassword; } set { _oldpassword = value; OnPropertyChanged(); } }
        private string _newpassword;
        public string NewPassword { get { return _newpassword; } set { _newpassword = value; OnPropertyChanged(); } }
        private string _confirmpassword;
        public string ConfirmPassword { get { return _confirmpassword; } set { _confirmpassword = value; OnPropertyChanged(); } }
        private string _MMATKHAU;
        public string MMATKHAU { get { return _MMATKHAU; } set { _MMATKHAU = value; OnPropertyChanged(); } }

        public ICommand ConfirmCommand { get; set; }

        public ChangePasswordViewModel()
        {
            ConfirmCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { ChangePW(p); });
            ListDN = new ObservableCollection<DANGNHAP>(DataProvider.Ins.DB.DANGNHAPs);
        }

        void ChangePW(Window p)
        {
            IIID = IID;
            if (string.IsNullOrEmpty(OldPassword) || string.IsNullOrEmpty(NewPassword) || string.IsNullOrEmpty(ConfirmPassword))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (OldPassword != MMATKHAU)
            {
                MessageBox.Show("Mật khẩu cũ không chính xác!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                OldPassword = NewPassword = ConfirmPassword = string.Empty;
                return;
            }
            if (OldPassword == NewPassword)
            {
                MessageBox.Show("Mật khẩu mới không được trùng mật khẩu cũ", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                OldPassword = NewPassword = ConfirmPassword = string.Empty;
                return;
            }
            if (NewPassword != ConfirmPassword)
            {
                MessageBox.Show("Mật khẩu mới và mật khẩu xác nhận không khớp!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                OldPassword = NewPassword = ConfirmPassword = string.Empty;
                return;
            }
            if (OldPassword == MMATKHAU && NewPassword == ConfirmPassword)
            {
                var userToUpdate = ListDN.FirstOrDefault(dn => dn.ID == IIID);

                if (userToUpdate != null)
                {
                    userToUpdate.MATKHAU = NewPassword;
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    OldPassword = NewPassword = ConfirmPassword = string.Empty;
                    p.Close();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy người dùng!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        public void ClearPasswords()
        {
            OldPassword = NewPassword = ConfirmPassword = string.Empty;
        }

    }
}