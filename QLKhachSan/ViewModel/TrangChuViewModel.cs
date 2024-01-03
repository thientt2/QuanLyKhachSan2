using QLKhachSan.Model;
using QLKhachSan.UserControlKS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static QLKhachSan.ViewModel.BasicViewModel;

namespace QLKhachSan.ViewModel
{
    public class TrangChuViewModel : BasicViewModel
    {
        private ObservableCollection<PHONG> _ListPhong;
        public ObservableCollection<PHONG> ListPhong { get { return _ListPhong; } set { _ListPhong = value; OnPropertyChanged(); } }
        public class ExpanderData
        {
            public string FloorNumber { get; set; }
            public ObservableCollection<RoomUC> Rooms { get; set; }

            public ExpanderData()
            {
                Rooms = new ObservableCollection<RoomUC>();
            }
        }
        public ObservableCollection<ExpanderData> ExpanderItems { get; set; }

        public ObservableCollection<RoomUC> MyStackPanel1 { get; set; }
        public ObservableCollection<RoomUC> MyStackPanel2 { get; set; }
        public ObservableCollection<RoomUC> MyStackPanel3 { get; set; }
        public ObservableCollection<RoomUC> MyStackPanel4 { get; set; }
        public ObservableCollection<RoomUC> MyStackPanel5 { get; set; }
        public ObservableCollection<RoomUC> MyStackPanel6 { get; set; }
        public ObservableCollection<RoomUC> MyStackPanel7 { get; set; }
        public ICommand SortAllCommand { get; set; }
        public ICommand SortUsingCommand { get; set; }
        public ICommand SortEmptyCommand { get; set; }
        public ICommand SortBookedCommand { get; set; }

        public TrangChuViewModel()
        {
            ListPhong = new ObservableCollection<PHONG>(DataProvider.Ins.DB.PHONGs);
            MyStackPanel1 = new ObservableCollection<RoomUC>();
            MyStackPanel2 = new ObservableCollection<RoomUC>();
            MyStackPanel3 = new ObservableCollection<RoomUC>();
            MyStackPanel4 = new ObservableCollection<RoomUC>();
            MyStackPanel5 = new ObservableCollection<RoomUC>();
            MyStackPanel6 = new ObservableCollection<RoomUC>();
            MyStackPanel7 = new ObservableCollection<RoomUC>();
            ExpanderItems = new ObservableCollection<ExpanderData>
        {
            new ExpanderData { FloorNumber = "1F", Rooms = MyStackPanel1 },
            new ExpanderData { FloorNumber = "2F", Rooms = MyStackPanel2 },
            new ExpanderData { FloorNumber = "3F", Rooms = MyStackPanel3 },
            new ExpanderData { FloorNumber = "4F", Rooms = MyStackPanel4 },
            new ExpanderData { FloorNumber = "5F", Rooms = MyStackPanel5 },
            new ExpanderData { FloorNumber = "6F", Rooms = MyStackPanel6 },
            new ExpanderData { FloorNumber = "7F", Rooms = MyStackPanel7 },
        };
            foreach (var phong in ListPhong)
            {
                int? floorNumber = phong.TANG;
                RoomUC room = new RoomUC { DataContext = phong };

                switch (floorNumber)
                {
                    case 1:
                        MyStackPanel1.Add(room);
                        break;
                    case 2:
                        MyStackPanel2.Add(room);
                        break;
                    case 3:
                        MyStackPanel3.Add(room);
                        break;
                    case 4:
                        MyStackPanel4.Add(room);
                        break;
                    case 5:
                        MyStackPanel5.Add(room);
                        break;
                    case 6:
                        MyStackPanel6.Add(room);
                        break;
                    case 7:
                        MyStackPanel7.Add(room);
                        break;
                    default:
                        break;
                }
            }

            SortUsingCommand = new RelayCommand<Button>((p) => { return true; }, (p) =>
            {
                try
                {
                    MyStackPanel1.Clear();
                    MyStackPanel2.Clear();
                    MyStackPanel3.Clear();
                    MyStackPanel4.Clear();
                    MyStackPanel5.Clear();
                    MyStackPanel6.Clear();
                    MyStackPanel7.Clear();
                    foreach (var phong in ListPhong)
                    {
                        if (phong.TINHTRANG == "Đang được sử dụng")
                        {
                            int? floorNumber = phong.TANG;
                            RoomUC room = new RoomUC { DataContext = phong };

                            switch (floorNumber)
                            {
                                case 1:
                                    MyStackPanel1.Add(room);
                                    break;
                                case 2:
                                    MyStackPanel2.Add(room);
                                    break;
                                case 3:
                                    MyStackPanel3.Add(room);
                                    break;
                                case 4:
                                    MyStackPanel4.Add(room);
                                    break;
                                case 5:
                                    MyStackPanel5.Add(room);
                                    break;
                                case 6:
                                    MyStackPanel6.Add(room);
                                    break;
                                case 7:
                                    MyStackPanel7.Add(room);
                                    break;
                                default:
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

            SortAllCommand = new RelayCommand<Button>((p) => { return true; }, (p) =>
            {
                try
                {
                    MyStackPanel1.Clear();
                    MyStackPanel2.Clear();
                    MyStackPanel3.Clear();
                    MyStackPanel4.Clear();
                    MyStackPanel5.Clear();
                    MyStackPanel6.Clear();
                    MyStackPanel7.Clear();
                    foreach (var phong in ListPhong)
                    {
                        int? floorNumber = phong.TANG;
                        RoomUC room = new RoomUC { DataContext = phong };

                        switch (floorNumber)
                        {
                            case 1:
                                MyStackPanel1.Add(room);
                                break;
                            case 2:
                                MyStackPanel2.Add(room);
                                break;
                            case 3:
                                MyStackPanel3.Add(room);
                                break;
                            case 4:
                                MyStackPanel4.Add(room);
                                break;
                            case 5:
                                MyStackPanel5.Add(room);
                                break;
                            case 6:
                                MyStackPanel6.Add(room);
                                break;
                            case 7:
                                MyStackPanel7.Add(room);
                                break;
                            default:
                                break;
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

            SortEmptyCommand = new RelayCommand<Button>((p) => { return true; }, (p) =>
            {
                try
                {
                    MyStackPanel1.Clear();
                    MyStackPanel2.Clear();
                    MyStackPanel3.Clear();
                    MyStackPanel4.Clear();
                    MyStackPanel5.Clear();
                    MyStackPanel6.Clear();
                    MyStackPanel7.Clear();
                    foreach (var phong in ListPhong)
                    {
                        if (phong.TINHTRANG == "Trống")
                        {
                            int? floorNumber = phong.TANG;
                            RoomUC room = new RoomUC { DataContext = phong };

                            switch (floorNumber)
                            {
                                case 1:
                                    MyStackPanel1.Add(room);
                                    break;
                                case 2:
                                    MyStackPanel2.Add(room);
                                    break;
                                case 3:
                                    MyStackPanel3.Add(room);
                                    break;
                                case 4:
                                    MyStackPanel4.Add(room);
                                    break;
                                case 5:
                                    MyStackPanel5.Add(room);
                                    break;
                                case 6:
                                    MyStackPanel6.Add(room);
                                    break;
                                case 7:
                                    MyStackPanel7.Add(room);
                                    break;
                                default:
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

            SortBookedCommand = new RelayCommand<Button>((p) => { return true; }, (p) =>
            {
                try
                {
                    MyStackPanel1.Clear();
                    MyStackPanel2.Clear();
                    MyStackPanel3.Clear();
                    MyStackPanel4.Clear();
                    MyStackPanel5.Clear();
                    MyStackPanel6.Clear();
                    MyStackPanel7.Clear();
                    foreach (var phong in ListPhong)
                    {
                        if (phong.TINHTRANG == "Đã đặt")
                        {
                            int? floorNumber = phong.TANG;
                            RoomUC room = new RoomUC { DataContext = phong };

                            switch (floorNumber)
                            {
                                case 1:
                                    MyStackPanel1.Add(room);
                                    break;
                                case 2:
                                    MyStackPanel2.Add(room);
                                    break;
                                case 3:
                                    MyStackPanel3.Add(room);
                                    break;
                                case 4:
                                    MyStackPanel4.Add(room);
                                    break;
                                case 5:
                                    MyStackPanel5.Add(room);
                                    break;
                                case 6:
                                    MyStackPanel6.Add(room);
                                    break;
                                case 7:
                                    MyStackPanel7.Add(room);
                                    break;
                                default:
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
        }

    }
}