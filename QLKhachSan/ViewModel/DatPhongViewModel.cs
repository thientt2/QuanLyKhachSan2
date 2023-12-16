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
        //Khách hàng
        private List<string> _TTENKH;
        public List<string> TTENKH { get { return _TTENKH; } set { _TTENKH = value; OnPropertyChanged(); } }
        private List<string> _TenKH;
        public List<string> TenKH { get { return _TenKH; } set { _TenKH = value; OnPropertyChanged(); } }
        private ObservableCollection<KHACHHANG> _ListKH;
        public ObservableCollection<KHACHHANG> ListKH { get { return _ListKH; } set { _ListKH = value; OnPropertyChanged(); } }
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
        //
        private KHACHHANG _SelectedItemKH;
        public KHACHHANG SelectedItemKH { get { return _SelectedItemKH; } set { _SelectedItemKH = value; OnPropertyChanged(); } }

        private ObservableCollection<PHIEUDATPHONG> _ListPDP;
        public ObservableCollection<PHIEUDATPHONG> ListPDP { get { return _ListPDP; } set { _ListPDP = value; OnPropertyChanged(); } }
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
