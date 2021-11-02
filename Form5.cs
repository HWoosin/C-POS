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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            Text = "점포 관리";
            dataGridView1.DataSource = PosManager.COD;
            dataGridView1.CurrentCellChanged += DataGridView1_CurrentCellChanged;
            dataGridView2.DataSource = PosManager.OD;
            dataGridView2.CurrentCellChanged += DataGridView2_CurrentCellChanged;
        }

        private void DataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                COrder cd = dataGridView1.CurrentRow.DataBoundItem as COrder;
                textBox1.Text = cd.Code;
                textBox2.Text = cd.Name;
                textBox3.Text = cd.Maker;
                textBox4.Text = cd.Count.ToString();
            }
            catch (Exception ex) { }
        }

      

        private void DataGridView2_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                Order od = dataGridView2.CurrentRow.DataBoundItem as Order;
                textBox1.Text = od.Code;
                textBox2.Text = od.Name;
                textBox3.Text = od.Maker;
                textBox4.Text = od.Count.ToString();
            }
            catch (Exception ex) { }
        }


        private void button2_Click(object sender, EventArgs e)//발주
        {
            try
            {
                if (PosManager.UPDS.Exists(x => x.Code == textBox1.Text))
                {
                    MessageBox.Show("추가 발주 완료");

                    UProduct ud = PosManager.UPDS.Single(x => x.Code == textBox1.Text);
                    ud.Code = textBox1.Text;
                    ud.Name = textBox2.Text;
                    ud.Maker = textBox3.Text;
                    ud.Count = int.Parse(textBox4.Text)+ud.Count;

                    COrder cod = PosManager.COD.Single(x => x.Code == textBox1.Text);
                    ud.Price = cod.Price;

                    Order od = PosManager.OD.Single(x => x.Code == textBox1.Text);
                    PosManager.OD.Remove(od);
                }
                else
                {
                    COrder cod = PosManager.COD.Single(x => x.Code == textBox1.Text);
                    UProduct ud = new UProduct()
                    {
                        Code = textBox1.Text,
                        Name = textBox2.Text,
                        Maker = textBox3.Text,
                        Count = int.Parse(textBox4.Text),
                        
                    };
                    ud.Price = cod.Price;



                    PosManager.UPDS.Add(ud);
                    MessageBox.Show("발주 완료");

                    Order od = PosManager.OD.Single(x => x.Code == textBox1.Text);
                    PosManager.OD.Remove(od);
                }  
              
               
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = PosManager.OD;
                PosManager.Save();
                    
            }
            catch (Exception ex) { }
        }

        private void button1_Click(object sender, EventArgs e)//취소
        {
            try
            {
                Order od = PosManager.OD.Single(x => x.Code == textBox1.Text);
                PosManager.OD.Remove(od);

                dataGridView2.DataSource = null;
                dataGridView2.DataSource = PosManager.OD;
                PosManager.Save();
            }
            catch (Exception ex) { }
        }

        private void button3_Click(object sender, EventArgs e)//추가
        {
            try
            {
                if (PosManager.OD.Exists(x => x.Code == textBox1.Text))
                {
                    MessageBox.Show("중복상품");

                }

                else
                {
                    COrder cod = PosManager.COD.Single(x => x.Code == textBox1.Text);
                    Order od = new Order()
                    {
                        Code = textBox1.Text,
                        Name = textBox2.Text,
                        Maker = textBox3.Text,
                        Count =+ int.Parse(textBox4.Text)
                    };
                    od.Price = cod.Price;
                    PosManager.OD.Add(od);

                    dataGridView2.DataSource = null;
                    dataGridView2.DataSource = PosManager.OD;
                    PosManager.Save();
                }
            }
            catch (Exception ex) { }
        }

        private void dataGridView1_CurrentCellChanged_1(object sender, EventArgs e)
        {
            try
            {
                COrder cd = dataGridView1.CurrentRow.DataBoundItem as COrder;
                textBox1.Text = cd.Code;
                textBox2.Text = cd.Name;
                textBox3.Text = cd.Maker;
                textBox4.Text = cd.Count.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void dataGridView2_CurrentCellChanged_1(object sender, EventArgs e)
        {
            try
            {
                Order od = dataGridView2.CurrentRow.DataBoundItem as Order;
                textBox1.Text = od.Code;
                textBox2.Text = od.Name;
                textBox3.Text = od.Maker;
                textBox4.Text = od.Count.ToString();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
