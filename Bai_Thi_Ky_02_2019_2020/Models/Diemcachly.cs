using System;
using System.Collections.Generic;


namespace Bai_Thi_Ky_02_2019_2020.Models
{
    public partial class Diemcachly
    {

      
        public string Madiemcachly { get; set; }
        public string Tendiemcachly { get; set; }
        public string Diachi { get; set; }
        public  ICollection<Congnhan> Congnhans{ get; set; }
    }
}
