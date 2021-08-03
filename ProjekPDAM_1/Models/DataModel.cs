using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekPDAM_1.Models
{
    public class DataModel
    {
        public DateTime Tanggal { get; set; }
        public string Komponen { get; set; }
        public string Keterangan { get; set; }

        public string status { get; set; }
    }

    public class InstalasiPDAM
    {
        public string Instalasi { get; set; }

    }
    public class PeralatanPDAM
    {
        public string Peralatan { get; set; }
    }

    public class StatusPDAM
    {
        public string Status { get; set; }
    }
}
