//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class PHIEUDATPHONG
    {
        public string MAPHIEUDAT { get; set; }
        public string MAKH { get; set; }
        public string MANV { get; set; }
        public string MAPHONG { get; set; }
        public Nullable<System.DateTime> NGAYLAP { get; set; }
        public Nullable<System.DateTime> NGAYBD { get; set; }
        public Nullable<System.DateTime> NGAYKT { get; set; }
    
        public virtual KHACHHANG KHACHHANG { get; set; }
        public virtual NHANVIEN NHANVIEN { get; set; }
        public virtual PHONG PHONG { get; set; }
    }
}