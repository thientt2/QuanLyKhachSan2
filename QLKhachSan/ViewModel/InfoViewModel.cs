using iText.Layout.Element;
using Org.BouncyCastle.Cms;
using QLKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Threading;

namespace QLKhachSan.ViewModel
{
    public class InfoViewModel : BasicViewModel
    {
        private TimeSpan? _remainingTime;

        public TimeSpan? RemainingTime
        {
            get { return _remainingTime; }
            set
            {
                if (_remainingTime != value)
                {
                    _remainingTime = value;
                    OnPropertyChanged(nameof(RemainingTime));
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
            UpdateRemainingTime();
        }

        private void UpdateRemainingTime()
        {
            RemainingTime = NGTRA - DateTime.Now;

            // Kiểm tra nếu thời gian còn lại là âm (đã kết thúc)
            if (RemainingTime?.TotalSeconds <= 0)
            {
                timer.Stop();
                RemainingTime = TimeSpan.Zero;
            }
        }
        private string _MAPDP;
        public string MAPDP { get { return _MAPDP; } set { _MAPDP = value; OnPropertyChanged(); } }
        private string _TENKH;
        public string TENKH { get { return _TENKH; } set { _TENKH = value; OnPropertyChanged(); } }
        private DateTime? _NGDAT;
        public DateTime? NGDAT { get { return _NGDAT; } set { _NGDAT = value; OnPropertyChanged(); } }
        private DateTime? _NGNHAN;
        public DateTime? NGNHAN { get { return _NGNHAN; } set { _NGNHAN = value; OnPropertyChanged(); } }
        private DateTime? _NGTRA;
        public DateTime? NGTRA { get { return _NGTRA; } set { _NGTRA = value; OnPropertyChanged(); } }
        private string _MAKH;
        public string MAKH { get { return _MAKH; } set { _MAKH = value; OnPropertyChanged(); } }
        private string _GIOITINH;
        public string GIOITINH { get { return _GIOITINH; } set { _GIOITINH = value; OnPropertyChanged();  } }
        private DateTime? _NGSINH;
        public DateTime? NGSINH { get { return _NGSINH; } set { _NGSINH = value; OnPropertyChanged();  } }
        private string _DIACHI;
        public string DIACHI { get { return _DIACHI; } set { _DIACHI = value; OnPropertyChanged();  } }
        private string _SDT;
        public string SDT { get { return _SDT; } set { _SDT = value; OnPropertyChanged();  } }
        private string _EMAIL;
        public string EMAIL { get { return _EMAIL; } set { _EMAIL = value; OnPropertyChanged();  } }
        private string _SOCCCD;
        public string SOCCCD { get { return _SOCCCD; } set { _SOCCCD = value; OnPropertyChanged(); } }
        private string _QUOCTICH;
        public string QUOCTICH { get { return _QUOCTICH; } set { _QUOCTICH = value; OnPropertyChanged();  } }
        //private ObservableCollection<CTPDV1> _ListCTPDV1;
        //public ObservableCollection<CTPDV1> ListCTPDV1 { get { return _ListCTPDV1; } set { _ListCTPDV1 = value; OnPropertyChanged(); } }
        //private ObservableCollection<CHITIETDICHVU> _ListCTPDV;
        //public ObservableCollection<CHITIETDICHVU> ListCTPDV { get { return _ListCTPDV; } set { _ListCTPDV = value; OnPropertyChanged(); } }
        //private ObservableCollection<DICHVU> _ListDV;
        //public ObservableCollection<DICHVU> ListDV { get { return _ListDV; } set { _ListDV = value; OnPropertyChanged(); } }

        //public ICommand ShowCommand { get; set; }

        public InfoViewModel()
        {
            InitializeTimer();
            //ListCTPDV1 = new ObservableCollection<CTPDV1>();
            //ListCTPDV = new ObservableCollection<CHITIETDICHVU>(DataProvider.Ins.DB.CHITIETDICHVUs);
            //ListDV = new ObservableCollection<DICHVU>(DataProvider.Ins.DB.DICHVUs);
            //ShowCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            //{
            //    MessageBox.Show(MAPDV);
            //    foreach (var ctpdv in ListCTPDV)
            //    {
            //        if (ctpdv.MAPDV == MAPDV)
            //            ListCTPDV1.Add(new CTPDV1 { MAPDV = ctpdv.MAPDV, MADV = ctpdv.MADV, SLDV = ctpdv.SLDV, GIA = ctpdv.GIA, TENDV = null });
            //    }
            //    foreach (var ctpdv1 in ListCTPDV1)
            //    {
            //        foreach (var dv in ListDV)
            //        {
            //            if (dv.MADV == ctpdv1.MADV)
            //            {
            //                ctpdv1.TENDV = dv.TENDV;
            //                break;
            //            }
            //        }
            //    }
            //});

        }
    }
}
