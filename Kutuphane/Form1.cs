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

namespace Kutuphane
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection
            ("Server=10.22.0.23; Database=M06; Integrated Security=true;");

        public void Listele (string sorgu)
        {
            SqlDataAdapter dr = new SqlDataAdapter(sorgu, con);
            DataTable doldur = new DataTable();
            dr.Fill(doldur);
            dataGridView1.DataSource = doldur;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Listele("select*from Kutuphane");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Kutuphane(KutuphaneAdi,KitapSayisi,Bolge,UyeSayisi,Adres) values (@KutuphaneAdi,@KitapSayisi,@Bolge,@UyeSayisi,@Adres) ", con);
            cmd.Parameters.AddWithValue("@KutuphaneAdi", textBox1.Text);
            cmd.Parameters.AddWithValue("@KitapSayisi", textBox2.Text);
            cmd.Parameters.AddWithValue("@Bolge", textBox3.Text);
            cmd.Parameters.AddWithValue("@UyeSayisi", textBox4.Text);
            cmd.Parameters.AddWithValue("@Adres", textBox5.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Listele("select * from Kutuphane");

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secim= dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Tag = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secim].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secim].Cells[3].Value.ToString();
            textBox4.Text= dataGridView1.Rows[secim].Cells[4].Value.ToString();
            textBox5.Text= dataGridView1.Rows[secim].Cells[5].Value.ToString();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand komut = new SqlCommand("Update Kutuphane set KutuphaneAdi='" + textBox1.Text.ToString() + "',KitapSayisi='" + textBox2.Text.ToString() + "',Bolge='" + textBox3.Text.ToString() + "',UyeSayisi='" + textBox4.Text.ToString() + "',Adres='" + textBox5.Text.ToString() + "'where KutuphaneNo='" + textBox1.Tag + "'", con);


            //tırnakları alanları birbirinden ayırmak için kullanırız.(+) verileri birleştirmek için
            komut.ExecuteNonQuery();
            Listele("select*from Kutuphane");
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd=new SqlCommand("delete from Kutuphane where KutuphaneNo=@KutuphaneNo", con);
            cmd.Parameters.AddWithValue("@KutuphaneNo", textBox1.Tag);
            cmd.ExecuteNonQuery();
            Listele("select * from Kutuphane");
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            SqlCommand cmd = new SqlCommand("select * from Kutuphane where KutuphaneAdi like '%" + textBox1.Text + "%'",con);
            con.Close();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable doldur=new DataTable();
            da.Fill(doldur);
            dataGridView1.DataSource= doldur;
            
        }
    }
}
