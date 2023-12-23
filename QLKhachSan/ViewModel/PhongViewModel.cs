using QLKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace QLKhachSan.ViewModel
{
    public class PhongViewModel : BasicViewModel
    {
        private List<int?> _LISTNUMBER;
        public List<int?> LISTNUMBER { get { return _LISTNUMBER; } set { _LISTNUMBER = value; OnPropertyChanged(); } }
        private List<int?> _ListNumber;
        public List<int?> ListNumber { get { return _ListNumber; } set { _ListNumber = value; OnPropertyChanged(); } }
        //Dịch vụ
        private List<string> _TTENDICHVU;
        public List<string> TENDICHVU { get { return _TTENDICHVU; } set { _TTENDICHVU = value; OnPropertyChanged(); } }
        private List<string> _TenDV;
        public List<string> TenDV { get { return _TenDV; } set { _TenDV = value; OnPropertyChanged(); } }
        private ObservableCollection<DICHVU> _ListDV;
        public ObservableCollection<DICHVU> ListDV { get { return _ListDV; } set { _ListDV = value; OnPropertyChanged(); } }
        //Phòng
        private List<string> _SSOPHONG;
        public List<string> SSOPHONG { get { return _SSOPHONG; } set { _SSOPHONG = value; OnPropertyChanged(); } }
        private List<string> _SoPhong;
        public List<string> SoPhong { get { return _SoPhong; } set { _SoPhong = value; OnPropertyChanged(); } }
        //Loại phòng
        private ObservableCollection<LOAIPHONG> _LoaiPhong;
        public ObservableCollection<LOAIPHONG> LoaiPhong { get { return _LoaiPhong; } set { _LoaiPhong = value; OnPropertyChanged(); } }
        private int? _SLGIUONG;
        public int? SLGIUONG { get { return _SLGIUONG; } set { _SLGIUONG = value; OnPropertyChanged(); } }
        private int? _NGUOITOIDA;
        public int? NGUOITOIDA { get { return _NGUOITOIDA; } set { _NGUOITOIDA = value; OnPropertyChanged(); } }
        private double? _DIENTICH;
        public double? DIENTICH { get { return _DIENTICH; } set { _DIENTICH = value; OnPropertyChanged(); } }
        private string _LOAIGIUONG;
        public string LOAIGIUONG { get { return _LOAIGIUONG; } set { _LOAIGIUONG = value; OnPropertyChanged(); } }
        private decimal? _GIA;
        public decimal? GIA { get { return _GIA; } set { _GIA = value; OnPropertyChanged(); } }
        //
        private ObservableCollection<PHONG> _ListPhong;
        public ObservableCollection<PHONG> ListPhong { get { return _ListPhong; } set { _ListPhong = value; OnPropertyChanged(); } }
        private LOAIPHONG _SelectedItem;
        public LOAIPHONG SelectedItem
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
                    MALOAI = SelectedItem.MALOAI;
                    SLGIUONG = SelectedItem.SLGIUONG;
                    DIENTICH = SelectedItem.DIENTICH;
                    NGUOITOIDA = SelectedItem.NGUOITOIDA;  
                    LOAIGIUONG = SelectedItem.LOAIGIUONG;
                    GIA = SelectedItem.GIA;

                }
            }
        }

        private string _MALOAI;
        public string MALOAI { get { return _MALOAI; } set { _MALOAI = value; OnPropertyChanged(); } }
        private string _SOPHONG;
        public string SOPHONG { get { return _SOPHONG; } set { _SOPHONG = value; OnPropertyChanged(); } }
        private int? _TANG;
        public int? TANG { get { return _TANG; } set { _TANG = value; OnPropertyChanged(); } }
        private string _TINHTRANG;
        public string TINHTRANG { get { return _TINHTRANG; } set { _TINHTRANG = value; OnPropertyChanged(); } }
        private string _MACTPDP;
        public string MACTPDP { get { return _MACTPDP; } set { _MACTPDP = value; OnPropertyChanged(); } }

        public ICommand DatDichVuCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public PhongViewModel()
        {
            LoaiPhong = new ObservableCollection<LOAIPHONG>(DataProvider.Ins.DB.LOAIPHONGs);
            ListNumber = new List<int?>();
            ListPhong = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs);
            TenDV = new List<string>();
            ListDV = new ObservableCollection<DICHVU>(DataProvider.Ins.DB.DICHVUs);
            SoPhong = new List<string>();
            foreach (var dv in ListDV)
                TenDV.Add(dv.TENDV);
            foreach (var phong in ListPhong)
            {
                if (phong.TINHTRANG == "Đang được sử dụng")
                    SoPhong.Add(phong.SOPHONG);
            }
            for (int i = 1; i <= 30; i++)
                ListNumber.Add(i);
            DatDichVuCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                DatDichVuWindow wd = new DatDichVuWindow();
                var addVM = wd.DataContext as PhieuDatDichVuViewModel;
                addVM.TTENDV = TenDV;
                addVM.SSOPHONG = SoPhong;
                addVM.LISTNUMBER = ListNumber;
                wd.ShowDialog();
            }
            );
            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                var loaiphong = new LOAIPHONG() { MALOAI = MALOAI, SLGIUONG = SLGIUONG, LOAIGIUONG = LOAIGIUONG, GIA = GIA, NGUOITOIDA = NGUOITOIDA, DIENTICH = DIENTICH};
                DataProvider.Ins.DB.LOAIPHONGs.Add(loaiphong);
                DataProvider.Ins.DB.SaveChanges();

                LoaiPhong.Add(loaiphong);
                MessageBox.Show("Thêm loại phòng thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            });
            EditCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                var loaiphong = DataProvider.Ins.DB.LOAIPHONGs.Where(x => x.MALOAI == SelectedItem.MALOAI).SingleOrDefault();
                loaiphong.SLGIUONG = SLGIUONG;
                loaiphong.LOAIGIUONG = LOAIGIUONG;
                loaiphong.GIA = GIA;
                loaiphong.NGUOITOIDA = NGUOITOIDA;
                loaiphong.DIENTICH = DIENTICH;
                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.MALOAI = MALOAI;
                MessageBox.Show("Sửa thông tin thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            });
            CancelCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                MALOAI = LOAIGIUONG = string.Empty;
                SLGIUONG = NGUOITOIDA = null;
                GIA = null;
                DIENTICH = null;
                SelectedItem = null;
            });
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                return SelectedItem != null;
            }, (p) =>
            {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.OK)
                {
                    DataProvider.Ins.DB.LOAIPHONGs.Remove(SelectedItem);
                    DataProvider.Ins.DB.SaveChanges();
                    LoaiPhong.Remove(SelectedItem);
                    MessageBox.Show("Xóa loại phòng thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            });
        }
    }
}
