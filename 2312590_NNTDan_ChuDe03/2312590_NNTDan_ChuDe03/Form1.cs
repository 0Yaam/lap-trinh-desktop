using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace _2312590_NNTDan_ChuDe03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void WriteReadText(string filename, string[]text)
        {
            File.WriteAllLines(filename, text);
            foreach(string s in File.ReadAllLines(filename))
            {
                Console.WriteLine(s);
            }
            Console.ReadLine();
        }

        private void btnDocFile_Click(object sender, EventArgs e)
        {
            string Str = "";
            string Path = "../../students.json";
            List<SinhVien> List = LoadJSON(Path);

            for(int i = 0;i<List.Count; i++)
            {
                SinhVien sv = List[i];
                Str += string.Format("Sinh viên {0} có MSSV: {1}, họ tên: {2}," + "điểm TB: {3}\r\n", (i + 1), sv.MSSV, sv.HoTen, sv.Diem);
            }
            MessageBox.Show(Str);
        }

        private List<SinhVien> LoadJSON(string path) {
            List<SinhVien> list = new List<SinhVien>();

            StreamReader r = new StreamReader(path);

            string json = r.ReadToEnd();

            var array = (JObject)JsonConvert.DeserializeObject(json);

            var students = array["sinhvien"].Children();
            foreach(var student in students)
            {
                string mssv = student["MSSV"].Value<string>();
                string hoten = student["hoten"].Value<string>();
                int tuoi = student["tuoi"].Value<int>();
                double diem = student["diem"].Value<double>();
                bool tongiao = student["tongiao"].Value<bool>();

                SinhVien sv = new SinhVien(mssv, hoten, tuoi, diem,tongiao);
                list.Add(sv);

            }
            return list;
        }

    }
}
