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
    
    public partial class CHITIETHOADON
    {
        public string MAHD { get; set; }
        public string MADV { get; set; }
        public Nullable<int> SOLUONG { get; set; }
    
        public virtual DICHVU DICHVU { get; set; }
        public virtual HOADON HOADON { get; set; }
    }
}
