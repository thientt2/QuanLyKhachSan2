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
    
    public partial class PHONG
    {
        public string SOPHONG { get; set; }
        public string MALOAI { get; set; }
        public Nullable<int> TANG { get; set; }
        public string TINHTRANG { get; set; }
        public string MAPDP { get; set; }
    
        public virtual LOAIPHONG LOAIPHONG { get; set; }
        public virtual PHIEUDATPHONG PHIEUDATPHONG { get; set; }
    }
}
