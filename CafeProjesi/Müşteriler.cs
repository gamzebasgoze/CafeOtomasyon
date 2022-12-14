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
    public partial class Müşteriler : Form
    {
        public Müşteriler()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection
           ("Server=316-07\\SQLEXPRESS; Database=M06; Integrated Security=true;");
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 go=new Form1();
            go.Show();
            this.Hide();

        }
        public void Listele(string sorgu)
        {
            SqlDataAdapter dr = new SqlDataAdapter(sorgu, con);
            DataTable doldur = new DataTable();
            dr.Fill(doldur);
            dataGridView1.DataSource = doldur;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into CMusteriler (MusteriAdSoyad,MusteriTelefon) values (MusteriAdSoyad,MusteriTelefon) ", con);
            cmd.Parameters.AddWithValue("@MusteriAdSoyad", textBox2.Text);
            cmd.Parameters.AddWithValue("@MusteriTelefon", maskedTextBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Listele("select * from CMusteriler");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand komut = new SqlCommand("Update CMusteriler set MusteriAdSoyad='" + textBox2.Text.ToString() + "',MusteriTelefon='" + maskedTextBox1.Text.ToString() + "'", con);

            komut.ExecuteNonQuery();
            Listele("select*from CMusteriler");
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from CMusteriler where MusteriAdSoyad=@MusteriAdSoyad", con);
            cmd.Parameters.AddWithValue("@MusteriAdSoyad", textBox2.Text);
            cmd.ExecuteNonQuery();
            Listele("select * from CMusteriler");
            con.Close();
            textBox1.Clear();
            maskedTextBox1.Clear();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from CMusteriler where MusteriAdSoyad like '%" + textBox2.Text + "%'", con);
            con.Close();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable doldur = new DataTable();
            da.Fill(doldur);
            dataGridView1.DataSource = doldur;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Listele("select*from CMusteriler");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secim = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Tag = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[secim].Cells[1].Value.ToString();
          
        }
    }
}
