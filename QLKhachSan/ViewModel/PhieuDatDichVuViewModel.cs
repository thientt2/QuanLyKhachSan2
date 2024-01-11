using QLKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
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
        private ObservableCollection<CHITIETDICHVU> _ListCTPDV;
        public ObservableCollection<CHITIETDICHVU> ListCTPDV { get { return _ListCTPDV; } set { _ListCTPDV = value; OnPropertyChanged(); } }
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
        private string _MAPDP;
        public string MAPDP { get { return _MAPDP; } set { _MAPDP = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand ShowCommand { get; set; }
        public ICommand ShowCommand1 { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public PhieuDatDichVuViewModel()
        {
            ListDV = new ObservableCollection<DICHVU>(DataProvider.Ins.DB.DICHVUs);
            ListPDV = new ObservableCollection<PHIEUDICHVU>(DataProvider.Ins.DB.PHIEUDICHVUs);
            ListPhong = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs);
            ListCTPDV = new ObservableCollection<CHITIETDICHVU>(DataProvider.Ins.DB.CHITIETDICHVUs);
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

            ShowCommand1 = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                try
                {
                    ListCTPDV1 = new ObservableCollection<CTPDV1>();
                    ListPhong = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs);
                    var pdp = ListPhong.FirstOrDefault(phong => phong.SOPHONG == SOPHONG);
                    MAPDP = pdp.MAPDP;
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
                    ListCTPDV = new ObservableCollection<CHITIETDICHVU>(DataProvider.Ins.DB.CHITIETDICHVUs);
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

            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                try
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
                            var ctpdv3 = DataProvider.Ins.DB.CHITIETDICHVUs.Where(x => x.MAPDV == MAPDV && x.MADV == MADV).SingleOrDefault();
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
                        var pdv = new PHIEUDICHVU() { MAPDV = MAPDV, MAPDP = MAPDP, TONGTIEN = null };
                        DataProvider.Ins.DB.PHIEUDICHVUs.Add(pdv);
                        DataProvider.Ins.DB.SaveChanges();
                        New = 0;
                    }
                    ListPDV = new ObservableCollection<PHIEUDICHVU>(DataProvider.Ins.DB.PHIEUDICHVUs);
                    if (same == 0)
                    {
                        var ctpdv4 = new CHITIETDICHVU() { MAPDV = MAPDV, MADV = MADV, SLDV = SLDV, GIA = sum };
                        DataProvider.Ins.DB.CHITIETDICHVUs.Add(ctpdv4);
                        DataProvider.Ins.DB.SaveChanges();
                    }
                    ListCTPDV = new ObservableCollection<CHITIETDICHVU>(DataProvider.Ins.DB.CHITIETDICHVUs);
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
            CancelCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                try
                {
                    MADV = MAPDV = "";
                    TENDV = null;
                    SLDV = 1;
                }                
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                return SelectedItem != null;
            }, (p) =>
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (result == MessageBoxResult.OK)
                    {
                        if (count == 2)
                        {
                            var ctpdv3 = DataProvider.Ins.DB.CHITIETDICHVUs.Where(x => x.MADV == SelectedItem.MADV && x.MAPDV == SelectedItem.MAPDV).SingleOrDefault();
                            ctpdv3.MAPDV = SelectedItem.MAPDV;
                            ctpdv3.MADV = SelectedItem.MADV;
                            ctpdv3.SLDV -= SelectedItem.SLDV;
                            ctpdv3.GIA -= SelectedItem.GIA;
                            DataProvider.Ins.DB.SaveChanges();
                        }
                        else
                        {
                            var ctpdv4 = DataProvider.Ins.DB.CHITIETDICHVUs.Where(x => x.MADV == SelectedItem.MADV && x.MAPDV == SelectedItem.MAPDV).SingleOrDefault();
                            DataProvider.Ins.DB.CHITIETDICHVUs.Remove(ctpdv4);
                            DataProvider.Ins.DB.SaveChanges();
                        }
                        ListCTPDV = new ObservableCollection<CHITIETDICHVU>(DataProvider.Ins.DB.CHITIETDICHVUs);
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
    }
}
