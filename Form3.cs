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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            Text = "재고 관리";

            dataGridView1.DataSource = PosManager.UPDS;
            dataGridView1.CurrentCellChanged += DataGridView1_CurrentCellChanged;
        }
        private void DataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                UProduct ud = dataGridView1.CurrentRow.DataBoundItem as UProduct;
                textBox1.Text = ud.Name.ToString();
            }
            catch (Exception ex) { }
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                
                UProduct ud = dataGridView1.CurrentRow.DataBoundItem as UProduct;
                textBox1.Text = ud.Name.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                UProduct ud = PosManager.UPDS.Single(x => x.Name == textBox1.Text);
                ud.Count = int.Parse(textBox2.Text);



                dataGridView1.DataSource = null;
                dataGridView1.DataSource = PosManager.UPDS;
                PosManager.Save();
            }
            catch (Exception ex) { }
        }
    }
}
