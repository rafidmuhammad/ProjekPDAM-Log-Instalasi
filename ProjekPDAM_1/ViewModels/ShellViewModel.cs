using Caliburn.Micro;
using ProjekPDAM_1.Models;
using System;
using System.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Linq;
using System.Globalization;
using System.IO;
using Microsoft.Win32;

namespace ProjekPDAM_1.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {   // list yang berisi semua nilai instalasi dan peralatan yang mungkin
        string[] instalasi = { "KM.12", "KM.8", "GN.Sari", "KP.Damai", "Teritip", "Prapatan", "Baru Ulu", "ZAM" };
        string[] peralatan = {"P. Dist. 1", "P. Dist. 2", "P. Dist. 3","P. Dist. 4", "Alat Ukur Air Bersih","Blower","LVMDP","Act. Valve Filter 1","Act. Valve Filter 2","Act. Valve Filter 3","C. Block R. Filter","C. Block R. Lagon",
                                     "Alat Ukur Air Baku", "Alarm PLN", "P. Transfer 1", "P. Transfer 2","P. Transfer 3","P. Transfer 4","Varable Speed", "P. Filter 1", "P. Filter 2","P. Filter 3","P. Filter 4", "Genset 1", "Genset 2","Sumur 2 ( MUI )","Sumur 3 ( Kopkar )","C. Block R. Dist.",
                                     "P. Saturasi 1", "P. Saturasi 2", "P. Saturasi 3","P. Saturasi 4","P. Saturasi 5","P. Saturasi 6", "Skimer 1", "Skimer 2","P. Air Service 1","P. Air Service 2","DP NAOCL 2","DP HCL","DP NAOCL 1","Blower Cuci Filter 1","Blower Cuci Filter 2",
                                     "Skimer 3","Skimer 4","Skimer 5","Skimer 6", "Cooling Tower 1", "Cooling Tower 2","Cooling Tower 3","Cooling Tower 4", "DP Kaporit 1", "DP Kaporit 2", "DP Soda As 1", "DP Soda As 2","DP Soda As 3", "DP Alum 1","P. Back Wash","DP NAOCL Injeksi 1","DP NAOCL Injeksi 2","DP NAOCL Injeksi 3",
                                     "P. Drainase R. PAB","DP Alum 2", "Mixer Kaporit 1", "Mixer Soda As", "Mixer Alum", "Sumur 1", "Sumur 2","Vessel 1", "Vessel 2", "Vessel 3", "PAB 1","PAB 2","PAB 3", "Vessel Inst.Mini","Comp. 1","Comp. 2","Act Back Wash Filter 1-6",
                               "C. Block R. P. House Ints. Mini","Panel LVMDP", "C. Block R. DAF Ints. Mini","C. Block R. Chemical Ints. Mini", "C. Block R. Chlor Ints. Mini","C. Block R. Intake Ints. Mini","Act 1-5 DMI filter","Blower Kaporit",
                                "P. Drainase P. House 1","DP Soda As 1 inst. Mini","DP Soda As 2 inst. Mini","DP Alum 1 inst. Mini","DP Alum 2 inst. Mini","DP Kaporit 1 inst. mini","DP Kaporit 2 inst. Mini","Act 1-5 Disc filter",
        "P. Dist. 1 Inst. Mini","P. Dist. 2 Inst. Mini","P. Dist. 3 Inst. Mini","P. Intake 1 Inst. Mini","P. Intake 2 Inst. Mini","P. Intake 3 Inst. Mini","PAB 4","PAB 5","P. Drainase P. House 2","Act Wash Out DAF 1 Ints. Mini","Act Cuci Filter 1-6",
        "Act Inlet Daf 1 Ints. Mini","Act Back Wash DAF 1 Ints. Mini","Act Cuci Filter DAF 1","Act Wash Out DAF 2 Ints. Mini","Act Inlet Daf 2 Ints. Mini","Act Back Wash DAF 2 Ints. Mini","Act Cuci Filter DAF 2","SCADA"
        ,"Travo 1","Travo 2","Travo 3","Travo Step Down 660-380 V","Travo Ints. Mini","Cubicle Switch Ints. Mini","PAB 6","C. Block P. House 2","P. Saturasi 1 Inst. Mini","P. Saturasi 2 Inst. Mini","Act 1-4 Ultra filter","Act Drain Filter 1-6",
        "P. Saturasi 3 Inst. Mini","P. Saturasi 4 Inst. Mini","Travo step down R. LVMDP","ACB Travo 1 LVMDP 1","ACB Travo 2 LVMDP 1","Breaker ACB PAB 1-6 LVMDP 1","Change Switch LVMDP 2","Change Swith Ints. Mini","A. Ukur Air Produksi","Act Outlet Filter 1-6",
        "ACB Utama Ints. Mini","ACB Travo 3 LVMDP 2","Breaker ACB PAB 7-9 LVMDP 2","PAB 7","P. Drainase P. House 3","Skimer DAF 1 Inst. Mini","PAB 8","PAB 9","C. Block P. House 3","Comp. P. house 1","Comp. 1 Ints. Mini","Comp. 2 Ints. Mini",
        "Comp. vessel Ints. Mini","P. Chlor 1 Ints. Mini","P. Chlor 2 Ints. Mini","Lemari Chlor 1 Ints. Mini","Lemari Chlor 2 Ints. Mini","Timangan Chlor Ints. Mini","Safety Chlor Ints. Mini","P. Cuci Filter 1","P. Cuci Filter 2","Act Inlet Filter 1-6",
        "Air Dryer Comp. 1 Ints. Mini","Air Dryer Comp. 2 Ints. Mini","A. Ukur Mag. Flow P. House 2","A. Ukur Mag. Flow P. House 3","A. Ukur Air Dist. Inst. Mini","A. Ukur Air Baku Inst. Mini","A. Ukur Back Wash Inst. Mini","Pembersihan",
        "C. Block P. House","C. Block R. Chlor 1","C. Block R. Chlor 2","C. Block R. Chemical 1","C. Block R. Chemical 2","C. Block Lagon","IPA 1","IPA 2","DP Kapur 1","DP Kapur 2","DP Kapur 3","DP Kapur 4", "DP Kaporit 3","P. Dist. 5", "Mixer Kaporit 2"
        , "Mixer Kapur 1", "Mixer Kapur 2", "Mixer Saturator","Act Cleator 1 1-6","Act Cleator 2 1-6","Act Cleator 3 1-6","Act Cleator 4 1-6","Lime Sleaker 1","Lime Sleaker 2","Act Valve R. Galery 1-21","Act. Pintu Filter 1-7","Act Pipa Pembuangan 1-7",
        "Act. R. Lagon","BCF 1","BCF 2","PCF 1","PCF 2","Change Switch R. LVMDP","Breaker ACB R. LVMDP","Blower Alum 1","Blower Alum 2","P. Lagon 1","P. Lagon 2","P. Lagon 3","P. Lagon 4","P. Air Baku Lagon","P. Drainase P. House",
        "P. Drainase A. Ukur Dist.","P. Drainase R. IPA","DP Alum 3","Comp. Lagon","Comp. 1 Cleator","Comp. 2 Cleator","Comp. 3 Cleator","A. Ukur Air Dist.","A. Ukur Lagon","A. Ukur IPA","Pembersihan","Change Switch","Capasitor Bank","Comp.","Electro valve 1-4","A. Ukur P. Transfer","A. Ukur P. Dist.",
        "P. Drainase R. Dist.","Panel Hubung Bagi R. PAB","Act B. Lumpur 1","Act B. Lumpur 2","Act B. Lumpur 3","Act B. Lumpur 4","Breaker ACB Travo 1","Breaker ACB Travo 2","Lime Sleaker","Sumur Kp. Damai 2","Sumur Terminal Tangki","Sumur Penggalang","Sumur Bukit Cinta","P. 6000 R. P. House",
        "Blower Pulsator 1","Blower Pulsator 2","Comp. 1 Vessel","Comp. 2 Vessel","Comp. Pullsator 1","Comp. Pullsator 2","A. Ukur Mag. Sumur 1-5","A. Ukur Mag. Air Baku pipa 400","A. Ukur Mag. Air Baku pipa 500","A. Ukur Mag. Backwash","A. Ukur Mag. Galery 1-6","A. Ukur Mag. Air Dist. pipa 500",
        "A. Ukur Mag. Air Dist. pipa 400","A. Ukur Mag. IPA","Breaker ACB PLN","Breaker ACB Genset","Sumur Gn. Sari 1","Sumur Gn. Sari 2","Sumur Gn. Malang","Sumur Gn. Sari 3","Sumur Gn. Sari 4","Sumur Martadinata","A. Ukur DAF 1","A. Ukur DAF 2",
        "A. Ukur Sumur 1","A. Ukur Sumur 2","A. Ukur Sumur 3","A. Ukur Sumur 4","A. Ukur Sumur 5","A. Ukur Sumur 6","A. Ukur Sumur 7","A. Ukur Sumur 8" 
};
        
        
        
        string[] status = { "", "NORMAL", "ABNORMAL" }; //nilai status yang mungkin

        public ShellViewModel()
        {
            for (int i = 0; i < 8; i++)
            {
                Install.Add(new InstalasiPDAM { Instalasi = instalasi[i] }); //memasukkan nilai instalasi dari list di atas ke penampung
            }
            Array.Sort(peralatan,StringComparer.InvariantCulture);

            for (int i = 0; i < peralatan.Length; i++)
            {
                Alat.Add(new PeralatanPDAM { Peralatan = peralatan[i] }); //memasukkan nilai peralatan dari list di atas ke penampung
            }


            for (int i = 0; i < 3; i++)
            {
                Stat.Add(new StatusPDAM { Status = status[i] }); //memasukkan nilai status dari list di atas ke penampung
            }
            ViewData = CollectionViewSource.GetDefaultView(Data); //meng-assign nilai viewdata yang digunakan pada datagrid dari nilai view dari data


        }



        private string _tanggal = string.Empty;

        public string Tanggal //terhubung langsung dengan textfield tanggal pada view
        {
            get { return _tanggal; }
            set
            {
                _tanggal = value;
                NotifyOfPropertyChange(() => Tanggal); //memberitahukan jika adanya perubahan data pada textfield tanggal
            }
        }

        private string _komponen = string.Empty;

        public string Komponen //terhubung langsung dengan textfield komponen pada view
        {
            get { return _komponen; }
            set
            {
                _komponen = value;
                NotifyOfPropertyChange(() => Komponen); //memberitahukan jika adanya perubahan data pada textfield komponen
            }
        }

        private string _keterangan = string.Empty;

        public string Keterangan //terhubung langsung dengan textfield keterangan pada view
        {
            get { return _keterangan; }
            set
            {
                _keterangan = value;
                NotifyOfPropertyChange(() => Keterangan); //memberitahukan jika adanya perubahan data pada textfield keterangan
            }
        }

        private InstalasiPDAM _selectedInstall; //menyimpan pilihan dari combobox view 

        public InstalasiPDAM SelectedInstall
        {
            get { return _selectedInstall; }
            set
            {
                _selectedInstall = value;
                NotifyOfPropertyChange(() => SelectedInstall); //memberithaunkan jika nilai yang dipilih berubah ke variabel sendiri
                NotifyOfPropertyChange(() => NamaFile);    //memberitahukan jika nilai yang dipilih berubah ke nama file
            }   
        }

        private PeralatanPDAM _selectedAlat; //menyimpan pilihan dari combobox view 

        public PeralatanPDAM SelectedAlat
        {
            get { return _selectedAlat; }
            set
            {
                _selectedAlat = value;
                NotifyOfPropertyChange(() => SelectedAlat); //memberithaunkan jika nilai yang dipilih berubah ke variabel sendiri
                NotifyOfPropertyChange(() => NamaFile);  //memberitahukan jika nilai yang dipilih berubah ke nama file
            }
        }

        private DataModel _selectedData; //menampung nilai terpilih dari data grid membantu pada fitur delete

        public DataModel SelectedData
        {
            get { return _selectedData; }
            set
            {
                _selectedData = value;
                NotifyOfPropertyChange(() => SelectedData);
            }
        }

        private StatusPDAM _selectedStat; // menampung nilai yang dipilih dari combobox status

        public StatusPDAM SelectedStat
        {
            get { return _selectedStat; }
            set
            {
                _selectedStat = value;
                NotifyOfPropertyChange(() => SelectedStat);
            }
        }

        public String NamaFile => $"{SelectedInstall?.Instalasi}.xlsx"; //terhubung langsung dengan view menampilkan nama file 

        private BindableCollection<InstalasiPDAM> _install = new BindableCollection<InstalasiPDAM>();

        public BindableCollection<InstalasiPDAM> Install //menampung list instalasi
        {
            get { return _install; }
            set { _install = value; }
        }

        private BindableCollection<PeralatanPDAM> _alat = new BindableCollection<PeralatanPDAM>();

        public BindableCollection<PeralatanPDAM> Alat //menampung list peralatan
        {
            get { return _alat; }
            set { _alat = value; }
        }


        private BindableCollection<DataModel> _data = new BindableCollection<DataModel>();

        public BindableCollection<DataModel> Data //menampung data {tanggal , komponen, keternagan, status}
        {
            get { return _data; }
            set
            {
                _data = value;
                NotifyOfPropertyChange(() => Data);
            }
        }

        private BindableCollection<StatusPDAM> _stat = new BindableCollection<StatusPDAM>();

        public BindableCollection<StatusPDAM> Stat //menampung status
        {
            get { return _stat; }
            set { _stat = value; }
        }

        private List<string[]> _titles = new List<string[]> {new string[] {"Tanggal", "Komponen", "Keterangan"} };

        public List<string[]> Titles
        {
            get { return _titles; }
            set { _titles = value; }
        }

        

        //view untuk dihubungkan langsung ke data grid
        private ICollectionView _viewData;

        public ICollectionView  ViewData
        {
            get 
            { 
                return _viewData; 
            }
            set
            {
                _viewData = value;
                NotifyOfPropertyChange(() => ViewData);
            }
        }


        //untuk memberi tanda apakah dapat menghapus data pada text field
        public bool CanClearText(string tanggal, string komponen, string keterangan)
        {
            return !String.IsNullOrWhiteSpace(tanggal) || !String.IsNullOrWhiteSpace(komponen) || !String.IsNullOrWhiteSpace(keterangan);
        }

        //menghapus data pada text field
        public void ClearText(string tanggal, string komponen, string keterangan)
        {
            Tanggal = "";
            Komponen = "";
            Keterangan = "";
        }

        //untuk memberi tanda apakah dapat menambah data
        public bool CanAddData(string tanggal, string komponen, string keterangan)
        {
            return !String.IsNullOrWhiteSpace(tanggal) && !String.IsNullOrWhiteSpace(komponen) && !String.IsNullOrWhiteSpace(keterangan);
        }

        //perintah untuk menambah data
        public void AddData(string tanggal, string komponen, string keterangan)
        {
            DataModel tempAdd = new DataModel();
            DateTime d;
            var formatstring = new string[] { "dd/MM/yyyy", "d/M/yyyy" }; //dapat memberikan masukan tanggal dengan dua format
            if (DateTime.TryParseExact(tanggal, formatstring, CultureInfo.InvariantCulture, DateTimeStyles.None, out d)) //melakukan pengecekan format
            {
                //assignment data
                tempAdd.Tanggal = d;
                tempAdd.Komponen = komponen;
                tempAdd.Keterangan = keterangan;
                tempAdd.status = SelectedStat?.Status;
                Data.Add(tempAdd); //menambahkan data
                NotifyOfPropertyChange(() => Data); //memberitahukan jika data bertambah
            }
            else
            {
                MessageBox.Show("Tanggal Salah!"); //pesan jika tanggal salah format
            }
        }


        public void DeleteData() //untuk menghapus data
        {
            Data.Remove(SelectedData);
            NotifyOfPropertyChange(() => Data);
        }
        
        public bool CanSearchData(string keterangan) //untuk memberik tanda apakah dapat mencari data
        {
            return !String.IsNullOrWhiteSpace(keterangan);
        }
        
        public void SearchData(string keterangan) //untuk melakukan pencarian data
        {
            ViewData.Filter = FilterData;
            ViewData.Refresh();
        }


        public void RefreshData() //untuk mengembalikan tampilan data grid dengan kondisi data sekarang
        {
            ViewData.Filter = null;
        }
        
        private bool FilterData(object obj) //untuk melakukan filtering (search)
        {
            if(obj is DataModel dataModel)
            {
                return dataModel.Keterangan.ToLower().Contains(Keterangan.ToLower()); //mencari nilai yang match pada kolom keterangan
            }

            return false;
        }

        public void OpenData() //membuka data dari file excel sesuai dengan instalasi yang dipilih
        {
            Data.Clear();
            DataTable dt = new DataTable();
            if (String.Compare(NamaFile, "-.xlsx") != 0 && SelectedAlat?.Peralatan != null && SelectedInstall?.Instalasi != null) //pengecekan adanya file, adanya instalasi dan peralatan yang dipilih 
            {
                try 
                { 
                        using (XLWorkbook workbook = new XLWorkbook(NamaFile))
                        {
                            bool isFirstRow = true;
                        
                            var rows = workbook.Worksheet(SelectedAlat?.Peralatan).RowsUsed();
                        foreach (var row in rows)
                            {
                                //adding columns ke data table
                                if (isFirstRow)
                                {
                                    foreach (IXLCell cell in row.Cells())
                                        dt.Columns.Add(cell.Value.ToString());
                                    isFirstRow = false;
                                }
                                else
                                {
                                    //menambahkan baris ke data table
                                    dt.Rows.Add();
                                    int i = 0;
                                    foreach (IXLCell cell in row.Cells())
                                        dt.Rows[dt.Rows.Count - 1][i++] = cell.Value.ToString();
                                }
                            }
                            //memindahkan data dari datatable ke list
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                DataModel temp = new DataModel();
                                temp.Tanggal = Convert.ToDateTime(dt.Rows[i]["Tanggal"].ToString());
                                temp.Komponen = dt.Rows[i]["Peralatan"].ToString();
                                temp.Keterangan = dt.Rows[i]["Keterangan"].ToString();
                                temp.status = dt.Rows[i]["Status"].ToString();
                                Data.Add(temp);
                            }
                        }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("File tidak ditemukan atau file terkait sedang dibuka!");
                }

        }
            else
            {
                MessageBox.Show("Pilih \'Instalasi\' dan \'Peralatan\' terlebih dahulu!");
            }
        }


        public void SaveData() //menyimpan data
        {
            try 
            { 
                    var dataTable = new DataTable();
                    dataTable.Columns.Add("Tanggal");
                    dataTable.Columns.Add("Peralatan");
                    dataTable.Columns.Add("Keterangan");
                    dataTable.Columns.Add("Status");

                    foreach (var element in Data) //menambahkan setiap baris yang ada pada 'Data' ke datatable
                    {

                        dataTable.Rows.Add(element.Tanggal, element.Komponen, element.Keterangan, element.status);
                    }


                    using (XLWorkbook workbook = new XLWorkbook(NamaFile)) // dari datatable ke worksheet
                    {
                    try
                    {
                        workbook.Worksheets.Delete(SelectedAlat?.Peralatan); //menghapus worksheet dahulu
                        workbook.Worksheets.Add(dataTable, SelectedAlat?.Peralatan).Style.Alignment.WrapText = true; //menambahkan data ke worksheet
                        workbook.Save(); //menyimpan worksheet
                    }
                    catch //jika tidak ada worksheet
                    {
                        workbook.Worksheets.Add(SelectedAlat?.Peralatan);  //membuat worksheet baru
                        workbook.Save(); //menyimpan worksheet
                        MessageBox.Show("Sheet terkait sudah dibuat! Ulangi Penambahan Data!");
                    }
                    }
                    MessageBox.Show("Success!");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Pilih \'Instalasi\' dan \'Peralatan\' terlebih dahulu! atau File terkait tidak ada!");
            }

        }
        
    }
}
