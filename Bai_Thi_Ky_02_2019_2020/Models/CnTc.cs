using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bai_Thi_Ky_02_2019_2020.Models
{
    public  class CnTc


    {
        [Display(Name = "Mã công nhân")]
        [StringLength(10, ErrorMessage = "Mã công nhân < 10 kí tự")]
        public string MaCongNhan { get; set; }
        [ForeignKey("MaCongNhan")]

        [Display(Name = "Mã triệu chứng")]
        [StringLength(10, ErrorMessage = "Mã triệu chứng < 10 kí tự")]
        public string MaTrieuChung { get; set; }
        [ForeignKey("MaTrieuChung")]

        public  Congnhan MaCongNhanNavigation { get; set; }
        public  Trieuchung MaTrieuChungNavigation { get; set; }
    }
}
