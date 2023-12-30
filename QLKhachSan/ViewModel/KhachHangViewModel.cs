using QLKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

namespace QLKhachSan.ViewModel
{
    public  class KhachHangViewModel: BasicViewModel
    {

        private ObservableCollection<KHACHHANG> _ListKH;
        public ObservableCollection<KHACHHANG> ListKH { get { return _ListKH; } set { _ListKH = value; OnPropertyChanged(); } }
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
        //private KHACHHANG _SelectedItem;
        //public KHACHHANG SelectedItem
        //{
        //    get
        //    {
        //        if (IsSearching)
        //        {
        //            return _collectionView?.CurrentItem as KHACHHANG;
        //        }
        //        else
        //        {
        //            return _SelectedItem;
        //        }
        //    }
        //    set
        //    {
        //        _SelectedItem = value;
        //        OnPropertyChanged();

        //        if (SelectedItem != null)
        //        {
        //            MAKH = SelectedItem.MAKH;
        //            TENKH = SelectedItem.TENKH;
        //            DIACHI = SelectedItem.DIACHI;
        //            GIOITINH = SelectedItem.GIOITINH;
        //            SDT = SelectedItem.SDT;
        //            EMAIL = SelectedItem.EMAIL;
        //            SOCCCD = SelectedItem.SOCCCD;
        //            QUOCTICH = SelectedItem.QUOCTICH;
        //            NGSINH = SelectedItem.NGSINH;
        //        }
        //    }
        //}

        private string _MAKH;
        public string MAKH { get { return _MAKH; } set { _MAKH = value; OnPropertyChanged(); } }
        private string _TENKH;
        public string TENKH { get { return _TENKH; } set { _TENKH = value; OnPropertyChanged(); if(IsSearching) CollectionView.Refresh(); } }
        private string _GIOITINH;
        public string GIOITINH { get { return _GIOITINH; } set { _GIOITINH = value; OnPropertyChanged(); if(IsSearching) CollectionView.Refresh(); } }
        private DateTime? _NGSINH;
        public DateTime? NGSINH { get { return _NGSINH; } set { _NGSINH = value; OnPropertyChanged(); } }
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

        public ICommand ToggleSearchCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand DeleteCommand { get; set; }


        private ICollectionView _collectionView;
        public ICollectionView CollectionView
        {
            get { return _collectionView; }
            set { _collectionView = value; OnPropertyChanged(); }
        }

        private bool Filter(object item)
        {
            string searchText = string.Empty;
            string searchText1 = string.Empty;
            if (string.IsNullOrEmpty(TENKH) && string.IsNullOrEmpty(GIOITINH))
                return true;
            var kh = (KHACHHANG)item;
            if (TENKH != null)
                searchText = TENKH.ToLowerInvariant();
            if (GIOITINH != null)
                searchText1 = GIOITINH.ToLowerInvariant();
            return kh.TENKH.ToLowerInvariant().Contains(searchText) && kh.GIOITINH.ToLowerInvariant().Contains(searchText1);
        }

        private bool _isSearching;
        public bool IsSearching
        {
            get { return _isSearching; }
            set
            {
                _isSearching = value;
                OnPropertyChanged();
            }
        }

        public KhachHangViewModel()
        {
            ListKH = new ObservableCollection<KHACHHANG>(DataProvider.Ins.DB.KHACHHANGs);
            CollectionView = CollectionViewSource.GetDefaultView(ListKH);
            CollectionView.Filter = Filter;
            //if (SelectedItem != null)
            //    IsSearching = false;
            if (CollectionView != null && SelectedItem != null)
            {
                CollectionView.MoveCurrentTo(SelectedItem);
                CollectionView.Refresh();
            }
            AddCommand = new RelayCommand<object>((p) => 
            {
                if (IsSearching)
                    return false;
                //if (string.IsNullOrEmpty(MAKH))
                //    return false;
                // điều kiện không được để trống 
                //var TenKHlist = DataProvider.Ins.DB.KHACHHANGs.Where(x => x.MAKH == MAKH);
                //if (TenKHlist == null || TenKHlist.Count() != 0)
                //    return false;
                if (TENKH == null || GIOITINH == null || NGSINH == null || DIACHI == null || SDT == null || QUOCTICH == null)
                    return false;
                return true;
            }, (p) =>
            {
                int maxCode = ListKH.Max(kh => int.Parse(kh.MAKH.Substring(2)));
                string nextCode = $"KH{maxCode + 1:000}";
                var khachhang = new KHACHHANG() { MAKH = nextCode, TENKH = TENKH, GIOITINH = GIOITINH, SDT = SDT, EMAIL = EMAIL, SOCCCD = SOCCCD, QUOCTICH = QUOCTICH, NGSINH = NGSINH, DIACHI = DIACHI };
                DataProvider.Ins.DB.KHACHHANGs.Add(khachhang);
                DataProvider.Ins.DB.SaveChanges();

                ListKH.Add(khachhang);
                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            });
            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem==null)
                    return false;

                //var MaKHlist = DataProvider.Ins.DB.KHACHHANGs.Where(x => x.MAKH == SelectedItem.MAKH);
                //if (MaKHlist == null || MaKHlist.Count() == 0)
                //    return false;
                return true;
            }, (p) =>
            {
                var khachhang = DataProvider.Ins.DB.KHACHHANGs.Where(x => x.MAKH == SelectedItem.MAKH).SingleOrDefault();                
                khachhang.TENKH = TENKH;
                khachhang.GIOITINH = GIOITINH;
                khachhang.SDT = SDT;
                khachhang.EMAIL = EMAIL;
                khachhang.SOCCCD = SOCCCD;
                khachhang.QUOCTICH = QUOCTICH;
                khachhang.NGSINH = NGSINH;
                khachhang.DIACHI = DIACHI;
                DataProvider.Ins.DB.SaveChanges();

                MessageBox.Show("Sửa thông tin thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                ListKH = new ObservableCollection<KHACHHANG>(DataProvider.Ins.DB.KHACHHANGs);
            });
            CancelCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                TENKH = GIOITINH = SDT = EMAIL = SOCCCD = QUOCTICH = DIACHI = string.Empty;
                NGSINH = null;
                if (SelectedItem != null)
                    SelectedItem = null;
                //ListKH = new ObservableCollection<KHACHHANG>(DataProvider.Ins.DB.KHACHHANGs);
            });
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                return SelectedItem != null;
            }, (p) =>
            {
                TENKH = GIOITINH = SDT = EMAIL = SOCCCD = QUOCTICH = DIACHI = string.Empty;
                NGSINH = null;
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.OK)
                {
                    DataProvider.Ins.DB.KHACHHANGs.Remove(SelectedItem);
                    DataProvider.Ins.DB.SaveChanges();
                    ListKH.Remove(SelectedItem);
                    MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                SelectedItem = null;
                ListKH = new ObservableCollection<KHACHHANG>(DataProvider.Ins.DB.KHACHHANGs);
            });
            ToggleSearchCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                TENKH = GIOITINH = SDT = EMAIL = SOCCCD = QUOCTICH = DIACHI = string.Empty;
                NGSINH = null;
                IsSearching = !IsSearching;
                if (!IsSearching)
                {
                    TENKH = GIOITINH = SDT = EMAIL = SOCCCD = QUOCTICH = DIACHI = string.Empty;
                    NGSINH = null;
                }
                //if(IsSearching)
                //{
                //    ListKH = new ObservableCollection<KHACHHANG>(DataProvider.Ins.DB.KHACHHANGs);
                //    CollectionView = CollectionViewSource.GetDefaultView(ListKH);
                //    CollectionView.Filter = Filter;
                //}    
            });
        }
        
    }
}
