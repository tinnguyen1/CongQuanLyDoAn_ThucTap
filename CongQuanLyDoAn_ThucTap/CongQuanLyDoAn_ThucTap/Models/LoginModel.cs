using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CongQuanLyDoAn_ThucTap.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời nhập Mã sinh viên")]
        public int MaSV { get; set; }

        [Required(ErrorMessage = "Mời nhập Mật Khẩu")]
        public string Matkhau { get; set; }

        public bool RememberMe { get; set; }


    }
}