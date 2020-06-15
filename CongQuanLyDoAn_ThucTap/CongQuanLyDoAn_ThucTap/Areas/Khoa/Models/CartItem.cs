using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CongQuanLyDoAn_ThucTap.Areas.Khoa.Models
{
    [Serializable]
    public class CartItem
    {
        public SinhVien SinhVien { get; set; }
        public Nhom_DA_TT Nhom_DA_TT { get; set; }
        public int Quantity { get; set; }
    }
}