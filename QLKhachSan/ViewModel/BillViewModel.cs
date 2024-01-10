using QLKhachSan.Model;
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
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

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
        private DateTime? _NGTRA;
        public DateTime? NGTRA { get { return _NGTRA; } set { _NGTRA = value; OnPropertyChanged(); } }

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
        private string _LOAI;
        public string LOAI { get { return _LOAI; } set { _LOAI = value; OnPropertyChanged(); } }

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

        private int? _SONGAY;
        public int? SONGAY { get { return _SONGAY; } set { _SONGAY = value; OnPropertyChanged(); } }

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
            MANV = MANV;

            PrintCommand = new RelayCommand<object>((p) =>
            {
                if (NGTRA != null)
                {
                    if (NGTRA.Value.Date != DateTime.Now.Date)
                        return false;
                }    
                return true;
            }, (p) =>
            {
                try
                {
                    XuatPDF();
                    var hd = new HOADON { MAHD = MAHD, MAPDP = MAPDP, LOAI = LOAI, NGLAPHD = NGLAPHD, THANHTIEN = THANHTIEN };
                    DataProvider.Ins.DB.HOADONs.Add(hd);
                    var phong = DataProvider.Ins.DB.PHONGs.Where(x => x.SOPHONG == SOPHONG1).SingleOrDefault();
                    var pdp = DataProvider.Ins.DB.PHIEUDATPHONGs.Where(x => x.MAPDP == MAPDP1).SingleOrDefault();
                    pdp.NGTRA = DateTime.Now;
                    phong.TINHTRANG = "Trống";
                    phong.MAPDP = null;                    
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Xuất file PDF và in hóa đơn thành công!");
                    MessageBox.Show($"Thanh toán phòng {SOPHONG1} thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    FrameworkElement window = p as FrameworkElement;
                    var w = window as Window;
                    if (w != null)
                    {
                        w.Close();
                    }

                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            MessageBox.Show($"Lỗi: {validationError.ErrorMessage}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show($"Lỗi cập nhật cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }

        public void Init()
        {
            var pdp = DataProvider.Ins.DB.PHIEUDATPHONGs.Where(x => x.MAPDP == MAPDP1).SingleOrDefault();
            var loaiphong = DataProvider.Ins.DB.LOAIPHONGs.Where(x => x.MALOAI == MALOAI1).SingleOrDefault();
            var pdv = DataProvider.Ins.DB.PHIEUDICHVUs.Where(x => x.MAPDP == MAPDP1).SingleOrDefault();
            var nv= DataProvider.Ins.DB.NHANVIENs.Where(x => x.MANV == MANV).SingleOrDefault();
            int maxCode = HoaDon.Max(hd => int.Parse(hd.MAHD.Substring(2)));
            string nextCode = $"HD{maxCode + 1:000}";
            MAHD = nextCode;

            if (pdp != null && loaiphong != null&&nv!=null)
            {
                TONGTIEN = 0;
                MAPDP = pdp.MAPDP;
                NGLAPHD = DateTime.Now;
                TENNV = nv.TENNV;
                TENKH = pdp.KHACHHANG.TENKH;
                SOCCCD = pdp.KHACHHANG.SOCCCD;
                SDT = pdp.KHACHHANG.SDT;
                DIACHI = pdp.KHACHHANG.DIACHI;
                SOPHONG = SOPHONG1;
                LOAI = MALOAI1;
                GIA = loaiphong.GIA;
                NGNHAN = pdp.NGNHAN;
                NGTRA = pdp.NGTRA;
                if(pdv != null)
                {
                    MAPDV = pdv.MAPDV;
                    TONGTIEN = pdv.TONGTIEN;
                }    

                SONGAY = (int)(NGLAPHD - NGNHAN).Value.Days + 1;
                if (NGLAPHD.Value.Hour > 12 && NGLAPHD.Value.Hour < NGNHAN.Value.Hour)
                    SONGAY++;
                //TimeSpan? KhoangCach = NGTRA - NGNHAN;
                //if (KhoangCach.HasValue)
                //    SONGAY = KhoangCach.Value.Days;
                TIENPHONG = GIA * SONGAY;
                THANHTIEN = TIENPHONG + TONGTIEN;
                ListCTPDV = new ObservableCollection<CHITIETDICHVU>(DataProvider.Ins.DB.CHITIETDICHVUs);
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

        private void XuatPDF()
        {
            string ThuMuc = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string DuongDan = Path.Combine(ThuMuc, $"Hóa Đơn {MAHD}.pdf");
            using (FileStream fs = new FileStream(DuongDan, FileMode.Create))
            {
                PdfWriter writer = new PdfWriter(fs);
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    iText.Layout.Document document = new iText.Layout.Document(pdf);
                    document.Add(new iText.Layout.Element.Paragraph("------------------------------------------------------------------"));
                    document.Add(new iText.Layout.Element.Paragraph("                                              "));
                    document.Add(new iText.Layout.Element.Paragraph($"        Bill Code: {MAHD}                     "));
                    document.Add(new iText.Layout.Element.Paragraph($"        Guest: {TENKH}                   "));
                    document.Add(new iText.Layout.Element.Paragraph($"        Room: {SOPHONG}                      "));
                    document.Add(new iText.Layout.Element.Paragraph($"        Check-in date: {NGNHAN}               "));
                    document.Add(new iText.Layout.Element.Paragraph($"        Check-out date: {NGTRA}               "));
                    document.Add(new iText.Layout.Element.Paragraph($"        Total: {THANHTIEN}                    "));
                    document.Add(new iText.Layout.Element.Paragraph($"                                              "));
                    document.Add(new iText.Layout.Element.Paragraph("------------------------------------------------------------------"));
                    document.Close();
                }
            }
        }


    }
}
