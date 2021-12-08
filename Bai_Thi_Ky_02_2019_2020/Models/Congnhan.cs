using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Bai_Thi_Ky_02_2019_2020.Models
{
    public partial class Congnhan
    {
        public Congnhan()
        {
            CnTc = new HashSet<CnTc>();
        }

        public string MaCongNhan { get; set; }
        public string TenCongNhan { get; set; }
        public bool? GioiTinh { get; set; }
        public int? NamSinh { get; set; }
        public string NuocVe { get; set; }
        public string MaDiemCachLy { get; set; }

        public virtual Diemcachly MaDiemCachLyNavigation { get; set; }
        public virtual ICollection<CnTc> CnTc { get; set; }
    }
}
