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
    public class DatPhongViewModel : BasicViewModel
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
            private string _TRANGTHAI;
            public string TRANGTHAI { get { return _TRANGTHAI; } set { _TRANGTHAI = value; OnPropertyChanged(); } }
            private string _MAPDV;
            public string MAPDV { get { return _MAPDV; } set { _MAPDV = value; OnPropertyChanged(); } }
            private DateTime? _NGLAP;
            public DateTime? NGLAP { get { return _NGLAP; } set { _NGLAP = value; OnPropertyChanged(); } }
            private decimal? _TONGTIEN;
            public decimal? TONGTIEN { get { return _TONGTIEN; } set { _TONGTIEN = value; OnPropertyChanged(); } }
        }
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

        //Phiếu dịch vụ
        private ObservableCollection<PHIEUDICHVU> _ListPDV;
        public ObservableCollection<PHIEUDICHVU> ListPDV { get { return _ListPDV; } set { _ListPDV = value; OnPropertyChanged(); } }
        private string _MAPDV;
        public string MAPDV { get { return _MAPDV; } set { _MAPDV = value; OnPropertyChanged(); } }
        private DateTime? _NGLAP;
        public DateTime? NGLAP { get { return _NGLAP; } set { _NGLAP = value; OnPropertyChanged(); } }
        private decimal? _TONGTIEN;
        public decimal? TONGTIEN { get { return _TONGTIEN; } set { _TONGTIEN = value; OnPropertyChanged(); } }
        //Chi tiết phiếu dịch vụ
        private ObservableCollection<CTPDV> _ListCTPDV;
        public ObservableCollection<CTPDV> ListCTPDV { get { return _ListCTPDV; } set { _ListCTPDV = value; OnPropertyChanged(); } }
        private int? _SLDV;
        public int? SLDV { get { return _SLDV; } set { _SLDV = value; OnPropertyChanged(); } }
        private decimal? _GIA;
        public decimal? GIA { get { return _GIA; } set { _GIA = value; OnPropertyChanged(); } }

        private PHIEUDATPHONG _SelectedItem;
        public PHIEUDATPHONG SelectedItem
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

        public ICommand DatPhongCommand { get; set; }

        public DatPhongViewModel()
        {
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

        }
    }
}
