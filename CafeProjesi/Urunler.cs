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
    public partial class Urunler : Form
    {
        public Urunler()
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
            SqlCommand cmd = new SqlCommand("insert into CUrunler (UrunAdı,UrunFiyati,UrunAdet,SonKullanmaTarihi,ÜretimTarihi,SatıcıNo) values (@UrunAdı,@UrunFiyati,@UrunAdet@SonKullanmaTarihi,@ÜretimTarihi,@SatıcıNo) ", con);
            cmd.Parameters.AddWithValue("@UrunAdı", comboBox2.SelectedItem);
            cmd.Parameters.AddWithValue("@UrunFiyati", textBox3.Text);
            cmd.Parameters.AddWithValue("@UrunAdet", textBox5.Text);
            cmd.Parameters.AddWithValue("@SonKullanmaTarihi", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@ÜretimTarihi", dateTimePicker2.Text);
            cmd.Parameters.AddWithValue("@SatıcıNo", comboBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Listele("select * from CUrunler");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand komut = new SqlCommand("Update CUrunler set UrunAdı='" + comboBox2.SelectedItem.ToString() + "',UrunFiyati='" + textBox3.Text.ToString() + "',UrunAdet='" + textBox5.Text.ToString() + "', SonKullanmaTarihi='" + dateTimePicker1.Text.ToString() + "',ÜretimTarihi='" + dateTimePicker2.Text.ToString() + "',SatıcıNo='" + comboBox1.Text.ToString() + "'", con);

            komut.ExecuteNonQuery();
            Listele("select*from CUrunler");
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*con.Open();
            SqlCommand cmd = new SqlCommand("delete from CUrunler where UrunAdı=@UrunAdı", con);
            cmd.Parameters.AddWithValue("@UrunAdı", comboBox2.SelectedItem);
            cmd.ExecuteNonQuery();
            Listele("select * from CUrunler");
            con.Close();
            textBox1.Clear();
            comboBox2.Items.Clear();
            textBox3.Clear();*/
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from CUrunler where UrunAdı like '%" + comboBox2.SelectedItem + "%'", con);
            con.Close();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable doldur = new DataTable();
            da.Fill(doldur);
            dataGridView1.DataSource = doldur;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Listele("select*from CUrunler");
        }

        private void Urunler_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secim = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Tag = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            comboBox2.SelectedItem = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secim].Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[secim].Cells[3].Value.ToString();
            dateTimePicker2.Text = dataGridView1.Rows[secim].Cells[4].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secim].Cells[5].Value.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
          //int   adet = 0;
          //   adet = Convert.ToInt32(comboBox2.SelectedItem);
          //  decimal fiyat = Convert.ToDecimal(textBox3.Text);
          //  decimal sonuc = adet * fiyat;
          //  textBox4.Text = sonuc.ToString();
        }

        private void Urunler_Load(object sender, EventArgs e)
        {  
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from CUrunler", con);
            SqlDataReader dr;

          
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox2.Items.Add(dr["UrunAdı"]);
            }
            con.Close();


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from CUrunler where UrunAdı=@UrunAdı", con);
            cmd.Parameters.AddWithValue("@UrunAdı",comboBox2.SelectedItem);
            SqlDataReader dr;


            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                textBox3.Text = dr["UrunFiyati"].ToString(); ;
            }
            con.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
             
            decimal  adet = Convert.ToDecimal(textBox5.Text);
            decimal fiyat = Convert.ToDecimal(textBox3.Text);
            decimal sonuc = adet * fiyat;
            textBox4.Text = sonuc.ToString();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Siparisler go = new Siparisler();
            go.textBox4.Text = textBox4.Text;
            go.Show();

            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

