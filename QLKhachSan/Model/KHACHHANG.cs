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
    
    public partial class KHACHHANG :BasicViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            this.PHIEUDATPHONGs = new HashSet<PHIEUDATPHONG>();
        }

        private string _MAKH;
        public string MAKH { get { return _MAKH; } set { _MAKH = value; OnPropertyChanged(); } }
        private string _TENKH;
        public string TENKH { get { return _TENKH; } set { _TENKH = value; OnPropertyChanged(); } }
        private string _GIOITINH;
        public string GIOITINH { get { return _GIOITINH; } set { _GIOITINH = value; OnPropertyChanged(); } }
        private string _DIACHI;
        public string DIACHI { get { return _DIACHI; } set { _DIACHI = value; OnPropertyChanged(); } }
        private string _SDT;
        public string SDT { get { return _SDT; } set { _SDT = value; OnPropertyChanged(); } }

        private string _EMAIL;
        public string EMAIL { get { return _EMAIL; } set { _EMAIL = value; OnPropertyChanged(); } }

        private string _SOCCCD;
        public string SOCCCD { get { return _SOCCCD; } set { _SOCCCD = value; OnPropertyChanged(); } }

        private string _QUOCTICH;
        public string QUOCTICH { get { return _QUOCTICH; } set { _QUOCTICH = value; OnPropertyChanged(); } }

        private DateTime? _NGSINH;
        public DateTime? NGSINH { get { return _NGSINH; } set { _NGSINH = value; OnPropertyChanged(); } }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUDATPHONG> PHIEUDATPHONGs { get; set; }
    }
}
