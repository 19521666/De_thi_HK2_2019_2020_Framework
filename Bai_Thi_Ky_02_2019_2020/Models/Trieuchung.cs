using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Bai_Thi_Ky_02_2019_2020.Models
{
    public partial class Trieuchung
    {
        public Trieuchung()
        {
            CnTc = new HashSet<CnTc>();
        }

        public string MaTrieuChung { get; set; }
        public string TenTrieuChung { get; set; }

        public virtual ICollection<CnTc> CnTc { get; set; }
    }
}
