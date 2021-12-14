using System;
using System.Collections.Generic;


namespace Bai_Thi_Ky_02_2019_2020.Models
{
    public  class Congnhan
    {

        
        public string MaCongNhan { get; set; }
        public string TenCongNhan { get; set; }
        public bool GioiTinh { get; set; }
        public int NamSinh { get; set; }
        public string NuocVe { get; set; }
        public string MaDiemCachLy { get; set; }
        public  Diemcachly diemcachly { get; set; }
        public  ICollection<CnTc> CnTcs { get; set; }
    }
}
