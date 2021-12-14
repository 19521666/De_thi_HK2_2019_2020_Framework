using System;
using System.Collections.Generic;


namespace Bai_Thi_Ky_02_2019_2020.Models
{
    public class Trieuchung
    {

        public string MaTrieuChung { get; set; }

        public string TenTrieuChung { get; set; }

        public  ICollection<CnTc> CnTcs { get; set; }
    }
}
