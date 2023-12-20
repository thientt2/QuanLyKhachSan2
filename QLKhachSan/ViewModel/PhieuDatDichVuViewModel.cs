using QLKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        private List<string> _TTENDV;
        public List<string> TTENDV { get { return _TTENDV; } set { _TTENDV = value; OnPropertyChanged(); } }

        private string _MADV;
        public string MADV { get { return _MADV; } set { _MADV = value; OnPropertyChanged(); } }
        private string _TENDV;
        public string TENDV { get { return _TENDV; } set { _TENDV = value; OnPropertyChanged(); } }
        private decimal? _DONGIA;
        public decimal? DONGIA { get { return _DONGIA; } set { _DONGIA = value; OnPropertyChanged(); } }


        //Phòng
        private ObservableCollection<PHONG> _ListPhong;
        public ObservableCollection<PHONG> ListPhong { get { return _ListPhong; } set { _ListPhong = value; OnPropertyChanged(); } }

        private List<string> _SoPhong;
        public List<string> SoPhong { get { return _SoPhong; } set { _SoPhong = value; OnPropertyChanged(); } }

        private List<string> _SSOPHONG;
        public List<string> SSOPHONG { get { return _SSOPHONG; } set { _SSOPHONG = value; OnPropertyChanged(); } }

        private string _SOPHONG;
        public string SOPHONG { get { return _SOPHONG; } set { _SOPHONG = value; OnPropertyChanged(); } }

        //Chi tiết phiếu dịch vụ
        private ObservableCollection<CTPDV> _ListCTPDV;
        public ObservableCollection<CTPDV> ListCTPDV { get { return _ListCTPDV; } set { _ListCTPDV = value; OnPropertyChanged(); } }

        private int _SLDV;
        public int SLDV { get { return _SLDV; } set { _SLDV = value; OnPropertyChanged(); } }
        private decimal? _GIA;
        public decimal? GIA { get { return _GIA; } set { _GIA = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand ShowCommand { get; set; }
        public ICommand ShowCommand1 { get; set; }

        public PhieuDatDichVuViewModel()
        {
            ListDV = new ObservableCollection<DICHVU>(DataProvider.Ins.DB.DICHVUs);
            ListPhong = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs);
            SSOPHONG = new List<string>();

            ShowCommand = new RelayCommand<ComboBox>((p) => { return true; }, (p) =>
            {
                foreach (var dv in ListDV)
                {
                    if (dv.TENDV == TENDV)
                    {
                        MADV = dv.MADV.ToString();
                    }
                }
            });

            ShowCommand1 = new RelayCommand<ComboBox>((p) => { return true; }, (p) =>
            {
                SoPhong = new List<string>();

                foreach (var phong in ListPhong)
                {
                    if (phong.TINHTRANG == "Đang được sử dụng")
                    {
                        SoPhong.Add(phong.SOPHONG);
                    }
                }
                SSOPHONG = SoPhong;
            });


            ListCTPDV = new ObservableCollection<CTPDV>(DataProvider.Ins.DB.CTPDVs);

            //AddCommand = new RelayCommand<object>((p) =>
            //{
            //    return true;
            //}, (p) =>
            //{

            //    decimal? sum = 0;
            //    foreach (var dv in ListDV)
            //    {
            //        if (dv.MADV == MADV)
            //        {
            //            sum = DONGIA * SLDV; 
            //        }
            //    }
            //    var ctpdv = new CTPDV() { MAPDV = MAPDV, MADV = MADV, SLDV = SLDV, GIA = sum };
            //    DataProvider.Ins.DB.PHIEUDATPHONGs.Add(ctpdv);
            //    foreach (var phong in ListPhong)
            //    {
            //        if (phong.SOPHONG == SOPHONG && phong.TINHTRANG == "Trống")
            //        {
            //            phong.TINHTRANG = "Đang được sử dụng";
            //        }
            //    }
            //    DataProvider.Ins.DB.SaveChanges();
            //    ListPDP.Add(pdp);
            //    FrameworkElement window = p as FrameworkElement;
            //    var w = window as Window;
            //    if (w != null)
            //    {
            //        w.Close();
            //    }

            //    TENDV = MADV = "";
            //    SLDV = 1;
            //    SOPHONG = null;
            //});

        }
    }
}
