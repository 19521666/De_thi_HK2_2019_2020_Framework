using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Bai_Thi_Ky_02_2019_2020.Models
{
    public partial class Diemcachly
    {
        public Diemcachly()
        {
            Congnhan = new HashSet<Congnhan>();
        }

        public string Madiemcachly { get; set; }
        public string Tendiemcachly { get; set; }
        public string Diachi { get; set; }

        public virtual ICollection<Congnhan> Congnhan { get; set; }
    }
}
