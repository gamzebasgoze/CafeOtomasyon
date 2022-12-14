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
    public partial class Satıcılar : Form
    {
        public Satıcılar()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection
            ("Server=316-07\\SQLEXPRESS; Database=M06; Integrated Security=true;");
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 go = new Form1();
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
            SqlCommand cmd = new SqlCommand("insert into CSaticilar(SaticiAdSoyad,SaticiAdres,SaticiIlce,SaticiSube) values (@SaticiAdSoyad,@SaticiAdres,@SaticiIlce,@SaticiSube) ", con);
            cmd.Parameters.AddWithValue("@SaticiAdSoyad", textBox2.Text);
            cmd.Parameters.AddWithValue("@SaticiAdres", textBox3.Text);
            cmd.Parameters.AddWithValue("@SaticiIlce", textBox4.Text);
            cmd.Parameters.AddWithValue("@SaticiSube", textBox5.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Listele("select * from CSaticilar");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand komut = new SqlCommand("Update CSaticilar set SaticiAdSoyad='" + textBox2.Text.ToString() + "',SaticiAdres='" + textBox3.Text.ToString() + "',SaticiIlce='" + textBox4.Text.ToString() + "',SaticiSube='" + textBox5.Text.ToString() + "'", con);

            komut.ExecuteNonQuery();
            Listele("select*from CSaticilar");
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from CSaticilar where SaticiNo=@SaticiNo", con);
            cmd.Parameters.AddWithValue("@SaticiNo", textBox1.Text);
            cmd.ExecuteNonQuery();
            Listele("select * from CSaticilar");
            con.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from CSaticilar where SaticiAdSoyad like '%" + textBox2.Text + "%'", con);
            con.Close();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable doldur = new DataTable();
            da.Fill(doldur);
            dataGridView1.DataSource = doldur;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Listele("select*from CSaticilar");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secim = dataGridView1.SelectedCells[0].RowIndex;
            //textBox1.Tag = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secim].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[secim].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[secim].Cells[4].Value.ToString();
        }

        private void Satıcılar_Load(object sender, EventArgs e)
        {

        }
    }
}
