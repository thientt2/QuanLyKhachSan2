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
    using System;
    using System.Collections.Generic;
    
    public partial class LOAIPHONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAIPHONG()
        {
            this.PHONGs = new HashSet<PHONG>();
        }
    
        public string MALOAI { get; set; }
        public Nullable<int> SLGIUONG { get; set; }
        public string LOAIGIUONG { get; set; }
        public Nullable<decimal> GIA { get; set; }
        public Nullable<int> NGUOITOIDA { get; set; }
        public Nullable<double> DIENTICH { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHONG> PHONGs { get; set; }
    }
}
