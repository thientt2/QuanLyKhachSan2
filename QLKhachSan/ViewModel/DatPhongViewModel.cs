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
    public class PDP1 : BasicViewModel
    {
        private string _MAPDP;
        public string MAPDP { get { return _MAPDP; } set { _MAPDP = value; OnPropertyChanged(); } }
        private string _MAKH;
        public string MAKH { get { return _MAKH; } set { _MAKH = value; OnPropertyChanged(); } }
        private string _MANV;
        public string MANV { get { return _MANV; } set { _MANV = value; OnPropertyChanged(); } }
        private DateTime? _NGDAT;
        public DateTime? NGDAT { get { return _NGDAT; } set { _NGDAT = value; OnPropertyChanged(); } }
        private DateTime? _NGNHAN;
        public DateTime? NGNHAN { get { return _NGNHAN; } set { _NGNHAN = value; OnPropertyChanged(); } }
        private DateTime? _NGTRA;
        public DateTime? NGTRA { get { return _NGTRA; } set { _NGTRA = value; OnPropertyChanged(); } }
        private string _TRANGTHAI;
        public string TRANGTHAI { get { return _TRANGTHAI; } set { _TRANGTHAI = value; OnPropertyChanged(); } }
        private string _MAPDV;
        public string MAPDV { get { return _MAPDV; } set { _MAPDV = value; OnPropertyChanged(); } }
    }

    public class DatPhongViewModel : BasicViewModel
    {
        private ObservableCollection<PDP1> _PDP1;
        public ObservableCollection<PDP1> PDP1 { get { return _PDP1; } set { _PDP1 = value; OnPropertyChanged(); } }
        //Khách hàng
        private List<string> _TTENKH;
        public List<string> TTENKH { get { return _TTENKH; } set { _TTENKH = value; OnPropertyChanged(); } }
        private List<string> _TenKH;
        public List<string> TenKH { get { return _TenKH; } set { _TenKH = value; OnPropertyChanged(); } }
        private ObservableCollection<KHACHHANG> _ListKH;
        public ObservableCollection<KHACHHANG> ListKH { get { return _ListKH; } set { _ListKH = value; OnPropertyChanged(); } }
        private KHACHHANG _SelectedItemKH;
        public KHACHHANG SelectedItemKH { get { return _SelectedItemKH; } set { _SelectedItemKH = value; OnPropertyChanged(); } }
        //Phòng
        private List<string> _MMALOAI;
        public List<string> MMALOAI { get { return _MMALOAI; } set { _MMALOAI = value; OnPropertyChanged(); } }
        private List<string> _MaLoai;
        public List<string> MaLoai { get { return _MaLoai; } set { _MaLoai = value; OnPropertyChanged(); } }
        private List<string> _SSOPHONG;
        public List<string> SSOPHONG { get { return _SSOPHONG; } set { _SSOPHONG = value; OnPropertyChanged(); } }
        private List<string> _SoPhong;
        public List<string> SoPhong { get { return _SoPhong; } set { _SoPhong = value; OnPropertyChanged(); } }
        private ObservableCollection<PHONG> _ListPhong;
        public ObservableCollection<PHONG> ListPhong { get { return _ListPhong; } set { _ListPhong = value; OnPropertyChanged(); } }
        private string _MALOAI;
        public string MALOAI { get { return _MALOAI; } set { _MALOAI = value; OnPropertyChanged(); } }
        private string _SOPHONG;
        public string SOPHONG { get { return _SOPHONG; } set { _SOPHONG = value; OnPropertyChanged(); } }
        private int? _TANG;
        public int? TANG { get { return _TANG; } set { _TANG = value; OnPropertyChanged(); } }
        private string _TINHTRANG;
        public string TINHTRANG { get { return _TINHTRANG; } set { _TINHTRANG = value; OnPropertyChanged(); } }

        private ObservableCollection<PDP1> _originalPDP1;
        public ObservableCollection<PDP1> OriginalPDP1 { get { return _originalPDP1; } set { _originalPDP1 = value; OnPropertyChanged(); } }

        //Phiếu dịch vụ
        private ObservableCollection<PHIEUDICHVU> _ListPDV;
        public ObservableCollection<PHIEUDICHVU> ListPDV { get { return _ListPDV; } set { _ListPDV = value; OnPropertyChanged(); } }
        private string _MAPDV;
        public string MAPDV { get { return _MAPDV; } set { _MAPDV = value; OnPropertyChanged(); } }
        private string _MADV;
        public string MADV { get { return _MADV; } set { _MADV = value; OnPropertyChanged(); } }
        private decimal? _TONGTIEN;
        public decimal? TONGTIEN { get { return _TONGTIEN; } set { _TONGTIEN = value; OnPropertyChanged(); } }

        //Chi tiết phiếu dịch vụ
        private ObservableCollection<CHITIETDICHVU> _ListCTPDV;
        public ObservableCollection<CHITIETDICHVU> ListCTPDV { get { return _ListCTPDV; } set { _ListCTPDV = value; OnPropertyChanged(); } }
        private int? _SLDV;
        public int? SLDV { get { return _SLDV; } set { _SLDV = value; OnPropertyChanged(); } }
        private decimal? _GIA;
        public decimal? GIA { get { return _GIA; } set { _GIA = value; OnPropertyChanged(); } }

        private string _TRANGTHAI;
        public string TRANGTHAI { get { return _TRANGTHAI; } set { _TRANGTHAI = value; OnPropertyChanged(); } }

        //private string _MAPDP1;
        //public string MAPDP1 { get { return _MAPDP1; } set { _MAPDP1 = value; OnPropertyChanged(); } }
        //private string _TENKH1;
        //public string TENKH1 { get { return _TENKH1; } set { _TENKH1 = value; OnPropertyChanged(); } }
        //private string _MANV1;
        //public string MANV1 { get { return _MANV1; } set { _MANV1 = value; OnPropertyChanged(); } }
        //private DateTime? _NGDAT1;
        //public DateTime? NGDAT1 { get { return _NGDAT1; } set { _NGDAT1 = value; OnPropertyChanged(); } }
        //private DateTime? _NGNHAN1;
        //public DateTime? NGNHAN1 { get { return _NGNHAN1; } set { _NGNHAN1 = value; OnPropertyChanged(); } }
        //private DateTime? _NGTRA1;
        //public DateTime? NGTRA1 { get { return _NGTRA1; } set { _NGTRA1 = value; OnPropertyChanged(); } }
        //private string _MALOAI1;
        //public string MALOAI1 { get { return _MALOAI1; } set { _MALOAI1 = value; OnPropertyChanged(); } }
        //private string _SOPHONG1;
        //public string SOPHONG1 { get { return _SOPHONG1; } set { _SOPHONG1 = value; OnPropertyChanged(); } }

        private PDP1 _SelectedItem;
        public PDP1 SelectedItem
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
                    MAPDP = SelectedItem.MAPDP;
                    MAKH = SelectedItem.MAKH;
                    MANV = SelectedItem.MANV;
                    NGDAT = SelectedItem.NGDAT;
                    NGNHAN = SelectedItem.NGNHAN;
                    TRANGTHAI = SelectedItem.TRANGTHAI;
                    MAPDV = SelectedItem.MAPDV;
                    NGTRA = SelectedItem.NGTRA;
                }
            }
        }
        //Phiếu đặt phòng
        private ObservableCollection<PHIEUDATPHONG> _ListPDP;
        public ObservableCollection<PHIEUDATPHONG> ListPDP { get { return _ListPDP; } set { _ListPDP = value; OnPropertyChanged(); } }
        private string _MAPDP;
        public string MAPDP { get { return _MAPDP; } set { _MAPDP = value; OnPropertyChanged(); } }
        private string _MAKH;
        public string MAKH { get { return _MAKH; } set { _MAKH = value; OnPropertyChanged(); } }
        private string _MANV;
        public string MANV { get { return _MANV; } set { _MANV = value; OnPropertyChanged(); } }
        private DateTime? _NGDAT;
        public DateTime? NGDAT { get { return _NGDAT; } set { _NGDAT = value; OnPropertyChanged(); } }
        private DateTime? _NGNHAN;
        public DateTime? NGNHAN { get { return _NGNHAN; } set { _NGNHAN = value; OnPropertyChanged(); } }
        private DateTime? _NGTRA;
        public DateTime? NGTRA { get { return _NGTRA; } set { _NGTRA = value; OnPropertyChanged(); } }


        public ICommand DatPhongCommand { get; set; }
        public ICommand NhanPhongCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SortAllCommand { get; set; }
        public ICommand SortCheckInCommand { get; set; }
        public ICommand SortBookedCommand { get; set; }
        public ICommand SortOutOfDateCommand { get; set; }
        public ICommand SortOutOfOrderCommand { get; set; }


        public DatPhongViewModel()
        {
            PDP1 = new ObservableCollection<PDP1>();
            OriginalPDP1 = new ObservableCollection<PDP1>();
            ListPDV = new ObservableCollection<PHIEUDICHVU>(DataProvider.Ins.DB.PHIEUDICHVUs);
            ListPDP = new ObservableCollection<PHIEUDATPHONG>(DataProvider.Ins.DB.PHIEUDATPHONGs);
            //Khách hàng
            ListKH = new ObservableCollection<KHACHHANG>(DataProvider.Ins.DB.KHACHHANGs);
            TenKH = new List<string>();
            foreach (var kh in ListKH)
                TenKH.Add(kh.TENKH);
            //Phòng
            ListPhong = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs);
            MaLoai = new List<string>();
            MaLoai.Add("Standard");
            MaLoai.Add("Premium");
            MaLoai.Add("Deluxe");
            MaLoai.Add("La Opera");
            //Màn hình chính
            CapNhat();
            //có ngày trả => Không còn sử dụng
            DatPhongCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                DatPhongWindow wd = new DatPhongWindow();
                var addVM = wd.DataContext as PhieuDatPhongViewModel;
                addVM.MMALOAI = MaLoai;
                wd.ShowDialog();
                DataProvider.Ins.DB.SaveChanges();
                CapNhat();
            }
            );
            NhanPhongCommand = new RelayCommand<object>((p) => 
            {
                if (SelectedItem == null || SelectedItem.TRANGTHAI != "Đợi nhận phòng")
                    return false;
                return true; 
            }, (p) =>
            {
                foreach (var pdp1 in PDP1)
                {
                    if (pdp1.MAPDP == SelectedItem.MAPDP)
                    {
                        if (SelectedItem.TRANGTHAI == "Đợi nhận phòng")
                            pdp1.TRANGTHAI = "Đã nhận phòng";
                    }
                }

                var phong = DataProvider.Ins.DB.PHONGs.Where(x => x.MAPDP == SelectedItem.MAPDP).SingleOrDefault();
                phong.TINHTRANG = "Đang được sử dụng";
                DataProvider.Ins.DB.SaveChanges();
                CapNhat();
            }
            );
            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null || SelectedItem.TRANGTHAI != "Đã nhận phòng")
                    return false;
                return true;
            }, (p) =>
            {
                var pdp = DataProvider.Ins.DB.PHIEUDATPHONGs.Where(x => x.MAPDP == SelectedItem.MAPDP).SingleOrDefault();
                pdp.NGTRA = NGTRA;
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Gia hạn trả phòng thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                NGTRA = null;
                CapNhat();
            });
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null || SelectedItem.TRANGTHAI != "Quá hạn nhận phòng" || SelectedItem.TRANGTHAI != "Không còn sử dụng")
                    return false;
                return true;
            }, (p) =>
            {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.OK)
                {
                    var pdp = DataProvider.Ins.DB.PHIEUDATPHONGs.Where(x => x.MAPDP == SelectedItem.MAPDP).SingleOrDefault();
                    DataProvider.Ins.DB.PHIEUDATPHONGs.Remove(pdp);
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Xóa phiếu đặt phòng thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                CapNhat();
            });
            SortAllCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                PDP1.Clear();
                foreach (var item in OriginalPDP1)
                {
                    PDP1.Add(item);
                }

            });
            SortCheckInCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                PDP1.Clear();
                foreach (var item in OriginalPDP1.Where(item => item.TRANGTHAI == "Đã nhận phòng"))
                {
                    PDP1.Add(item);
                }
            });

            SortBookedCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                PDP1.Clear();
                foreach (var item in OriginalPDP1.Where(item => item.TRANGTHAI == "Đợi nhận phòng"))
                {
                    PDP1.Add(item);
                }
            });

            SortOutOfDateCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                PDP1.Clear();
                foreach (var item in OriginalPDP1.Where(item => item.TRANGTHAI == "Quá hạn nhận phòng"))
                {
                    PDP1.Add(item);
                }
            });

            SortOutOfOrderCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                PDP1.Clear();
                foreach (var item in OriginalPDP1.Where(item => item.TRANGTHAI == "Không còn sử dụng"))
                {
                    PDP1.Add(item);
                }
            });
        }
        public void CapNhat()
        {
            PDP1 = new ObservableCollection<PDP1>();
            OriginalPDP1 = new ObservableCollection<PDP1>();
            ListPDP = new ObservableCollection<PHIEUDATPHONG>(DataProvider.Ins.DB.PHIEUDATPHONGs);
            ListPDV = new ObservableCollection<PHIEUDICHVU>(DataProvider.Ins.DB.PHIEUDICHVUs);
            foreach (var pdp in ListPDP)
            {
                PDP1.Add(new PDP1 { MAPDP = pdp.MAPDP, MAKH = pdp.MAKH, MANV = pdp.MANV, NGDAT = pdp.NGDAT, NGNHAN = pdp.NGNHAN, NGTRA = pdp.NGTRA, TRANGTHAI = "Đợi nhận phòng", MAPDV = null });
                OriginalPDP1.Add(new PDP1 { MAPDP = pdp.MAPDP, MAKH = pdp.MAKH, MANV = pdp.MANV, NGDAT = pdp.NGDAT, NGNHAN = pdp.NGNHAN, NGTRA = pdp.NGTRA, TRANGTHAI = "Đợi nhận phòng", MAPDV = null });
            }
            foreach (var pdp1 in PDP1)
            {
                foreach (var pdv in ListPDV)
                {
                    if (pdv.MAPDP == pdp1.MAPDP)
                    {
                        pdp1.MAPDV = pdv.MAPDV;
                        break;
                    }
                }
            }
            foreach (var pdp1 in OriginalPDP1)
            {
                foreach (var pdv in ListPDV)
                {
                    if (pdv.MAPDP == pdp1.MAPDP)
                    {
                        pdp1.MAPDV = pdv.MAPDV;
                        break;
                    }
                }
            }
            foreach (var pdp1 in OriginalPDP1)
            {
                if (pdp1.NGNHAN < DateTime.Now && pdp1.TRANGTHAI == "Đợi nhận phòng")
                {
                    pdp1.TRANGTHAI = "Quá hạn nhận phòng";
                    if(pdp1.NGTRA < DateTime.Now)
                        pdp1.TRANGTHAI = "Không còn sử dụng";
                }    

                var phong = DataProvider.Ins.DB.PHONGs.Where(x => x.MAPDP == pdp1.MAPDP).SingleOrDefault();
                if (phong != null)
                {
                    if (phong.TINHTRANG == "Đang được sử dụng")
                    {
                        pdp1.TRANGTHAI = "Đã nhận phòng";
                    }
                }    
            }

            foreach (var pdp1 in PDP1)
            {
                if (pdp1.NGNHAN < DateTime.Now && pdp1.TRANGTHAI == "Đợi nhận phòng")
                {
                    pdp1.TRANGTHAI = "Quá hạn nhận phòng";
                    if (pdp1.NGTRA < DateTime.Now)
                        pdp1.TRANGTHAI = "Không còn sử dụng";
                }

                var phong = DataProvider.Ins.DB.PHONGs.Where(x => x.MAPDP == pdp1.MAPDP).SingleOrDefault();
                if (phong != null)
                {
                    if (phong.TINHTRANG == "Đang được sử dụng")
                    {
                        pdp1.TRANGTHAI = "Đã nhận phòng";
                    }
                }
            }
        }
    }
}
