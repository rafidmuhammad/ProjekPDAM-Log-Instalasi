using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekPDAM_1.Models //menggambarkan bagaimana data disimpan 
{                             // digunakan cara pandang berorientasi objek
    public class DataModel
    {
        public DateTime Tanggal { get; set; } //menyimpan tanggal
        public string Komponen { get; set; } //menyimpan komponen
        public string Keterangan { get; set; } // menyimpan keterangan

        public string status { get; set; } //menyimpan nilai status hasi pemilihan combobox
    }

    public class InstalasiPDAM
    {
        public string Instalasi { get; set; } //sebagai tipe yang akan menyimpan list instalasi nantinya

    }
    public class PeralatanPDAM
    {
        public string Peralatan { get; set; } //sebagai tipe yang akan menyimpan list peralatan nantinya
    }

    public class StatusPDAM
    {
        public string Status { get; set; } //sebagai tipe yang akan menyimpan list status nantinya
    }
}
