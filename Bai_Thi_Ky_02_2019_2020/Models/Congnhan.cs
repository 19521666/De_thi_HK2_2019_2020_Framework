using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bai_Thi_Ky_02_2019_2020.Models
{
    public  class Congnhan
    {

        [Key]

        [StringLength(10, ErrorMessage = "Mã công nhân < 10 kí tự")]
        [Display(Name = "Mã công nhân ")]
        public string MaCongNhan { get; set; }

        [StringLength(30, ErrorMessage = "Tên  công nhân < 30 kí tự")]
        [Display(Name = "Tên công nhân ")]
        public string TenCongNhan { get; set; }

        [Display(Name = "Giới tính")]
        public bool? GioiTinh { get; set; }

        [Display(Name = "Năm sinh")]
        public int? NamSinh { get; set; }

        [StringLength(30, ErrorMessage = "Nước về  < 10 kí tự")]
        [Display(Name = "Nước về ")]
        public string NuocVe { get; set; }

        [StringLength(10, ErrorMessage = "Mã điểm cách ly< 10 kí tự")]
        [Display(Name = "Mã điểm cách ly ")]
        public string MaDiemCachLy { get; set; }
        [ForeignKey("MaDiemCachLy")]

        public  Diemcachly MaDiemCachLyNavigation { get; set; }
        public  ICollection<CnTc> CnTc { get; set; }
    }
}
