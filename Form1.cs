using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 편의점POS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Text = "편의점 메인";
            
            label3.Text = DateTime.Now.ToString("MM월dd일 hh:mm");
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form3().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form4().ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Form5().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int sales = Form2.sale;
            int basic = 100000;
            int result = basic + sales;
            label4.Text = result.ToString("#,##0원");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int sales = Form2.sale;
            int basic = 100000;
            int result = basic + sales;
            label4.Text = result.ToString("#,##0원");
        }
    }
}
