using QLKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;

namespace QLKhachSan.ViewModel
{
    public class PhongViewModel : BasicViewModel
    {
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
        //
        private ObservableCollection<PHONG> _ListPhong;
        public ObservableCollection<PHONG> ListPhong { get { return _ListPhong; } set { _ListPhong = value; OnPropertyChanged(); } }
        private PHONG _SelectedItem;
        public PHONG SelectedItem
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
                    SOPHONG = SelectedItem.SOPHONG;
                    MALOAI = SelectedItem.MALOAI;
                    TANG = SelectedItem.TANG;
                    TINHTRANG = SelectedItem.TINHTRANG;

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

        public PhongViewModel()
        {
            ListPhong = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs);
            TenDV = new List<string>();
            SoPhong = new List<string>();
            ListDV = new ObservableCollection<DICHVU>(DataProvider.Ins.DB.DICHVUs);
            foreach (var dv in ListDV)
                TenDV.Add(dv.TENDV);
            foreach (var p in ListPhong)
                SoPhong.Add(p.SOPHONG);
            DatDichVuCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                DatDichVuWindow wd = new DatDichVuWindow();
                var addVM = wd.DataContext as PhieuDatDichVuViewModel;
                addVM.TTENDV = TenDV;
                addVM.SSOPHONG = SoPhong;
                wd.ShowDialog();
            }
            );
        }
    }
}
