﻿using QLKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System.Net.NetworkInformation;
using System.IO;
using System.Xml.Linq;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Printing;
using System.Windows.Xps.Packaging;


namespace QLKhachSan.ViewModel
{
    public class BillViewModel : BasicViewModel
    {
        private ObservableCollection<CTPDV1> _ListCTPDV1;
        public ObservableCollection<CTPDV1> ListCTPDV1 { get { return _ListCTPDV1; } set { _ListCTPDV1 = value; OnPropertyChanged(); } }
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
        private string _SOPHONG1;
        public string SOPHONG1 { get { return _SOPHONG1; } set { _SOPHONG1 = value; OnPropertyChanged(); } }
        private string _MALOAI;
        public string MALOAI { get { return _MALOAI; } set { _MALOAI = value; OnPropertyChanged(); } }

        //Chi tiết phiếu dịch vụ
        private ObservableCollection<CHITIETDICHVU> _ListCTPDV;
        public ObservableCollection<CHITIETDICHVU> ListCTPDV { get { return _ListCTPDV; } set { _ListCTPDV = value; OnPropertyChanged(); } }
        private int? _SLDV;
        public int? SLDV { get { return _SLDV; } set { _SLDV = value; OnPropertyChanged(); } }
        private decimal? _GIA;
        public decimal? GIA { get { return _GIA; } set { _GIA = value; OnPropertyChanged(); } }
        private decimal? _TIENPHONG;
        public decimal? TIENPHONG { get { return _TIENPHONG; } set { _TIENPHONG = value; OnPropertyChanged(); } }
        private decimal? _THANHTIEN;
        public decimal? THANHTIEN { get { return _THANHTIEN; } set { _THANHTIEN = value; OnPropertyChanged(); } }

        //Phiếu đặt phòng
        private ObservableCollection<PHIEUDATPHONG> _ListPDP;
        public ObservableCollection<PHIEUDATPHONG> ListPDP { get { return _ListPDP; } set { _ListPDP = value; OnPropertyChanged(); } }
        private DateTime? _NGNHAN;
        public DateTime? NGNHAN { get { return _NGNHAN; } set { _NGNHAN = value; OnPropertyChanged(); } }

        //Phiếu dịch vụ
        private ObservableCollection<PHIEUDICHVU> _ListPDV;
        public ObservableCollection<PHIEUDICHVU> ListPDV { get { return _ListPDV; } set { _ListPDV = value; OnPropertyChanged(); } }
        private string _MAPDV;
        public string MAPDV { get { return _MAPDV; } set { _MAPDV = value; OnPropertyChanged(); } }
        private DateTime? _NGLAP;
        public DateTime? NGLAP { get { return _NGLAP; } set { _NGLAP = value; OnPropertyChanged(); } }
        private string _MAPDP;
        public string MAPDP { get { return _MAPDP; } set { _MAPDP = value; OnPropertyChanged(); } }

        //Hoá đơn
        private ObservableCollection<HOADON> _HoaDon;
        public ObservableCollection<HOADON> HoaDon { get { return _HoaDon; } set { _HoaDon = value; OnPropertyChanged(); } }
        private string _MAHD;
        public string MAHD { get { return _MAHD; } set { _MAHD = value; OnPropertyChanged(); } }
        private string _MANV;
        public string MANV { get { return _MANV; } set { _MANV = value; OnPropertyChanged(); } }
        private string _TENNV;
        public string TENNV { get { return _TENNV; } set { _TENNV = value; OnPropertyChanged(); } }
        private DateTime? _NGLAPHD;
        public DateTime? NGLAPHD { get { return _NGLAPHD; } set { _NGLAPHD = value; OnPropertyChanged(); } }

        private ObservableCollection<NHANVIEN> _NhanVien;
        public ObservableCollection<NHANVIEN> NhanVien { get { return _NhanVien; } set { _NhanVien = value; OnPropertyChanged(); } }
        private string _MAKH;
        public string MAKH { get { return _MAKH; } set { _MAKH = value; OnPropertyChanged(); } }
        private string _TENKH;
        public string TENKH { get { return _TENKH; } set { _TENKH = value; OnPropertyChanged(); } }
        private string _DIACHI;
        public string DIACHI { get { return _DIACHI; } set { _DIACHI = value; OnPropertyChanged(); } }
        private string _SDT;
        public string SDT { get { return _SDT; } set { _SDT = value; OnPropertyChanged(); } }
        private string _SOCCCD;
        public string SOCCCD { get { return _SOCCCD; } set { _SOCCCD = value; OnPropertyChanged(); } }

        private string _MAPDP1;
        public string MAPDP1 { get { return _MAPDP1; } set { _MAPDP1 = value; OnPropertyChanged(); } }
        private string _MALOAI1;
        public string MALOAI1 { get { return _MALOAI1; } set { _MALOAI1 = value; OnPropertyChanged(); } }
        private string _MACTPDP1;
        public string MACTPDP1 { get { return _MACTPDP1; } set { _MACTPDP1 = value; OnPropertyChanged(); } }

        public ICommand PrintCommand { get; set; }
        public ICommand CloseCommand { get; set; }

        public BillViewModel()
        {
            ListDV = new ObservableCollection<DICHVU>(DataProvider.Ins.DB.DICHVUs);
            ListPDV = new ObservableCollection<PHIEUDICHVU>(DataProvider.Ins.DB.PHIEUDICHVUs);
            ListPDP = new ObservableCollection<PHIEUDATPHONG>(DataProvider.Ins.DB.PHIEUDATPHONGs);
            ListPhong = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs);
            ListCTPDV = new ObservableCollection<CHITIETDICHVU>(DataProvider.Ins.DB.CHITIETDICHVUs);
            HoaDon = new ObservableCollection<HOADON>(DataProvider.Ins.DB.HOADONs);
            Init();

            PrintCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                //PrintDialog printDialog = new PrintDialog();

                //if (printDialog.ShowDialog() == true)
                //{
                //    // Thực hiện công việc in tại đây
                //    PrintDocument(printDialog.PrintQueue);
                //}
                var hd = new HOADON { MAHD = MAHD, MAPDP = MAPDP, NGLAPHD = NGLAPHD, THANHTIEN = THANHTIEN };
                DataProvider.Ins.DB.HOADONs.Add(hd);
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Bill printed successfully!");
                

            });
            CloseCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                // tất cả null
                FrameworkElement window = p as FrameworkElement;
                var w = window as Window;
                if (w != null)
                {
                    w.Close();
                }
            });
        }


        public void Init()
        {
            int SoNgay = 0;
            var pdp = DataProvider.Ins.DB.PHIEUDATPHONGs.Where(x => x.MAPDP == MAPDP1).SingleOrDefault();
            var phong = DataProvider.Ins.DB.PHONGs.Where(x => x.MAPDP == MAPDP1).SingleOrDefault();
            var pdv = DataProvider.Ins.DB.PHIEUDICHVUs.Where(x => x.MAPDP == MAPDP1).SingleOrDefault();

            int maxCode = HoaDon.Max(hd => int.Parse(hd.MAHD.Substring(2)));
            string nextCode = $"HD{maxCode + 1:000}";
            MAHD = nextCode;

            if (pdp != null && phong != null && pdv != null)
            {
                MAPDP = pdp.MAPDP;
                NGLAPHD = DateTime.Now;
                TENNV = pdp.NHANVIEN.TENNV;
                TENKH = pdp.KHACHHANG.TENKH;
                SOCCCD = pdp.KHACHHANG.SOCCCD;
                SDT = pdp.KHACHHANG.SDT;
                DIACHI = pdp.KHACHHANG.DIACHI;
                SOPHONG = SOPHONG1;
                MALOAI = MALOAI1;
                GIA = phong.LOAIPHONG.GIA;
                NGNHAN = pdp.NGNHAN;
                MAPDV = pdv.MAPDV;

                TimeSpan? KhoangCach = DateTime.Now - NGNHAN;
                if (KhoangCach.HasValue)
                    SoNgay = KhoangCach.Value.Days;
                TIENPHONG = GIA * SoNgay;
                TONGTIEN = pdv.TONGTIEN;
                THANHTIEN = TIENPHONG + TONGTIEN;
                ListCTPDV1 = new ObservableCollection<CTPDV1>();
                //hiển thị thông qua binding TENDV?
                //hiển thị thông qua bảng kết
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
            }
        }

        //private void PrintDocument(PrintQueue printQueue)
        //{
        //    var printCapabilities = printQueue.GetPrintCapabilities();

        //    // Bây giờ bạn có thể sử dụng printCapabilities để lấy thông tin in ấn
        //    double pageWidth = printCapabilities.PageImageableArea.ExtentWidth;
        //    double pageHeight = printCapabilities.PageImageableArea.ExtentHeight;

        //    // Tạo một FixedDocument để chứa nội dung cần in
        //    FixedDocument fixedDoc = new FixedDocument();

        //    // Tạo trang mới
        //    FixedPage page1 = new FixedPage();
        //    page1.Width = pageWidth;
        //    page1.Height = pageHeight;

        //    // Thêm nội dung vào trang
        //    TextBlock textBlock = new TextBlock();
        //    textBlock.Text = "Hello, this is a sample printed page.";
        //    page1.Children.Add(textBlock);

        //    // Thêm trang vào tài liệu
        //    PageContent page1Content = new PageContent();
        //    ((IAddChild)page1Content).AddChild(page1);
        //    fixedDoc.Pages.Add(page1Content);

        //    XpsDocumentWriter xpsWriter = PrintQueue.CreateXpsDocumentWriter(printQueue);

        //    // Thực hiện việc in vào tài liệu XPS
        //    // ...

        //    // Gọi Dispose khi bạn đã hoàn thành công việc in
        //    xpsWriter.Dispose();
        //}
    }
}