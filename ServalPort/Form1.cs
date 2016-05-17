using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace MySerialPort
{
    public partial class Form1 : Form
    {
        private static string receive_buff;
        private string Updata;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;        //激活跨线程调用控件

            Updata = "说明\r\n";
            Updata += "本作品只是个人学习C#串口开发的一个实验品\r\n";
            Updata += "不可避免的存在各类Bug，希望谅解\r\n";
            Updata += "更新内容：\r\n";
            Updata += "1、增加16进制发送\r\n";
            Updata += "2、增加16进制接收\r\n";
            Updata += "3、增加ASCII查询工具\r\n";


            label10.Font = new Font("宋体_GB2312", 14);
            label10.Text = Updata;
            label10.Visible = true;

            //固定窗体大小
            this.Size = new Size(640, 450);
            this.MaximumSize = new Size(640, 450);
            this.MinimumSize = new Size(640, 450);

            //初始化串口选项
            string[] ports = SerialPort.GetPortNames();
            if (ports.Length!=0)            //判断是否存在可用串口
            {
                foreach (var item in ports)
                {
                    this.comboBox1.Items.Add(item);
                }
                comboBox1.Text = comboBox1.Items[0].ToString();//默认串口
            }
            
            comboBox2.Text = comboBox2.Items[4].ToString();//默认波特率
            comboBox3.Text = comboBox3.Items[0].ToString();//默认数据位
            comboBox4.Text = comboBox4.Items[0].ToString();//默认停止位
            comboBox5.Text = comboBox5.Items[0].ToString();//默认校验位

            comboBox6.Text = comboBox6.Items[1].ToString();//默认发送格式
            comboBox7.Text = comboBox7.Items[1].ToString();//默认接收格式
            
            button2.BackColor = System.Drawing.Color.White;
            button2.ForeColor = System.Drawing.Color.DimGray;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (serialPort1.IsOpen == false)       //连接串口
            {
                serialPort1.Open();
                button1.Text = "已连接";
                button1.BackColor = System.Drawing.Color.GreenYellow;
                button1.ForeColor = System.Drawing.Color.Black;

                button2.BackColor = System.Drawing.Color.White;
                button2.ForeColor = System.Drawing.Color.Black;
            }
            else if (serialPort1.IsOpen == true)
            {
                serialPort1.Close();

                button1.Text = "已断开";
                button1.BackColor = System.Drawing.Color.White;
                button1.ForeColor = System.Drawing.Color.Black;

                button2.BackColor = System.Drawing.Color.White;
                button2.ForeColor = System.Drawing.Color.DimGray;
            } 

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            string formate = comboBox7.Text;
            switch (formate)
            {
                case "16进制":
                    byte[] data = Encoding.ASCII.GetBytes(textBox2.Text);
                    byte[] myhex = new byte[(data.Length+2)/3];
                    int mycounts = 0;
                    int j = 0;
                    for (int i = 0; i < data.Length; i++)
                    {
                        if (data[i] != 0x20)
                        {
                            data[i] = asctohex(data[i]);
                            myhex[j] = (byte)((myhex[j] << 4) + data[i]);
                            mycounts++;
                            Console.Write("A");
                        }
                        else if (data[i] == 0x20 && mycounts > 0)
                        {
                            j++;
                            mycounts = 0;
                            Console.Write("B");
                        }
                    }

                    string str1 = Encoding.ASCII.GetString(myhex);
                    str1.Substring(0, j);

                    if (serialPort1.IsOpen == true)
                    {
                        serialPort1.Write(str1);

                        textBox4.Text = (int.Parse(textBox4.Text) + str1.Length).ToString();
                    }
                    break;
                case "字符串":
                    byte[] data2 = Encoding.ASCII.GetBytes(textBox2.Text);
                    string str2 = Encoding.ASCII.GetString(data2);

                    if (str2.IndexOf("\\r\\n") >= 0)
                    {
                        int len = str2.Length - 4;
                        str2 = str2.Substring(0, len);
                        str2 = str2 + "\r\n";
                    }

                    if (serialPort1.IsOpen == true)
                    {
                        serialPort1.Write(str2);

                        textBox4.Text = (int.Parse(textBox4.Text) + str2.Length).ToString();
                    }
                    break;
                case "文件":
                    MessageBox.Show("暂时不支持该功能！", "系统提示");
                    break;
                default:
                    break;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private byte asctohex(byte mychar)
        {
            byte myhex=0x00;
            if (mychar >= 0x30 && mychar <= 0x39)
            {
                myhex = (byte)(mychar - 0x30);
            }
            else if (mychar >= 0x41 && mychar <= 0x5A)
            {
                myhex = (byte)(mychar - 0x41 + 0x0A);
            }
            else if (mychar >= 0x61 && mychar <= 0x7A)
            {
                myhex = (byte)(mychar - 0x61 + 0x0A);
            }
            return myhex;
        }

        private byte hextoasc(byte myhex)
        {
            byte myasc = 0;
            if (myhex >= 0 && myhex <= 9)
            {
                myasc = (byte)(myhex + 0x30);
            }
            else if (myhex >= 10 && myhex <= 15)
            {
                myasc = (byte)(myhex - 10 + 0x41);
            }
            return myasc;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();     //退出
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {//串口名
            serialPort1.PortName = comboBox1.Text;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {//波特率
            serialPort1.BaudRate =int.Parse( comboBox2.Text);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {//数据位
            string boxval = comboBox3.Text;
            switch (boxval)
            {
                case "8bit":
                    serialPort1.DataBits = 8;
                    break;
                case "7bit":
                    serialPort1.DataBits = 7;
                    break;
                case "6bit":
                    serialPort1.DataBits = 6;
                    break;
                case "5bit":
                    serialPort1.DataBits = 5;
                    break;
                default:
                    break;
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string boxval = comboBox4.Text;
            switch (boxval)
            { 
                case "0bit":
                    serialPort1.StopBits = System.IO.Ports.StopBits.None;
                    break;
                case "1bit":
                    serialPort1.StopBits = System.IO.Ports.StopBits.One;
                    break;
                case "1.5bit":
                    serialPort1.StopBits = System.IO.Ports.StopBits.OnePointFive;
                    break;
                case "2bit":
                    serialPort1.StopBits = System.IO.Ports.StopBits.Two;
                    break;
                default:
                    break;
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string boxval = comboBox5.Text;
            switch (boxval)
            {
                case "None":
                    serialPort1.Parity = System.IO.Ports.Parity.None;
                    break;
                case "Even":
                    serialPort1.Parity = System.IO.Ports.Parity.Even;
                    break;
                case "Odd":
                    serialPort1.Parity = System.IO.Ports.Parity.Odd;
                    break;
                case "Mark":
                    serialPort1.Parity = System.IO.Ports.Parity.Mark;
                    break;
                case "Space":
                    serialPort1.Parity = System.IO.Ports.Parity.Space;
                    break;
                default:
                    break;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string formate = comboBox6.Text;
            string rec;

            int len = 0;
            len = this.serialPort1.BytesToRead;

            rec = this.serialPort1.ReadExisting();
            receive_buff = receive_buff + rec;    //接收内容追加到缓冲区
            textBox3.Text = (int.Parse(textBox3.Text) + rec.Length).ToString();//显示接收计数
            
            if (serialPort1.IsOpen == true)
            {
                switch (formate)
                {
                    case "16进制":
                        byte[] data = Encoding.ASCII.GetBytes(receive_buff);
                        byte[] myhex = new byte[(data.Length)*3-1];
                        int j = 0;
                        for (int i = 0; i < data.Length; i++)
                        {
                            //Console.WriteLine(data[i]);
                            myhex[j] = (byte)((data[i] >> 4) & (byte)0x0F);//高四位
                            myhex[j] = hextoasc(myhex[j]);
                            //Console.WriteLine(myhex[j]);
                            myhex[j + 1] = (byte)((data[i]) & (byte)0x0F);//低四位
                            myhex[j+1] = hextoasc(myhex[j+1]);
                            //Console.WriteLine(myhex[j+1]);
                            if (j + 2 < (data.Length) * 3 - 1)
                            {
                                myhex[j + 2] = 0x20;                //空格
                                j = j + 3;
                            }
                        }
                        textBox1.Text = Encoding.ASCII.GetString(myhex);
                        //Console.WriteLine(textBox1.Text);
                        break;
                    case "字符串":
                        textBox1.Text = receive_buff;
                        break;
                    case "文件":
                        MessageBox.Show("暂时不支持该功能！", "系统提示");
                        break;
                    default:
                        break;
                }
                
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            receive_buff = null;        //缓冲区清空
            textBox1.Text = "";         //接收内容清空
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";         //发送内容清空
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Text = "0";//计数清空
            textBox4.Text = "0";//计数清空
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            string formate = comboBox6.Text;
            switch (formate)
            {
                case "16进制":
                    if (receive_buff==null)  return;
                    byte[] data = Encoding.ASCII.GetBytes(receive_buff);
                    byte[] myhex = new byte[(data.Length) * 3 - 1];
                    int j = 0;
                    for (int i = 0; i < data.Length; i++)
                    {
                        //Console.WriteLine(data[i]);
                        myhex[j] = (byte)((data[i] >> 4) & (byte)0x0F);//高四位
                        myhex[j] = hextoasc(myhex[j]);
                        //Console.WriteLine(myhex[j]);
                        myhex[j + 1] = (byte)((data[i]) & (byte)0x0F);//低四位
                        myhex[j + 1] = hextoasc(myhex[j + 1]);
                        //Console.WriteLine(myhex[j+1]);
                        if (j + 2 < (data.Length) * 3 - 1)
                        {
                            myhex[j + 2] = 0x20;                //空格
                            j = j + 3;
                        }
                    }
                    textBox1.Text = Encoding.ASCII.GetString(myhex);
                    //Console.WriteLine(textBox1.Text);
                    break;
                case "字符串":
                    textBox1.Text = receive_buff;
                    break;
                case "文件":
                    MessageBox.Show("暂时不支持该功能！", "系统提示");
                    break;
                default:
                    break;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label10.Font = new Font("宋体_GB2312", 14);
            label10.Text = Updata;
            label10.Visible = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void label10_Click(object sender, EventArgs e)
        {
            label10.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form2 From2 = new Form2();      //调用窗体2
            From2.Show();
        }
    }
}
