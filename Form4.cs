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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            Text = "택배 관리";
            dataGridView1.DataSource = PosManager.TDVER;
            dataGridView1.CurrentCellChanged += DataGridView1_CurrentCellChanged;
            
        }
        private void DataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                TDeliver td = dataGridView1.CurrentRow.DataBoundItem as TDeliver;
                textBox1.Text = td.Dcode;
            }
            catch (Exception ex) { }
        }

      


        private void button4_Click(object sender, EventArgs e) //삭제
        {
            try
            {
                TDeliver td = PosManager.TDVER.Single(x => x.Dcode == textBox1.Text);
                PosManager.TDVER.Remove(td);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = PosManager.TDVER;
                PosManager.Save();
            }
            catch (Exception ex) { }
        }

        private void button1_Click(object sender, EventArgs e)//입고
        {
            try
            {

                if (PosManager.TDVER.Exists(x => x.Dcode == textBox1.Text))
                {
                    MessageBox.Show("이미 존재하는 택배입니다.");
                }
                
                else
                {
                    TDeliver td = new TDeliver()
                    {
                        Dcode = textBox1.Text
                    };
                    PosManager.TDVER.Add(td);

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = PosManager.TDVER;
                    PosManager.Save();
                }
            }
            catch (Exception ex) { }
            
        }

        private void button2_Click(object sender, EventArgs e) //출고
        {
            try
            {
                TDeliver td = PosManager.TDVER.Single(x => x.Dcode == textBox1.Text);
                PosManager.TDVER.Remove(td);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = PosManager.TDVER;
                PosManager.Save();
                MessageBox.Show("고객 수령 완료!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("택배를 선택해 주십시오.");
            }
        }

        private void dataGridView1_CurrentCellChanged_1(object sender, EventArgs e)
        {
            try
            {
                TDeliver td = dataGridView1.CurrentRow.DataBoundItem as TDeliver;
                textBox1.Text = td.Dcode;

            }
            catch (Exception ex) { }
        }
    }
}

    

