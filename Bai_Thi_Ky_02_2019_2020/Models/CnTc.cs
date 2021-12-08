using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Bai_Thi_Ky_02_2019_2020.Models
{
    public partial class CnTc
    {
        public string MaCongNhan { get; set; }
        public string MaTrieuChung { get; set; }

        public virtual Congnhan MaCongNhanNavigation { get; set; }
        public virtual Trieuchung MaTrieuChungNavigation { get; set; }
    }
}
