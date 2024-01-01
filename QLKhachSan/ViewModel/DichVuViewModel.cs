using QLKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QLKhachSan.ViewModel.BasicViewModel;
using System.Windows.Input;
using System.Windows.Documents;
using System.Windows;

namespace QLKhachSan.ViewModel
{
    public class DichVuViewModel : BasicViewModel
    {
        // Chi tiết phiếu dịch vụ
        private ObservableCollection<CHITIETDICHVU> _ListCTPDV;
        public ObservableCollection<CHITIETDICHVU> ListCTPDV { get { return _ListCTPDV; } set { _ListCTPDV = value; OnPropertyChanged(); } }
        private string _MAPDV;
        public string MAPDV { get { return _MAPDV; } set { _MAPDV = value; OnPropertyChanged(); } }
        private int? _SLDV;
        public int? SLDV { get { return _SLDV; } set { _SLDV = value; OnPropertyChanged(); } }
        private decimal? _GIA;
        public decimal? GIA { get { return _GIA; } set { _GIA = value; OnPropertyChanged(); } }
        // Dịch vụ
        private ObservableCollection<DICHVU> _ListDV;
        public ObservableCollection<DICHVU> ListDV { get { return _ListDV; } set { _ListDV = value; OnPropertyChanged(); } }
        private DICHVU _SelectedItem;
        public DICHVU SelectedItem
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
                    MADV = SelectedItem.MADV;
                    TENDV = SelectedItem.TENDV;
                    DONGIA = SelectedItem.DONGIA;
                }
            }
        }
        private string _MADV;
        public string MADV { get { return _MADV; } set { _MADV = value; OnPropertyChanged(); } }
        private string _TENDV;
        public string TENDV { get { return _TENDV; } set { _TENDV = value; OnPropertyChanged(); } }
        private decimal? _DONGIA;
        public decimal? DONGIA { get { return _DONGIA; } set { _DONGIA = value; OnPropertyChanged(); } }
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public DichVuViewModel()
        {
            ListCTPDV = new ObservableCollection<CHITIETDICHVU>(DataProvider.Ins.DB.CHITIETDICHVUs);
            ListDV = new ObservableCollection<DICHVU>(DataProvider.Ins.DB.DICHVUs);
            AddCommand = new RelayCommand<object>((p) =>
            {
                //if (string.IsNullOrEmpty(MADV))
                //    return false;
                //var TenDVlist = DataProvider.Ins.DB.DICHVUs.Where(x => x.MADV == MADV);
                //if (TenDVlist == null || TenDVlist.Count() != 0)
                //    return false;
                //return true;
                if (TENDV == null || DONGIA == null)
                    return false;
                return true;
            }, (p) =>
            {
                int maxCode = ListDV.Max(dv => int.Parse(dv.MADV.Substring(2)));
                string nextCode = $"DV{maxCode + 1:000}";
                var dichvu = new DICHVU() { MADV = nextCode, TENDV = TENDV, DONGIA = DONGIA, };
                DataProvider.Ins.DB.DICHVUs.Add(dichvu);
                DataProvider.Ins.DB.SaveChanges();
                ListDV.Add(dichvu);
                TENDV = string.Empty;
                DONGIA = null;
                MessageBox.Show("Thêm dịch vụ thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            });
            EditCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(MADV) || SelectedItem == null)
                    return false;
                var MaDVlist = DataProvider.Ins.DB.DICHVUs.Where(x => x.MADV == SelectedItem.MADV);
                if (MaDVlist == null || MaDVlist.Count() == 0)
                    return false;
                return true;
            }, (p) =>
            {
                var dichvu = DataProvider.Ins.DB.DICHVUs.Where(x => x.MADV == SelectedItem.MADV).SingleOrDefault();
                dichvu.TENDV = TENDV;
                dichvu.DONGIA = DONGIA;
                DataProvider.Ins.DB.SaveChanges();
                TENDV = string.Empty;
                DONGIA = null;
                MessageBox.Show("Sửa thông tin thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            });
            CancelCommand = new RelayCommand<object>((p) =>
            {
                if (TENDV == null && DONGIA == null && SelectedItem == null)
                    return false;
                return true;
            }, (p) =>
            {
                TENDV = string.Empty;
                DONGIA = null;
                SelectedItem = null;
            });
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                return SelectedItem != null;
            }, (p) =>
            {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if(result == MessageBoxResult.OK)
                {
                    TENDV = string.Empty;
                    DONGIA = null;
                    DataProvider.Ins.DB.DICHVUs.Remove(SelectedItem);
                    DataProvider.Ins.DB.SaveChanges();
                    ListDV.Remove(SelectedItem);
                    MessageBox.Show("Xóa dịch vụ thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                SelectedItem = null;
            });
        }
    }
}
