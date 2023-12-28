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

    public class DoanhThuViewModel : BasicViewModel
    {
        private List<int> _LNam;
        public List<int> LNam { get { return _LNam; } set { _LNam = value; OnPropertyChanged(); } }
        private List<double> _LDoanhThu;
        public List<double> LDoanhThu { get { return _LDoanhThu; } set { _LDoanhThu = value; OnPropertyChanged(); } }
        private int _Nam;
        public int Nam { get { return _Nam; } set { _Nam = value; OnPropertyChanged(); } }
        private List<int> _LThang;
        public List<int> LThang { get { return _LThang; } set { _LThang = value; OnPropertyChanged(); } }
        private int _Thang;
        public int Thang { get { return _Thang; } set { _Thang = value; OnPropertyChanged(); } }
        private ObservableCollection<HOADON> _ListHD;
        public ObservableCollection<HOADON> ListHD { get { return _ListHD; } set { _ListHD = value; OnPropertyChanged(); } }
        private ObservableCollection<PHIEUDATPHONG> _ListPDP;
        public ObservableCollection<PHIEUDATPHONG> ListPDP { get { return _ListPDP; } set { _ListPDP = value; OnPropertyChanged(); } }
        private ObservableCollection<PHONG> _ListPhong;
        public ObservableCollection<PHONG> ListPhong { get { return _ListPhong; } set { _ListPhong = value; OnPropertyChanged(); } }
        public ICommand ShowCommand1 { get; set; }
        public ICommand ShowCommand2 { get; set; }
        private int year;



        public DoanhThuViewModel()
        {
            ListHD = new ObservableCollection<HOADON>(DataProvider.Ins.DB.HOADONs);
            ListPDP = new ObservableCollection<PHIEUDATPHONG>(DataProvider.Ins.DB.PHIEUDATPHONGs);
            ListPhong = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs);
            LNam = new List<int>();

            foreach (var hd in ListHD)
            {
                int nam = hd.NGLAPHD.Value.Year;
                if (!LNam.Contains(nam))
                {
                    LNam.Add(nam);
                }
            }
            LNam.Sort();
            ShowCommand1 = new RelayCommand<ComboBox>((p) => { return true; }, (p) =>
            {
                if (p != null && p.SelectedItem != null)
                {
                    LThang = new List<int>();
                    int selectedNam = (int)p.SelectedItem;
                    year = selectedNam;
                    foreach (var hd in ListHD)
                    {
                        if (hd.NGLAPHD.Value.Year == selectedNam)
                        {
                            int thang = hd.NGLAPHD.Value.Month;
                            if (!LThang.Contains(thang))
                            {
                                LThang.Add(thang);
                            }
                        }
                    }
                    //LThang.Sort();
                }
            });
            ShowCommand2 = new RelayCommand<ComboBox>((p) => { return true; }, (p) =>
            {
                if (p != null && p.SelectedItem != null) 
                {
                    string[] maloai = { "Standard", "Deluxe", "Premium", "La Opera" };
                    int selectedThang = (int)p.SelectedItem;

                    for (int i = 0; i < maloai.Length; i++)
                    {
                        double sum = 0;
                        foreach (var hd in ListHD)
                        {
                            if (hd.NGLAPHD.Value.Year == year && hd.NGLAPHD.Value.Month == selectedThang)
                            {
                                foreach (var phong in ListPhong)
                                {
                                    if (hd.MAPDP == phong.MAPDP && phong.MALOAI == maloai[i]) 
                                    {
                                        sum += (double)hd.THANHTIEN;
                                    }
                                }

                            }
                        }
                        LDoanhThu.Add(sum);
                    }
                }
                MessageBox.Show(LDoanhThu.Count.ToString());
            });



        }

    }
}