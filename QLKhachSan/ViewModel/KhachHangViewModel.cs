using QLKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QLKhachSan.ViewModel
{
    public  class KhachHangViewModel: BasicViewModel
    {
        private ObservableCollection<KHACHHANG> _List;
        public ObservableCollection<KHACHHANG> List { get { return _List; } set { _List = value; OnPropertyChanged(); } }
        private KHACHHANG _SelectedItem;
        public KHACHHANG SelectedItem
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
                    MAKH = SelectedItem.MAKH;
                    TENKH = SelectedItem.TENKH;
                    DIACHI = SelectedItem.DIACHI;
                    GIOITINH = SelectedItem.GIOITINH;
                    SDT = SelectedItem.SDT;
                    EMAIL = SelectedItem.EMAIL;
                    SOCCCD = SelectedItem.SOCCCD;
                    QUOCTICH = SelectedItem.QUOCTICH;
                    NGSINH = SelectedItem.NGSINH;
                }
            }
        }
        private string _TENKH;
        public string TENKH { get { return _TENKH; } set { _TENKH = value; OnPropertyChanged(); } }
        private string _MAKH;
        public string MAKH { get { return _MAKH; } set { _MAKH = value; OnPropertyChanged(); } }
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
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public KhachHangViewModel()
        {
            List = new ObservableCollection<KHACHHANG>(DataProvider.Ins.DB.KHACHHANGs);
            AddCommand = new RelayCommand<object>((p) => 
            {
                if (string.IsNullOrEmpty(MAKH))
                    return false;
                var TenKHlist=DataProvider.Ins.DB.KHACHHANGs.Where(x => x.MAKH == MAKH);
                if (TenKHlist == null || TenKHlist.Count() != 0)
                    return false;
                return true;
            }, (p) =>
            {
                var khachhang = new KHACHHANG() { MAKH = MAKH, TENKH = TENKH, GIOITINH = GIOITINH, SDT = SDT, EMAIL = EMAIL, SOCCCD = SOCCCD, QUOCTICH = QUOCTICH, NGSINH = NGSINH, DIACHI = DIACHI };
                DataProvider.Ins.DB.KHACHHANGs.Add(khachhang);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(khachhang);
            });
            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem==null)
                    return false;
                var MaKHlist = DataProvider.Ins.DB.KHACHHANGs.Where(x => x.MAKH == SelectedItem.MAKH);
                if (MaKHlist == null || MaKHlist.Count() == 0)
                    return false;
                return true;
            }, (p) =>
            {
                var khachhang = DataProvider.Ins.DB.KHACHHANGs.Where(x => x.MAKH == SelectedItem.MAKH).SingleOrDefault();
                khachhang.MAKH = MAKH;
                khachhang.TENKH = TENKH;
                khachhang.GIOITINH = GIOITINH;
                khachhang.SDT = SDT;
                khachhang.EMAIL = EMAIL;
                khachhang.SOCCCD = SOCCCD;
                khachhang.QUOCTICH = QUOCTICH;
                khachhang.NGSINH = NGSINH;
                khachhang.DIACHI = DIACHI;
                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.MAKH = MAKH;
            });
        }
        
    }
}
