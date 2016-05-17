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

namespace ASCII_Tab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //声明一个泛型集合
            //List<string> my_ascii=new List<string>();
            string context= File.ReadAllText(@"E:\ASCIII.txt",Encoding.Unicode );
            int num = 5;
            
            string[] strs={"\t","\r\n"};
            string[] my_ascii = context.Split(strs, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < my_ascii.Length / num; i++)
            {
                string[] row = { my_ascii[i * num], my_ascii[i * num + 1], my_ascii[i * num + 2], my_ascii[i * num + 3], my_ascii[i * num + 4] };
                dataGridView1.Rows.Add(row);
            }
            //dataGridView1.Rows.Add(my_ascii.Length / num);
            //dataGridView1.Rows.AddCopies(0, my_ascii.Length / num);
                
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
        }
    }
}
