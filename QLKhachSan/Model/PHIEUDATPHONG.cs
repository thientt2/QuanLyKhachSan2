//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLKhachSan.Model
{
    using QLKhachSan.ViewModel;
    using System;
    using System.Collections.Generic;
    
    public partial class PHIEUDATPHONG:BasicViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUDATPHONG()
        {
            this.CTPDPs = new HashSet<CTPDP>();
            this.HOADONs = new HashSet<HOADON>();
            this.PHIEUDICHVUs = new HashSet<PHIEUDICHVU>();
        }

        private string _MAPDP;
        public string MAPDP { get { return _MAPDP; } set { _MAPDP = value; OnPropertyChanged(); } }
        private string _MAKH;
        public string MAKH { get { return _MAKH; } set { _MAKH = value; OnPropertyChanged(); } }
        private string _MANV;
        public string MANV { get { return _MANV; } set { _MANV = value; OnPropertyChanged(); } }
        private DateTime? _NGDAT;
        public DateTime? NGDAT { get { return _NGDAT; } set { _NGDAT = value; OnPropertyChanged(); } }
        private DateTime? _NGNHAN;
        public DateTime? NGNHAN { get { return _NGNHAN; } set { _NGNHAN = value; OnPropertyChanged(); } }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPDP> CTPDPs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }
        public virtual KHACHHANG KHACHHANG { get; set; }
        public virtual NHANVIEN NHANVIEN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUDICHVU> PHIEUDICHVUs { get; set; }
    }
}
