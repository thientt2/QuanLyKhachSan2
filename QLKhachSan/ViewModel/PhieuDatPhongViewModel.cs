using QLKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QLKhachSan.ViewModel
{
    public class PhieuDatPhongViewModel : BasicViewModel
    {
        private ObservableCollection<KHACHHANG> _ListKH;
        public ObservableCollection<KHACHHANG> ListKH { get { return _ListKH; } set { _ListKH = value; OnPropertyChanged(); } }

        private List<string> _TTENKH;
        public List<string> TTENKH { get { return _TTENKH; } set { _TTENKH = value; OnPropertyChanged(); } }
        private string _TENKH;
        public string TENKH { get { return _TENKH; } set { _TENKH = value; OnPropertyChanged(); } }
        private string _GIOITINH;
        public string GIOITINH { get { return _GIOITINH; } set { _GIOITINH = value; OnPropertyChanged(); } }
        private string _DIACHI;
        public string DIACHI { get { return _DIACHI; } set { _DIACHI = value; OnPropertyChanged(); } }
        private string _SDT;
        public string SDT { get { return _SDT; } set { _SDT = value; OnPropertyChanged(); } }

        private string _EMAIL;
        public string EMAIL { get { return _EMAIL; } set { _EMAIL = value; OnPropertyChanged(); } }

        private string _SOCCCD;
        public string SOCCCD { get { return _SOCCCD; } set { _SOCCCD = value; OnPropertyChanged(); } }

        private string _QUOCTICH;
        public string QUOCTICH { get { return _QUOCTICH; } set { _QUOCTICH = value; OnPropertyChanged(); } }

        private DateTime? _NGSINH;
        public DateTime? NGSINH { get { return _NGSINH; } set { _NGSINH = value; OnPropertyChanged(); } }
        public ICommand AddCommand { get; set; }

        public ICommand ShowCommand { get; set; }
        public ICommand CancelleCommand { get; set; }

        public PhieuDatPhongViewModel()
        {

            ListKH = new ObservableCollection<KHACHHANG>(DataProvider.Ins.DB.KHACHHANGs);
            ShowCommand = new RelayCommand<ComboBox>((p) => { return true; }, (p) => 
            { 
                foreach(var kh in ListKH)
                {
                    if(kh.TENKH == TENKH)
                    {
                        GIOITINH = kh.GIOITINH.ToString();
                        SOCCCD = kh.SOCCCD.ToString();
                        QUOCTICH = kh.QUOCTICH.ToString();
                        DIACHI = kh.DIACHI.ToString();
                        EMAIL = kh.EMAIL.ToString();
                        SDT = kh.SDT.ToString();
                        NGSINH = kh.NGSINH;
                    }    
                }    
            });
        }
    }
}
