using QLKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace QLKhachSan.ViewModel
{
    public class PhieuDatDichVuViewModel : BasicViewModel
    {
        //Dịch vụ
        private ObservableCollection<DICHVU> _ListDV;
        public ObservableCollection<DICHVU> ListDV { get { return _ListDV; } set { _ListDV = value; OnPropertyChanged(); } }

        private string _MADV;
        public string MADV { get { return _MADV; } set { _MADV = value; OnPropertyChanged(); } }
        private string _TENDV;
        public string TENDV { get { return _TENDV; } set { _TENDV = value; OnPropertyChanged(); } }

        private List<string> _TTENDV;
        public List<string> TTENDV { get { return _TTENDV; } set { _TTENDV = value; OnPropertyChanged(); } }

        //Phòng
        private ObservableCollection<PHONG> _ListPhong;
        public ObservableCollection<PHONG> ListPhong { get { return _ListPhong; } set { _ListPhong = value; OnPropertyChanged(); } }

        private List<string> _SSOPHONG;
        public List<string> SSOPHONG { get { return _SSOPHONG; } set { _SSOPHONG = value; OnPropertyChanged(); } }
        //
        public ICommand ShowCommand { get; set; }
        public PhieuDatDichVuViewModel()
        {

            ListDV = new ObservableCollection<DICHVU>(DataProvider.Ins.DB.DICHVUs);
            ListPhong = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs);
            ShowCommand = new RelayCommand<ComboBox>((p) => { return true; }, (p) =>
            {
                foreach (var kh in ListDV)
                {
                    if (kh.TENDV == TENDV)
                    {
                        MADV = kh.MADV.ToString();
                    }
                }
            });
        }
    }
}
