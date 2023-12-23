using QLKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QLKhachSan.ViewModel
{
    public class CTPDV1 : BasicViewModel
    {
        private string _MAPDV;
        public string MAPDV { get { return _MAPDV; } set { _MAPDV = value; OnPropertyChanged(); } }
        private string _MADV;
        public string MADV { get { return _MADV; } set { _MADV = value; OnPropertyChanged(); } }
        private string _TENDV;
        public string TENDV { get { return _TENDV; } set { _TENDV = value; OnPropertyChanged(); } }
        private int? _SLDV;
        public int? SLDV { get { return _SLDV; } set { _SLDV = value; OnPropertyChanged(); } }
        private decimal? _GIA;
        public decimal? GIA { get { return _GIA; } set { _GIA = value; OnPropertyChanged(); } }
    }
    //public class CTPDV2
    //{
    //    public string MAPDV { get; set; }
    //    public string TENDV { get; set; }
    //    public int? SLDV { get; set; }
    //    public decimal? GIA { get; set; }
    //}
    //public class TENDVConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        if (value != null)
    //        {
    //            // Lấy giá trị MAPDV từ ListCTPDV
    //            string mapdv = value.ToString();

    //            // Lấy TENDV từ ListDV dựa trên MAPDV
    //            var tendv = ListDV.FirstOrDefault(dv => dv.MAPDV == mapdv)?.TENDV;

    //            return tendv;
    //        }

    //        return string.Empty;
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    public class PhieuDatDichVuViewModel : BasicViewModel
    {
        private CTPDV1 _SelectedItem;
        public CTPDV1 SelectedItem
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
                    TENDV = SelectedItem.TENDV;
                    MAPDV = SelectedItem.MAPDV;
                    MADV = SelectedItem.MADV;
                    SLDV = SelectedItem.SLDV;
                    GIA = SelectedItem.GIA;
                }
            }
        }
        private List<int?> _LISTNUMBER;
        public List<int?> LISTNUMBER { get { return _LISTNUMBER; } set { _LISTNUMBER = value; OnPropertyChanged(); } }
        private List<int?> _ListNumber;
        public List<int?> ListNumber { get { return _ListNumber; } set { _ListNumber = value; OnPropertyChanged(); } }
        private ObservableCollection<CTPDV1> _ListCTPDV1;
        public ObservableCollection<CTPDV1> ListCTPDV1 { get { return _ListCTPDV1; } set { _ListCTPDV1 = value; OnPropertyChanged(); } }
        //private ObservableCollection<CTPDV2> _ListCTPDV2;
        //public ObservableCollection<CTPDV2> ListCTPDV2 { get { return _ListCTPDV2; } set { _ListCTPDV2 = value; OnPropertyChanged(); } }
        //private TENDVConverter _tendvConverter;
        //public TENDVConverter TENDVConverter
        //{
        //    get
        //    {
        //        if (_tendvConverter == null)
        //            _tendvConverter = new TENDVConverter();
        //        return _tendvConverter;
        //    }
        //    set { _tendvConverter = value; }
        //}

        private string _TENDICHVU;
        public string TENDICHVU { get { return _TENDICHVU; } set { _TENDICHVU = value; OnPropertyChanged(); } }
        private int _SOLUONG;
        public int SOLUONG { get { return _SOLUONG; } set { _SOLUONG = value; OnPropertyChanged(); } }
        private decimal? _TONGTIEN;
        public decimal? TONGTIEN { get { return _TONGTIEN; } set { _TONGTIEN = value; OnPropertyChanged(); } }
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

        private int? _SLDV;
        public int? SLDV { get { return _SLDV; } set { _SLDV = value; OnPropertyChanged(); } }
        private decimal? _GIA;
        public decimal? GIA { get { return _GIA; } set { _GIA = value; OnPropertyChanged(); } }


        //Phiếu dịch vụ
        private ObservableCollection<PHIEUDICHVU> _ListPDV;
        public ObservableCollection<PHIEUDICHVU> ListPDV { get { return _ListPDV; } set { _ListPDV = value; OnPropertyChanged(); } }
        private string _MAPDV;
        public string MAPDV { get { return _MAPDV; } set { _MAPDV = value; OnPropertyChanged(); } }
        private DateTime? _NGLAP;
        public DateTime? NGLAP { get { return _NGLAP; } set { _NGLAP = value; OnPropertyChanged(); } }

        //Chi tiết phiếu đặt phòng
        private ObservableCollection<CTPDP> _ListCTPDP;
        public ObservableCollection<CTPDP> ListCTPDP { get { return _ListCTPDP; } set { _ListCTPDP = value; OnPropertyChanged(); } }
        private string _MACTPDP;
        public string MACTPDP { get { return _MACTPDP; } set { _MACTPDP = value; OnPropertyChanged(); } }
        private string _MAPDP;
        public string MAPDP { get { return _MAPDP; } set { _MAPDP = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand ShowCommand { get; set; }
        public ICommand ShowCommand1 { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        //public void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var tempList = new List<CTPDV1>();
        //    foreach (var ctpdv1 in ListCTPDV1)
        //    {
        //        tempList.Add(new CTPDV1
        //        {
        //            MAPDV = ctpdv1.MAPDV,
        //            MADV = ctpdv1.MADV,
        //            SLDV = ctpdv1.SLDV,
        //            GIA = ctpdv1.GIA,
        //            TENDV = ctpdv1.TENDV
        //        });
        //    }
        //    ListCTPDV1 = new ObservableCollection<CTPDV1>(tempList);
        //}

        public PhieuDatDichVuViewModel()
        {
            string selectedRoom = null;
            ListDV = new ObservableCollection<DICHVU>(DataProvider.Ins.DB.DICHVUs);
            ListPDV = new ObservableCollection<PHIEUDICHVU>(DataProvider.Ins.DB.PHIEUDICHVUs);
            ListPhong = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs);
            ListCTPDV = new ObservableCollection<CTPDV>(DataProvider.Ins.DB.CTPDVs);
            ListCTPDP = new ObservableCollection<CTPDP>(DataProvider.Ins.DB.CTPDPs);
            SSOPHONG = new List<string>();
            ListNumber = new List<int?>();
            SLDV = 1;
            int same = 0;
            int count = 0;
            int New = 0;
            decimal? tongtien = 0;

            ShowCommand = new RelayCommand<ComboBox>((p) => { return true; }, (p) =>
            {
                foreach (var dv in ListDV)
                {
                    if (dv.TENDV == TENDV)
                        MADV = dv.MADV;
                }
            });

            ShowCommand1 = new RelayCommand<ComboBox>((p) => { return true; }, (p) =>
            {
                //ListCTPDV2 = new ObservableCollection<CTPDV2>();
                ListCTPDV1 = new ObservableCollection<CTPDV1>();
                if(SOPHONG != null)
                {
                    selectedRoom = SOPHONG;
                    var ctpdp = ListPhong.FirstOrDefault(phong => phong.SOPHONG == selectedRoom)?.CTPDP;
                    MACTPDP = ctpdp.MACTPDP; //?????????
                    MAPDP = ctpdp.MAPDP;
                    var phieuDichVu = ListPDV.FirstOrDefault(pdv => pdv.MAPDP == MAPDP);
                    if (phieuDichVu == null)
                    {
                        int maxCode = ListPDV.Max(dv => int.Parse(dv.MAPDV.Substring(2)));
                        string nextCode = $"PH{maxCode + 1:000}";
                        MAPDV = nextCode;
                        New = 1;
                    }
                    else
                        MAPDV = phieuDichVu.MAPDV.ToString();
                }
                ListCTPDV = new ObservableCollection<CTPDV>(DataProvider.Ins.DB.CTPDVs);
                foreach (var ctpdv in ListCTPDV)
                {
                    if (ctpdv.MAPDV == MAPDV)
                        ListCTPDV1.Add(new CTPDV1 { MAPDV = ctpdv.MAPDV, MADV = ctpdv.MADV, SLDV = ctpdv.SLDV, GIA = ctpdv.GIA, TENDV = null });
                }
                foreach (var ctpdv1 in ListCTPDV1)
                {
                    foreach (var dv in ListDV)
                    {
                        if (dv.MADV == ctpdv1.MADV)
                        {
                            ctpdv1.TENDV = dv.TENDV;
                            break;
                        }
                    }
                }
            });

            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                decimal? sum = 0;
                foreach (var dv in ListDV)
                {
                    if (dv.MADV == MADV)
                        sum = dv.DONGIA * SLDV;
                }

                foreach (var ctpdv in ListCTPDV)
                {                 
                    if (ctpdv.MAPDV == MAPDV && ctpdv.MADV == MADV)
                    {
                        var ctpdv3 = DataProvider.Ins.DB.CTPDVs.Where(x => x.MAPDV == MAPDV && x.MADV == MADV).SingleOrDefault();
                        ctpdv3.MAPDV = MAPDV;
                        ctpdv3.MADV = MADV;
                        ctpdv3.SLDV += SLDV;
                        ctpdv3.GIA += sum;
                        DataProvider.Ins.DB.SaveChanges();
                        same = 1;
                    }
                }
                if (New == 1)
                {
                    var pdv = new PHIEUDICHVU() { MAPDV = MAPDV, MAPDP = MAPDP, NGLAP = DateTime.Now, TONGTIEN = null };
                    DataProvider.Ins.DB.PHIEUDICHVUs.Add(pdv);
                    DataProvider.Ins.DB.SaveChanges();
                    New = 0;
                }
                ListPDV = new ObservableCollection<PHIEUDICHVU>(DataProvider.Ins.DB.PHIEUDICHVUs);
                if (same == 0)
                {
                    var ctpdv4 = new CTPDV() { MAPDV = MAPDV, MADV = MADV, SLDV = SLDV, GIA = sum };
                    DataProvider.Ins.DB.CTPDVs.Add(ctpdv4);
                    DataProvider.Ins.DB.SaveChanges();
                }
                ListCTPDV = new ObservableCollection<CTPDV>(DataProvider.Ins.DB.CTPDVs);
                foreach (var ctpdv in ListCTPDV)
                {
                    if (ctpdv.MAPDV == MAPDV)
                    {
                        tongtien += ctpdv.GIA;
                    }
                }
                foreach (var pdv in ListPDV)
                {
                    if (pdv.MAPDV == MAPDV)
                    {
                        pdv.TONGTIEN = tongtien;
                        DataProvider.Ins.DB.SaveChanges();
                    }
                }
                tongtien = 0;

                ListCTPDV1.Add(new CTPDV1 { MAPDV = MAPDV, MADV = MADV, SLDV = SLDV, GIA = sum, TENDV = TENDV });
                MessageBox.Show("Thêm đơn mua dịch vụ thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

            });
            CancelCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                MADV = MAPDV = "";
                TENDV = SOPHONG = null;
                SLDV = 1;
            });
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                return SelectedItem != null;
            }, (p) =>
            {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.OK)
                {                   
                    //ListCTPDV1 = new ObservableCollection<CTPDV1>();
                    //foreach (var ctpdv2 in ListCTPDV)
                    //{
                    //    if (ctpdv2.MAPDV == MAPDV)
                    //        ListCTPDV1.Add(new CTPDV1 { MAPDV = ctpdv2.MAPDV, MADV = ctpdv2.MADV, SLDV = ctpdv2.SLDV, GIA = ctpdv2.GIA, TENDV = null });
                    //}
                    //foreach (var ctpdv1 in ListCTPDV1)
                    //{
                    //    foreach (var dv in ListDV)
                    //    {
                    //        if (dv.MADV == ctpdv1.MADV)
                    //        {
                    //            ctpdv1.TENDV = dv.TENDV;
                    //            break;
                    //        }
                    //    }
                    //}

                    if (count == 2)
                    {
                        var ctpdv3 = DataProvider.Ins.DB.CTPDVs.Where(x => x.MADV == SelectedItem.MADV && x.MAPDV == SelectedItem.MAPDV).SingleOrDefault();
                        ctpdv3.MAPDV = SelectedItem.MAPDV;
                        ctpdv3.MADV = SelectedItem.MADV;
                        ctpdv3.SLDV -= SelectedItem.SLDV;
                        ctpdv3.GIA -= SelectedItem.GIA;
                        DataProvider.Ins.DB.SaveChanges();
                    }
                    else
                    {
                        var ctpdv4 = DataProvider.Ins.DB.CTPDVs.Where(x => x.MADV == SelectedItem.MADV && x.MAPDV == SelectedItem.MAPDV).SingleOrDefault();
                        DataProvider.Ins.DB.CTPDVs.Remove(ctpdv4);
                        DataProvider.Ins.DB.SaveChanges();
                    }
                    ListCTPDV = new ObservableCollection<CTPDV>(DataProvider.Ins.DB.CTPDVs);
                    ListCTPDV1.Remove(SelectedItem);
                    foreach (var ctpdv in ListCTPDV1)
                    {
                        tongtien += ctpdv.GIA;
                        if (ctpdv.MADV == MADV)
                            count++;
                    }
                    foreach (var pdv in ListPDV)
                    {
                        if (pdv.MAPDV == MAPDV)
                        {
                            pdv.TONGTIEN = tongtien;
                            DataProvider.Ins.DB.SaveChanges();
                        }
                    }
                    tongtien = 0;
                    count = 0;
                    MessageBox.Show("Xóa đơn mua dịch vụ thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            });
        }
    }
}
