using QLKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
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
        //PDP
        private ObservableCollection<PHIEUDATPHONG> _ListPDP;
        public ObservableCollection<PHIEUDATPHONG> ListPDP { get { return _ListPDP; } set { _ListPDP = value; OnPropertyChanged(); } }
        private DateTime? _NGNHAN;
        public DateTime? NGNHAN { get { return _NGNHAN; } set { _NGNHAN = value; OnPropertyChanged(); } }
        private string _MAPDP;
        public string MAPDP { get { return _MAPDP; } set { _MAPDP = value; OnPropertyChanged(); } }
        private string _MAPDP1;
        public string MAPDP1 { get { return _MAPDP1; } set { _MAPDP1 = value; OnPropertyChanged(); } }
        private DateTime? _NGTRA;
        public DateTime? NGTRA { get { return _NGTRA; } set { _NGTRA = value; OnPropertyChanged(); } }
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
                    MALOAI = SelectedItem.MALOAI; //trùng với bảng kia
                    SLGIUONG = SelectedItem.SLGIUONG;
                    DIENTICH = SelectedItem.DIENTICH;
                    NGUOITOIDA = SelectedItem.NGUOITOIDA;  
                    LOAIGIUONG = SelectedItem.LOAIGIUONG;
                    GIA = SelectedItem.GIA;

                }
            }
        }
        //Phòng
        private ObservableCollection<PHONG> _ListPhong;
        public ObservableCollection<PHONG> ListPhong { get { return _ListPhong; } set { _ListPhong = value; OnPropertyChanged(); } }
        private string _MALOAI;
        public string MALOAI { get { return _MALOAI; } set { _MALOAI = value; OnPropertyChanged(); } }
        private string _MALOAI1;
        public string MALOAI1 { get { return _MALOAI1; } set { _MALOAI1 = value; OnPropertyChanged(); } }
        private string _SOPHONG;
        public string SOPHONG { get { return _SOPHONG; } set { _SOPHONG = value; OnPropertyChanged(); } }
        private string _SOPHONG1;
        public string SOPHONG1 { get { return _SOPHONG1; } set { _SOPHONG1 = value; OnPropertyChanged(); } }
        private int? _TANG;
        public int? TANG { get { return _TANG; } set { _TANG = value; OnPropertyChanged(); } }
        private string _TINHTRANG;
        public string TINHTRANG { get { return _TINHTRANG; } set { _TINHTRANG = value; OnPropertyChanged(); } }
        private PHONG _SelectedItem1;
        public PHONG SelectedItem1
        {
            get
            {
                return _SelectedItem1;
            }
            set
            {
                _SelectedItem1 = value;
                OnPropertyChanged();
                if (SelectedItem1 != null)
                {
                    MALOAI = SelectedItem1.MALOAI;
                    SOPHONG = SelectedItem1.SOPHONG;
                    TANG = SelectedItem1.TANG;
                    TINHTRANG = SelectedItem1.TINHTRANG;
                    MAPDP = SelectedItem1.MAPDP;
                }
            }
        }
        //Hoá đơn
        private ObservableCollection<HOADON> _HoaDon;
        public ObservableCollection<HOADON> HoaDon { get { return _HoaDon; } set { _HoaDon = value; OnPropertyChanged(); } }
        private string _MAHD;
        public string MAHD { get { return _MAHD; } set { _MAHD = value; OnPropertyChanged(); } }
        private DateTime? _NGLAPHD;
        public DateTime? NGLAPHD { get { return _NGLAPHD; } set { _NGLAPHD = value; OnPropertyChanged(); } }
        private decimal? _THANHTIEN;
        public decimal? THANHTIEN { get { return _THANHTIEN; } set { _THANHTIEN = value; OnPropertyChanged(); } }
        //Phiếu dịch vụ
        private ObservableCollection<PHIEUDICHVU> _ListPDV;
        public ObservableCollection<PHIEUDICHVU> ListPDV { get { return _ListPDV; } set { _ListPDV = value; OnPropertyChanged(); } }

        public ICommand DatDichVuCommand { get; set; }
        public ICommand InHoaDonCommand { get; set; }
        public ICommand ThanhToanCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public PhongViewModel()
        {
            LoaiPhong = new ObservableCollection<LOAIPHONG>(DataProvider.Ins.DB.LOAIPHONGs);
            ListNumber = new List<int?>();
            ListPhong = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs);
            TenDV = new List<string>();
            ListDV = new ObservableCollection<DICHVU>(DataProvider.Ins.DB.DICHVUs);
            ListPDP = new ObservableCollection<PHIEUDATPHONG>(DataProvider.Ins.DB.PHIEUDATPHONGs);
            ListPDV = new ObservableCollection<PHIEUDICHVU>(DataProvider.Ins.DB.PHIEUDICHVUs);
            SoPhong = new List<string>();
            foreach (var dv in ListDV)
                TenDV.Add(dv.TENDV);
            for (int i = 1; i <= 30; i++)
                ListNumber.Add(i);
            DatDichVuCommand = new RelayCommand<object>((p) => 
            {
                return true; 
            }, (p) =>
            {
                try
                {
                    ListPhong = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs);
                    SoPhong = new List<string>();
                    foreach (var phong in ListPhong)
                    {
                        if (phong.TINHTRANG == "Đang được sử dụng")
                            SoPhong.Add(phong.SOPHONG);
                    }
                    DatDichVuWindow wd = new DatDichVuWindow();
                    var addVM = wd.DataContext as PhieuDatDichVuViewModel;
                    addVM.TTENDV = TenDV;
                    addVM.SSOPHONG = SoPhong;
                    addVM.LISTNUMBER = ListNumber;
                    wd.ShowDialog();
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
            }
            );
            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;
                return true;
            }, (p) =>
            {
                try
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
            CancelCommand = new RelayCommand<object>((p) =>
            {
                if (LOAIGIUONG == null && SLGIUONG == null && NGUOITOIDA == null && GIA == null && DIENTICH == null && SelectedItem == null && SelectedItem1 == null)
                    return false;
                return true;
            }, (p) =>
            {
                try
                {
                    MALOAI = LOAIGIUONG = string.Empty;
                    SLGIUONG = NGUOITOIDA = null;
                    GIA = null;
                    DIENTICH = null;
                    SelectedItem = null;
                    SelectedItem1 = null;
                }                
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
            ThanhToanCommand = new RelayCommand<object>((p) => 
            {
                if (SelectedItem1 == null)
                    return false;
                if (SelectedItem1.TINHTRANG != "Đang được sử dụng")
                    return false;
                return true; 
            }, (p) =>
            {
                try
                {
                    HoaDon = new ObservableCollection<HOADON>(DataProvider.Ins.DB.HOADONs);
                    var wd = new Bill();
                    var addVM = wd.DataContext as BillViewModel;
                    addVM.SOPHONG1 = SelectedItem1.SOPHONG;
                    addVM.MALOAI1 = SelectedItem1.MALOAI;
                    addVM.MAPDP1 = SelectedItem1.MAPDP;
                    addVM.Init();
                    wd.ShowDialog();
                    var phong = DataProvider.Ins.DB.PHONGs.Where(x => x.SOPHONG == SelectedItem1.SOPHONG).SingleOrDefault();
                    var pdp = DataProvider.Ins.DB.PHIEUDATPHONGs.Where(x => x.MAPDP == SelectedItem1.MAPDP).SingleOrDefault();
                    pdp.NGTRA = DateTime.Now;
                    phong.TINHTRANG = "Trống";
                    phong.MAPDP = null;
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show($"Thanh toán phòng {SelectedItem1.SOPHONG} thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
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
            }
            );
        }
    }
}
