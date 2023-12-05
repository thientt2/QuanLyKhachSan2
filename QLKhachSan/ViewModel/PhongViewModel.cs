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

        public PhongViewModel()
        {
            ListPhong = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs);
        }
    }
}
