using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CongQuanLyDoAn_ThucTap.Areas.Giangvien.Models
{
    public class Gv_LoginModel
    {
        [Required(ErrorMessage = "Mời nhập mã giảng viên")]
        public string MaGV { get; set; }

        [Required(ErrorMessage = "Mời nhập Mật Khẩu")]
        public string Matkhau { get; set; }

        public bool RememberMe { get; set; }
    }
}