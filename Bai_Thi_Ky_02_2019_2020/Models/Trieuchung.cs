using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Bai_Thi_Ky_02_2019_2020.Models
{
    public class Trieuchung
    {

        [Key]

        [StringLength(10, ErrorMessage = "Mã triệu chứng < 10 kí tự")]
        [Display(Name = "Mã triệu chứng ")]
        public string MaTrieuChung { get; set; }

        [StringLength(30, ErrorMessage = "Tên triệu chứng < 30 kí tự")]
        [Display(Name = "Tên triệu chứng ")]
        public string TenTrieuChung { get; set; }

        public  ICollection<CnTc> CnTc { get; set; }
    }
}
