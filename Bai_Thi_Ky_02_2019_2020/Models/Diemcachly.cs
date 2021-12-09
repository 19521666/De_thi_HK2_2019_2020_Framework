using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bai_Thi_Ky_02_2019_2020.Models
{
    public partial class Diemcachly
    {

        [Key]

        [StringLength(10, ErrorMessage = "Mã điểm cách ly< 10 kí tự")]
        [Display(Name = "Mã điểm cách ly")]
        public string Madiemcachly { get; set; }

        [StringLength(30, ErrorMessage = "Tên điểm cách ly < 30 kí tự")]
        [Display(Name = "Tên điểm cách ly")]


        public string Tendiemcachly { get; set; }

        [StringLength(40, ErrorMessage = "Địa chỉ  cách ly< 40 kí tự")]
        [Display(Name = "Địa chỉ  cách ly")]
        public string Diachi { get; set; }

        public  ICollection<Congnhan> Congnhan { get; set; }
    }
}
