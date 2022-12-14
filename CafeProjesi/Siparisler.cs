using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CafeProjesi
{
    public partial class Siparisler : Form
    {
        public Siparisler()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection
          ("Server=316-07\\SQLEXPRESS; Database=M06; Integrated Security=true;");
        public void Listele(string sorgu)
        {
            SqlDataAdapter dr = new SqlDataAdapter(sorgu, con);
            DataTable doldur = new DataTable();
            dr.Fill(doldur);
            dataGridView1.DataSource = doldur;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 go = new Form1();
            go.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from CSiparis where UrunNo like '%" + textBox1.Text + "%'", con);
            con.Close();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable doldur = new DataTable();
            da.Fill(doldur);
            dataGridView1.DataSource = doldur;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into CSiparis (SiparisTutari,KullaniciNo,SiparisAdresi) values (SiparisTutari,KullaniciNo,SiparisAdresi) ", con);
            cmd.Parameters.AddWithValue("@SiparisTutari ", textBox4.Text);
            cmd.Parameters.AddWithValue("@KullaniciNo", textBox2.Text);
            cmd.Parameters.AddWithValue("@SiparisAdresi", textBox3.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Listele("select * from CSiparis");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand komut = new SqlCommand("Update CUrunler set SiparisTutari='" + textBox4.Text.ToString() + "',KullaniciNo='" + textBox2.Text.ToString() + "',SiparisAdresi='" + textBox3.Text.ToString() + "'", con);

            komut.ExecuteNonQuery();
            Listele("select*from CSiparis");
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from CSiparis where UrunNo=@UrunNo", con);
            cmd.Parameters.AddWithValue("@UrunNo", textBox1.Text);
            cmd.ExecuteNonQuery();
            Listele("select * from CSiparis");
            con.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Listele("select*from CSiparis");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secim = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Tag = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secim].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[secim].Cells[3].Value.ToString();
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            decimal adet = Convert.ToDecimal(textBox3.Text);
            decimal fiyat = Convert.ToDecimal(textBox2.Text);
            decimal sonuc = adet * fiyat;
            textBox4.Text = sonuc.ToString();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string kadi=Convert.ToString(textBox1.Text);
        }
    }
}
