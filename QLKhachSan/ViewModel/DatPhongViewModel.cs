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


        public DatPhongViewModel()
        {
            PDP1 = new ObservableCollection<PDP1>();
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
            foreach (var pdp in ListPDP)
            {
                PDP1.Add(new PDP1 { MAPDP = pdp.MAPDP, MAKH = pdp.MAKH, MANV = pdp.MANV, NGDAT = pdp.NGDAT, NGNHAN = pdp.NGNHAN, NGTRA = pdp.NGTRA, TRANGTHAI = "Đợi nhận phòng", MAPDV = null });
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
            foreach (var pdp1 in PDP1)
            {
                if (pdp1.NGNHAN < DateTime.Now)
                    pdp1.TRANGTHAI = "Quá hạn nhận phòng";
                if (pdp1.NGTRA != null)
                {
                    pdp1.TRANGTHAI = "Không còn sử dụng";
                }    
            }

            //có ngày trả => Không còn sử dụng
            DatPhongCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                DatPhongWindow wd = new DatPhongWindow();
                var addVM = wd.DataContext as PhieuDatPhongViewModel;
                addVM.TTENKH = TenKH;
                addVM.MMALOAI = MaLoai;
                wd.ShowDialog();
                ListPDP = new ObservableCollection<PHIEUDATPHONG>(DataProvider.Ins.DB.PHIEUDATPHONGs);
            }
            );
            NhanPhongCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
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
            }
            );
            EditCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                //var dichvu = DataProvider.Ins.DB.DICHVUs.Where(x => x.MADV == SelectedItem.MADV).SingleOrDefault();
                //dichvu.TENDV = TENDV;
                //dichvu.DONGIA = DONGIA;
                //DataProvider.Ins.DB.SaveChanges();

                //SelectedItem.MADV = MADV;
                MessageBox.Show("Sửa thông tin thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            });
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                return SelectedItem != null;
            }, (p) =>
            {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.OK)
                {


                    //if (count == 2)
                    //{
                    //    var ctpdv3 = DataProvider.Ins.DB.CTPDVs.Where(x => x.MADV == SelectedItem.MADV && x.MAPDV == SelectedItem.MAPDV).SingleOrDefault();
                    //    ctpdv3.MAPDV = SelectedItem.MAPDV;
                    //    ctpdv3.MADV = SelectedItem.MADV;
                    //    ctpdv3.SLDV -= SelectedItem.SLDV;
                    //    ctpdv3.GIA -= SelectedItem.GIA;
                    //    DataProvider.Ins.DB.SaveChanges();
                    //}
                    //else
                    //{
                    //    var ctpdv4 = DataProvider.Ins.DB.CTPDVs.Where(x => x.MADV == SelectedItem.MADV && x.MAPDV == SelectedItem.MAPDV).SingleOrDefault();
                    //    DataProvider.Ins.DB.CTPDVs.Remove(ctpdv4);
                    //    DataProvider.Ins.DB.SaveChanges();
                    //}
                    //ListCTPDV = new ObservableCollection<CTPDV>(DataProvider.Ins.DB.CTPDVs);
                    //ListCTPDV1.Remove(SelectedItem);
                    //foreach (var ctpdv in ListCTPDV1)
                    //{
                    //    tongtien += ctpdv.GIA;
                    //    if (ctpdv.MADV == MADV)
                    //        count++;
                    //}
                    //foreach (var pdv in ListPDV)
                    //{
                    //    if (pdv.MAPDV == MAPDV)
                    //    {
                    //        pdv.TONGTIEN = tongtien;
                    //        DataProvider.Ins.DB.SaveChanges();
                    //    }
                    //}
                    //tongtien = 0;
                    //count = 0;
                    MessageBox.Show("Xóa phiếu đặt phòng thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            });
        }
    }
}
