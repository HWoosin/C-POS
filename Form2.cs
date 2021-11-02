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
    public partial class Form2 : Form
    {
        public static int sale;
        public Form2()
        {
            InitializeComponent();
            Text = "상품계산";
            
            
            dataGridView1.DataSource = PosManager.CB;
            dataGridView1.CurrentCellChanged += DataGridView1_CurrentCellChanged;
        }
        private void DataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                Cusbuy cb = dataGridView1.CurrentRow.DataBoundItem as Cusbuy;
                textBox1.Text = cb.Code;
            }
            catch (Exception ex) { }
        }
        private void dataGridView1_CurrentCellChanged_1(object sender, EventArgs e)
        {
            try
            {
                Cusbuy cb = dataGridView1.CurrentRow.DataBoundItem as Cusbuy;
                textBox1.Text = cb.Code;
            }
            catch (Exception ex) { }
        }

        private void button1_Click(object sender, EventArgs e)//결제
        {
            try
            {
                if (int.Parse(textBox2.Text) < int.Parse(textBox3.Text))
                {
                    MessageBox.Show("받은 금액이 적습니다.", "결제가 완료되지않음!");
                    
                }
                else 
                {
                    int result;
                    result = int.Parse(textBox2.Text) - int.Parse(textBox3.Text);
                    MessageBox.Show($"거스름돈:{ result.ToString(" #,##0원")}", "결제완료");


                    label3.Text = "거래완료";
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = PosManager.CB;
                    //PosManager.Save();
                    
                    sale += int.Parse(textBox3.Text);
                    textBox2.Text = "";
                    textBox3.Text = "";

                    button4.Enabled = true;
                }

                
                //dataGridView1.DataSource = null;
                //dataGridView1.DataSource = PosManager.CB;
                //PosManager.Save();
            }
            catch (Exception ex) { }
        }

        private void button3_Click(object sender, EventArgs e)//취소
        {

            try
            {
                Cusbuy cb = PosManager.CB.Single(x => x.Code == textBox1.Text);
                PosManager.CB.Remove(cb);
                UProduct ud = PosManager.UPDS.Single(x => x.Code == textBox1.Text);
                ud.Count = ud.Count + cb.Count;

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = PosManager.CB;
                //PosManager.Save();

                int sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                }
                textBox3.Text = sum.ToString();

                int count = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    count += Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
                }
                label3.Text = count.ToString("0개");
            }
            catch (Exception ex) { }
        }

        private void button2_Click(object sender, EventArgs e)//입력
        {
            try
            {

                if (PosManager.CB.Exists(x => x.Code == textBox1.Text))
                {
                    Cusbuy cb = PosManager.CB.Single(x => x.Code == textBox1.Text);
                    cb.Count = cb.Count+1;
                    cb.Totalprice = cb.Count * cb.Price;

                    UProduct ud = PosManager.UPDS.Single(x => x.Code == textBox1.Text);
                    ud.Count = ud.Count - 1;


                }

                else if(PosManager.UPDS.Exists(x => x.Code == textBox1.Text))
                {
                    UProduct ud = PosManager.UPDS.Single(x => x.Code == textBox1.Text);
                    
                    Cusbuy cb = new Cusbuy()
                    {
                        Code = textBox1.Text,
                        Name =ud.Name,
                        Price =ud.Price,
                        Count = 1,
                        Totalprice= ud.Price
                    };
                    

                    ud.Count = ud.Count - 1;
                    PosManager.CB.Add(cb);


                }
                else
                {
                    MessageBox.Show("등록되지 않은 상품입니다.");
                }
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = PosManager.CB;
                    //PosManager.Save();

                int sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                }
                textBox3.Text = sum.ToString();

                int count = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    count += Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
                }
                label3.Text = count.ToString("0개");

            }
            catch (Exception ex) { }
        }

        private void button4_Click(object sender, EventArgs e)//목록 초기화
        {
            try
            {
                Cusbuy cb = PosManager.CB.Single(x => x.Code == textBox1.Text);
                PosManager.CB.Remove(cb);
                label3.Text = "거래완료";

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = PosManager.CB;
                PosManager.Save();
            }
            catch (Exception ex) { }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Cusbuy cb = PosManager.CB.Single(x => x.Code == textBox1.Text);
                PosManager.CB.Remove(cb);
                label3.Text = "거래완료";

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = PosManager.CB;
                PosManager.Save();
            }
            catch (Exception ex) { }
        }
    }
    
}
