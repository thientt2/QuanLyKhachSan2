using QLKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QLKhachSan.ViewModel
{
    public class DatPhongViewModel : BasicViewModel
    {
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
            DatPhongCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                DatPhongWindow wd = new DatPhongWindow();
                wd.ShowDialog();
            }
            );
        }
    }
}
