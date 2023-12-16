using QLKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QLKhachSan.ViewModel.BasicViewModel;
using System.Windows.Input;

namespace QLKhachSan.ViewModel
{
    public class NhanVienViewModel : BasicViewModel
    {
        private ObservableCollection<NHANVIEN> _ListNV;
        public ObservableCollection<NHANVIEN> ListNV { get { return _ListNV; } set { _ListNV = value; OnPropertyChanged(); } }
        private NHANVIEN _SelectedItem;
        public NHANVIEN SelectedItem
        {
            get
            {
                return _SelectedItem;
            }
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    MANV = SelectedItem.MANV;
                    TENNV = SelectedItem.TENNV;
                    DIACHI = SelectedItem.DIACHI;
                    GIOITINH = SelectedItem.GIOITINH;
                    SDT = SelectedItem.SDT;
                    EMAIL = SelectedItem.EMAIL;
                    VITRILAMVIEC = SelectedItem.VITRILAMVIEC;
                    LUONG = SelectedItem.LUONG;
                    NGVL = SelectedItem.NGVL;
                    NGSINH = SelectedItem.NGSINH;
                }
            }
        }
        private string _MANV;
        public string MANV { get { return _MANV; } set { _MANV = value; OnPropertyChanged(); } }
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

        private decimal? _LUONG;
        public decimal? LUONG { get { return _LUONG; } set { _LUONG = value; OnPropertyChanged(); } }

        private DateTime? _NGVL;
        public DateTime? NGVL { get { return _NGVL; } set { _NGVL = value; OnPropertyChanged(); } }

        private DateTime? _NGSINH;
        public DateTime? NGSINH { get { return _NGSINH; } set { _NGSINH = value; OnPropertyChanged(); } }
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public NhanVienViewModel()
        {
            ListNV = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs);
            AddCommand = new RelayCommand<object>((p) =>
            {
                //if (string.IsNullOrEmpty(MANV))
                //    return false;
                var TenNVlist = DataProvider.Ins.DB.NHANVIENs.Where(x => x.MANV == MANV);
                if (TenNVlist == null || TenNVlist.Count() != 0)
                    return false;
                return true;
            }, (p) =>
            {
                int maxCode = ListNV.Max(nv => int.Parse(nv.MANV.Substring(2)));
                string nextCode = $"NV{maxCode + 1:000}";
                var nhanvien = new NHANVIEN() { MANV = nextCode, TENNV = TENNV, GIOITINH = GIOITINH, SDT = SDT, EMAIL = EMAIL, LUONG = LUONG, VITRILAMVIEC = VITRILAMVIEC, NGSINH = NGSINH, NGVL = NGVL, DIACHI = DIACHI };
                DataProvider.Ins.DB.NHANVIENs.Add(nhanvien);
                DataProvider.Ins.DB.SaveChanges();

                ListNV.Add(nhanvien);
            });
            EditCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(MANV) || SelectedItem == null)
                    return false;
                var MaNVlist = DataProvider.Ins.DB.NHANVIENs.Where(x => x.MANV == SelectedItem.MANV);
                if (MaNVlist == null || MaNVlist.Count() == 0)
                    return false;
                return true;
            }, (p) =>
            {
                var nhanvien = DataProvider.Ins.DB.NHANVIENs.Where(x => x.MANV == SelectedItem.MANV).SingleOrDefault();
                nhanvien.TENNV = TENNV;
                nhanvien.GIOITINH = GIOITINH;
                nhanvien.SDT = SDT;
                nhanvien.EMAIL = EMAIL;
                nhanvien.LUONG = LUONG;
                nhanvien.VITRILAMVIEC = VITRILAMVIEC;
                nhanvien.NGSINH = NGSINH;
                nhanvien.NGVL = NGVL;
                nhanvien.DIACHI = DIACHI;
                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.MANV = MANV;
            });
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                return SelectedItem != null;
            }, (p) =>
            {
                DataProvider.Ins.DB.NHANVIENs.Remove(SelectedItem);
                DataProvider.Ins.DB.SaveChanges();
                ListNV.Remove(SelectedItem);
            });
        }
    }
}
