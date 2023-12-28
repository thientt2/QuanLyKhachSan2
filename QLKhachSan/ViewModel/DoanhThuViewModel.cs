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
        private int _Nam;
        public int Nam { get { return _Nam; } set { _Nam = value; OnPropertyChanged(); } }
        private List<int> _LThang;
        public List<int> LThang { get { return _LThang; } set { _LThang = value; OnPropertyChanged(); } }
        private int _Thang;
        public int Thang { get { return _Thang; } set { _Thang = value; OnPropertyChanged(); } }
        private ObservableCollection<HOADON> _ListHD;
        public ObservableCollection<HOADON> ListHD { get { return _ListHD; } set { _ListHD = value; OnPropertyChanged(); } }
        public ICommand ShowCommand1 { get; set; }
        public ICommand ShowCommand2 { get; set; }
        public string[] maloai = { "Standard", "Deluxe", "Premium", "La Opera" };

        public DoanhThuViewModel()
        {
            ListHD = new ObservableCollection<HOADON>(DataProvider.Ins.DB.HOADONs);
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
                    int selectedNam = (int)p.SelectedItem; // Giả sử ComboBox chứa các năm (int)
                    // Lọc danh sách các tháng dựa trên năm đã chọn
                   foreach(var hd in ListHD)
                    {
                        if(hd.NGLAPHD.Value.Year==selectedNam)
                        {
                            int thang = hd.NGLAPHD.Value.Month;
                            if (!LThang.Contains(thang))
                            {
                                LThang.Add(thang);
                            }
                        }    
                    }                                 

                    // Sắp xếp danh sách tháng
                    //LThang.Sort();
                    
                }
            });
            ShowCommand2 = new RelayCommand<ComboBox>((p) => { return true; }, (p) => {
                if (p != null && p.SelectedItem != null)
                {
                    int selectedThang = (int)p.SelectedItem;
                }
            });

        }

    }
}