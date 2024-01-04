using Microsoft.Win32;
using QLKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Threading;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using static QLKhachSan.ViewModel.BasicViewModel;

namespace QLKhachSan.ViewModel
{

    public class MainViewModel : BasicViewModel
    {
        private string _currentTime;

        public string CurrentTime
        {
            get { return _currentTime; }
            set
            {
                if (_currentTime != value)
                {
                    _currentTime = value;
                    OnPropertyChanged(nameof(CurrentTime));
                }
            }
        }

        private DispatcherTimer timer;

        private void InitializeTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateClock();
        }

        private void UpdateClock()
        {
            CurrentTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private ObservableCollection<NHANVIEN> _ListNV;
        public ObservableCollection<NHANVIEN> ListNV { get { return _ListNV; } set { _ListNV = value; OnPropertyChanged(); } }
        private string _MANV;
        public string MANV { get { return _MANV; } set { _MANV = value; OnPropertyChanged(); } }
        private string _MMANV;
        public string MMANV { get { return _MMANV; } set { _MMANV = value; OnPropertyChanged(); } }
        private string _TENNV;
        public string TENNV { get { return _TENNV; } set { _TENNV = value; OnPropertyChanged(); } }
        private string _GIOITINH;
        public string GIOITINH { get { return _GIOITINH; } set { _GIOITINH = value; OnPropertyChanged(); } }
        private string _DIACHI;
        public string DIACHI { get { return _DIACHI; } set { _DIACHI = value; OnPropertyChanged(); } }
        private string _SDT;
        public string SDT { get { return _SDT; } set { _SDT = value; OnPropertyChanged(); } }
        private string _EMAIL;
        public string EMAIL { get { return _EMAIL; } set { _EMAIL = value; OnPropertyChanged(); } }
        private string _VITRILAMVIEC;
        public string VITRILAMVIEC { get { return _VITRILAMVIEC; } set { _VITRILAMVIEC = value; OnPropertyChanged(); } }
        private DateTime? _NGSINH;
        public DateTime? NGSINH { get { return _NGSINH; } set { _NGSINH = value; OnPropertyChanged(); } }
        private string _ImagePath;
        public string ImagePath { get { return _ImagePath; } set { _ImagePath = value; OnPropertyChanged(); } }

        private string _NewImagePath;
        public string NewImagePath { get { return _NewImagePath; } set { _NewImagePath = value; OnPropertyChanged(); } }
        private int? _IDPHANQUYEN;
        public int? IDPHANQUYEN { get { return _IDPHANQUYEN; } set { _IDPHANQUYEN = value; OnPropertyChanged(); } }

        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; OnPropertyChanged(); } }
        private string _MATKHAU;
        public string MATKHAU { get { return _MATKHAU; } set { _MATKHAU = value; OnPropertyChanged(); } }

        public bool IsLoaded = false;
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand DatPhongCommand { get; set; }
        public ICommand LogOutCommand { get; set; }
        public ICommand ChangeImagePathCommand { get; set; }
        public ICommand ChangePWCommand { get; set; }


        public MainViewModel()
        {
            InitializeTimer();
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                try { IsLoaded = true;
                    if (p == null)
                        return;
                    p.Hide();
                    LoginWindow loginWindow = new LoginWindow();
                    loginWindow.ShowDialog();
                    if (loginWindow.DataContext == null)
                        return;
                    var loginVM = loginWindow.DataContext as LoginViewModel;
                    if (loginVM.IsLogin)
                    {
                        ListNV = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs);
                        MANV = loginVM.MANV;
                        IDPHANQUYEN = loginVM.IDPHANQUYEN;
                        ID = loginVM.ID;
                        MATKHAU = loginVM.MATKHAU;
                        var info = DataProvider.Ins.DB.NHANVIENs.FirstOrDefault(x => x.MANV == MANV);
                        MMANV = MANV;
                        TENNV = info.TENNV;
                        GIOITINH = info.GIOITINH;
                        SDT = info.SDT;
                        DIACHI = info.DIACHI;
                        NGSINH = info.NGSINH;
                        EMAIL = info.EMAIL;
                        VITRILAMVIEC = info.VITRILAMVIEC;
                        if (TENNV == "Nguyễn Hữu Trường")
                        {
                            ImagePath = "Images/HT.jpg";
                        }
                        if (TENNV == "Trần Trung Thông")
                        {
                            ImagePath = "Images/3T.jpg";
                        }
                        if (TENNV == "Tăng Thanh Thiện")
                        {
                            ImagePath = "Images/TT.jpg";
                        }
                        p.Show();
                        DatPhongWindow wd = new DatPhongWindow();
                        var addVM = wd.DataContext as PhieuDatPhongViewModel;
                        addVM.MANV = MANV;
                        Bill wd1 = new Bill();
                        var addVM1 = wd1.DataContext as BillViewModel;
                        addVM1.MANV = MANV;
                    }
                    else p.Close();
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
            }

        );
            ChangePWCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {

                ChangePWWindow wd = new ChangePWWindow();
                var addVM = wd.DataContext as ChangePasswordViewModel;
                addVM.IID = ID;
                addVM.MMATKHAU = MATKHAU;
                addVM.IID = ID;
                wd.ShowDialog();
            });
            LogOutCommand = new RelayCommand<object>((p) => { return true; }, (p) => { try
                {
                    LogOut();
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
            ChangeImagePathCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                try
                {
                    ChangeImagePath();
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

        void LogOut()
        {
            IsLoaded = false;
            ListNV.Clear();
            MANV = MMANV = TENNV = GIOITINH = DIACHI = SDT = EMAIL = VITRILAMVIEC = ImagePath = null;
            // Thực hiện các bước cần thiết để thoát và khởi động lại chương trình
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        private void ChangeImagePath()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (.png;.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (.)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                // Lấy đường dẫn mới từ OpenFileDialog
                NewImagePath = openFileDialog.FileName;

                // Cập nhật đường dẫn hình ảnh trong ImagePath
                ImagePath = NewImagePath;
            }
        }

    }
}