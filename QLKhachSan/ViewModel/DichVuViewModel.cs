using QLKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QLKhachSan.ViewModel.BasicViewModel;
using System.Windows.Input;

namespace QLKhachSan.ViewModel
{
    public class DichVuViewModel : BasicViewModel
    {
        private ObservableCollection<DICHVU> _ListDV;
        public ObservableCollection<DICHVU> ListDV { get { return _ListDV; } set { _ListDV = value; OnPropertyChanged(); } }
        private DICHVU _SelectedItem;
        public DICHVU SelectedItem
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
                    MADV = SelectedItem.MADV;
                    TENDV = SelectedItem.TENDV;
                    DONGIA = SelectedItem.DONGIA;
                }
            }
        }
        private string _MADV;
        public string MADV { get { return _MADV; } set { _MADV = value; OnPropertyChanged(); } }
        private string _TENDV;
        public string TENDV { get { return _TENDV; } set { _TENDV = value; OnPropertyChanged(); } }
        private decimal? _DONGIA;
        public decimal? DONGIA { get { return _DONGIA; } set { _DONGIA = value; OnPropertyChanged(); } }
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public DichVuViewModel()
        {
            ListDV = new ObservableCollection<DICHVU>(DataProvider.Ins.DB.DICHVUs);
            AddCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(MADV))
                    return false;
                var TenDVlist = DataProvider.Ins.DB.DICHVUs.Where(x => x.MADV == MADV);
                if (TenDVlist == null || TenDVlist.Count() != 0)
                    return false;
                return true;
            }, (p) =>
            {
                var dichvu = new DICHVU() { MADV = MADV, TENDV = TENDV, DONGIA = DONGIA, };
                DataProvider.Ins.DB.DICHVUs.Add(dichvu);
                DataProvider.Ins.DB.SaveChanges();

                ListDV.Add(dichvu);
            });
            EditCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(MADV) || SelectedItem == null)
                    return false;
                var MaDVlist = DataProvider.Ins.DB.DICHVUs.Where(x => x.MADV == SelectedItem.MADV);
                if (MaDVlist == null || MaDVlist.Count() == 0)
                    return false;
                return true;
            }, (p) =>
            {
                var dichvu = DataProvider.Ins.DB.DICHVUs.Where(x => x.MADV == SelectedItem.MADV).SingleOrDefault();
                dichvu.TENDV = TENDV;
                dichvu.DONGIA = DONGIA;
                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.MADV = MADV;
            });
        }
    }
}
