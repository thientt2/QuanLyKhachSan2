using LiveCharts.Wpf;
using LiveCharts;
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
using LiveCharts.Wpf.Charts.Base;

namespace QLKhachSan.ViewModel
{

    public class DoanhThuViewModel : BasicViewModel
    {
        private List<int> _LNam;
        public List<int> LNam { get { return _LNam; } set { _LNam = value; OnPropertyChanged(); } }
        private int _Nam;
        public int Nam { get { return _Nam; } set { _Nam = value; OnPropertyChanged(); } }
        private List<int> _LThang;
        public List<int> LThang { get { return _LThang; } set { _LThang = value; OnPropertyChanged(); } }
        private int _Thang;
        public int Thang { get { return _Thang; } set { _Thang = value; OnPropertyChanged(); } }
        private int _SoLuotThue;
        public int SoLuotThue
        {
            get { return _SoLuotThue; }
            set
            {
                _SoLuotThue = value;
                OnPropertyChanged();
            }
        }
        private double _TongDoanhThu;
        public double TongDoanhThu
        {
            get { return _TongDoanhThu; }
            set
            {
                _TongDoanhThu = value;
                OnPropertyChanged();
            }
        }
        private double _doanhThuS;
        public double DoanhThuS
        {
            get { return _doanhThuS; }
            set
            {
                _doanhThuS = value;
                DoanhThuValues[0].Clear();
                DoanhThuValues[0].Add(value);
                OnPropertyChanged();
            }
        }

        private double _doanhThuD;
        public double DoanhThuD
        {
            get { return _doanhThuD; }
            set
            {
                _doanhThuD = value;
                DoanhThuValues[1].Clear();
                DoanhThuValues[1].Add(value);
                OnPropertyChanged();
            }
        }

        private double _doanhThuP;
        public double DoanhThuP
        {
            get { return _doanhThuP; }
            set
            {
                _doanhThuP = value;
                DoanhThuValues[2].Clear();
                DoanhThuValues[2].Add(value);
                OnPropertyChanged();
            }
        }

        private double _doanhThuLA;
        public double DoanhThuLA
        {
            get { return _doanhThuLA; }
            set
            {
                _doanhThuLA = value;
                DoanhThuValues[3].Clear();
                DoanhThuValues[3].Add(value);
                OnPropertyChanged();
            }
        }
        private double _doanhThuPhong;
        public double DoanhThuPhong
        {
            get { return _doanhThuPhong; }
            set
            {
                _doanhThuPhong = value;
                DoanhThuValues2[0].Clear();
                DoanhThuValues2[0].Add(value);
                OnPropertyChanged();
            }
        }
        private double _doanhThuDV;
        public double DoanhThuDV
        {
            get { return _doanhThuDV; }
            set
            {
                _doanhThuDV = value;
                DoanhThuValues2[1].Clear();
                DoanhThuValues2[1].Add(value);
                OnPropertyChanged();
            }
        }

        private ObservableCollection<HOADON> _ListHD;
        public ObservableCollection<HOADON> ListHD { get { return _ListHD; } set { _ListHD = value; OnPropertyChanged(); } }
        private ObservableCollection<PHIEUDATPHONG> _ListPDP;
        public ObservableCollection<PHIEUDATPHONG> ListPDP { get { return _ListPDP; } set { _ListPDP = value; OnPropertyChanged(); } }
        private ObservableCollection<PHIEUDICHVU> _ListPDV;
        public ObservableCollection<PHIEUDICHVU> ListPDV { get { return _ListPDV; } set { _ListPDV = value; OnPropertyChanged(); } }
        public ICommand ShowCommand1 { get; set; }
        public ICommand ShowCommand2 { get; set; }
        public ICommand Chart_DataClickCommand { get; set; }
        private string[] maloai = { "Standard", "Deluxe", "Premium", "La Opera" };

        private PieSeries _selectedSeries;
        public PieSeries SelectedSeries
        {
            get { return _selectedSeries; }
            set { _selectedSeries = value; OnPropertyChanged(); }
        }
        private List<ChartValues<double>> _doanhThuValues;
        public List<ChartValues<double>> DoanhThuValues
        {
            get { return _doanhThuValues; }
            set { _doanhThuValues = value; OnPropertyChanged(); }
        }
        private List<ChartValues<double>> _doanhThuValues2;
        public List<ChartValues<double>> DoanhThuValues2
        {
            get { return _doanhThuValues2; }
            set { _doanhThuValues2 = value; OnPropertyChanged(); }
        }
        public Func<ChartPoint, string> PointLabel { get; set; }
        public Func<ChartPoint, string> PointLabel2 { get; set; }
        public string[] MaLoai { get; set; }

        public DoanhThuViewModel()
        {
            ListHD = new ObservableCollection<HOADON>(DataProvider.Ins.DB.HOADONs);
            ListPDV = new ObservableCollection<PHIEUDICHVU>(DataProvider.Ins.DB.PHIEUDICHVUs);
            ListPDP = new ObservableCollection<PHIEUDATPHONG>(DataProvider.Ins.DB.PHIEUDATPHONGs);
            LNam = new List<int>();
            DoanhThuValues = new List<ChartValues<double>>

                    {
                        new ChartValues<double>(),
                        new ChartValues<double>(),
                        new ChartValues<double>(),
                        new ChartValues<double>()
                    };
            DoanhThuValues2 = new List<ChartValues<double>>
                    {
                        new ChartValues<double>(),
                        new ChartValues<double>()
                    };

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
                    foreach (var hd in ListHD)
                    {
                        if (hd.NGLAPHD.Value.Year == Nam)
                        {
                            int thang = hd.NGLAPHD.Value.Month;
                            if (!LThang.Contains(thang))
                            {
                                LThang.Add(thang);
                            }
                        }
                    }
                    LThang.Sort();
                    DoanhThuS = 0;
                    DoanhThuP = 0;
                    DoanhThuD = 0;
                    DoanhThuLA = 0;
                    DoanhThuPhong = 0;
                    DoanhThuDV = 0;
                    double sum1 = 0;
                    SoLuotThue = 0;
                    for (int i = 0; i < maloai.Length; i++)
                    {
                        double sum = 0;
                        foreach (var hd in ListHD)
                        {
                            if (hd.NGLAPHD.Value.Year == Nam && hd.LOAI == maloai[i])
                            {
                                sum += (double)hd.THANHTIEN;
                                SoLuotThue++;
                            }
                        }
                        sum1 += sum;
                        switch (maloai[i])
                        {
                            case "Standard":
                                DoanhThuS = sum;
                                break;
                            case "Deluxe":
                                DoanhThuD = sum;
                                break;
                            case "Premium":
                                DoanhThuP = sum;
                                break;
                            case "La Opera":
                                DoanhThuLA = sum;
                                break;
                        }
                    }
                    foreach (var pdv in ListPDV)
                    {
                        foreach (var pdp in ListPDP)
                        {
                            if (pdv.MAPDP == pdp.MAPDP && pdp.NGTRA.Value.Year == Nam)
                            {
                                DoanhThuDV += (double)pdv.TONGTIEN;
                            }
                        }
                    }
                    DoanhThuPhong = sum1 - DoanhThuDV;
                    TongDoanhThu = sum1;
                }
            });
            ShowCommand2 = new RelayCommand<ComboBox>((p) => { return true; }, (p) =>
            {
                if (p != null && p.SelectedItem != null)
                {
                    DoanhThuS = 0;
                    DoanhThuP = 0;
                    DoanhThuD = 0;
                    DoanhThuLA = 0;
                    DoanhThuPhong = 0;
                    DoanhThuDV = 0;
                    double sum1 = 0;
                    SoLuotThue = 0;
                    for (int i = 0; i < maloai.Length; i++)
                    {
                        double sum = 0;
                        foreach (var hd in ListHD)
                        {
                            if (hd.NGLAPHD.Value.Year == Nam && hd.NGLAPHD.Value.Month == Thang && hd.LOAI == maloai[i])
                            {
                                sum += (double)hd.THANHTIEN;
                                SoLuotThue++;
                            }
                        }
                        sum1 += sum;
                        switch (maloai[i])
                        {
                            case "Standard":
                                DoanhThuS = sum;
                                break;
                            case "Deluxe":
                                DoanhThuD = sum;
                                break;
                            case "Premium":
                                DoanhThuP = sum;
                                break;
                            case "La Opera":
                                DoanhThuLA = sum;
                                break;
                        }
                    }
                    foreach (var pdv in ListPDV)
                    {
                        foreach (var pdp in ListPDP)
                        {
                            if (pdv.MAPDP == pdp.MAPDP && pdp.NGTRA.Value.Year == Nam && pdp.NGTRA.Value.Month == Thang)
                            {
                                DoanhThuDV += (double)pdv.TONGTIEN;
                            }
                        }
                    }
                    DoanhThuPhong = sum1 - DoanhThuDV;
                    TongDoanhThu = sum1;

                }
            });

            PointLabel = chartPoint =>
            {
                string roomType = string.Empty;
                double doanhThu = 0;

                // Lấy thông tin từ DataPoint
                var series = (PieSeries)chartPoint.SeriesView;
                if (series.Title == "Standard")
                {
                    roomType = "Standard";
                    doanhThu = DoanhThuS;
                }
                else if (series.Title == "Deluxe")
                {
                    roomType = "Deluxe";
                    doanhThu = DoanhThuD;
                }
                else if (series.Title == "Premium")
                {
                    roomType = "Premium";
                    doanhThu = DoanhThuP;
                }
                else if (series.Title == "La Opera")
                {
                    roomType = "La Opera";
                    doanhThu = DoanhThuLA;
                }
                return string.Format("{0:P}", chartPoint.Participation);
            };
            PointLabel2 = chartPoint =>
            {
                string roomType = string.Empty;
                double giatri = 0;

                // Lấy thông tin từ DataPoint
                var series = (PieSeries)chartPoint.SeriesView;
                if (series.Title == "Doanh thu phòng")
                {
                    roomType = "Doanh thu phòng";
                    giatri = DoanhThuPhong;
                }
                else if (series.Title == "Doanh thu dịch vụ")
                {
                    roomType = "Doanh thu dịch vụ";
                    giatri = DoanhThuDV;
                }
                return string.Format("{0:P}", chartPoint.Participation);
            };

            Chart_DataClickCommand = new RelayCommand<ChartPoint>((p) => { return true; }, (p) =>
            {
                var chart = (LiveCharts.Wpf.PieChart)p.ChartView;

                //clear selected slice.
                foreach (PieSeries series in chart.Series)
                    series.PushOut = 0;

                var selectedSeries = (PieSeries)p.SeriesView;
                selectedSeries.PushOut = 8;
            });

        }
        
    }

}