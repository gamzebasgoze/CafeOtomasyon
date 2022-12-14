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
    public partial class Kullanıcılar : Form
    {
        SqlConnection con = new SqlConnection
            ("Server=10.22.0.23; Database=M06; Integrated Security=true;");
        public Kullanıcılar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from CKullanici where KullaniciAdi=@KullaniciAdi and Sifre=@Sifre", con);
            cmd.Parameters.AddWithValue("@KullaniciAdi", textBox1.Text);
            cmd.Parameters.AddWithValue("@Sifre", textBox2.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Giriş Başarılı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form2 go = new Form2();
                go.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş", "Hata", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                textBox1.Clear();
                textBox2.Clear();
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into CKullanici (KullaniciAdi,Sifre,Mail,Telefon) values (@KullaniciAdi,@Sifre,@Mail,@Telefon)", con);
            cmd.Parameters.AddWithValue("@KullaniciAdi", textBox1.Text);
            cmd.Parameters.AddWithValue("@Sifre", textBox2.Text);
            cmd.Parameters.AddWithValue("@Mail", textBox3.Text);
            cmd.Parameters.AddWithValue("@Telefon", maskedTextBox1.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            maskedTextBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("select * from CYKullanici where KullaniciAdi=@KullaniciAdi and Sifre=@Sifre", con);
            cmd.Parameters.AddWithValue("@KullaniciAdi", textBox4.Text);
            cmd.Parameters.AddWithValue("@Sifre", textBox5.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Giriş Başarılı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 go = new Form1();
                go.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş", "Hata", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                textBox1.Clear();
                textBox2.Clear();
            }
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into CYKullanici (KullaniciAdi,Sifre,Mail,Telefon) values (@KullaniciAdi,@Sifre,@Mail,@Telefon)", con);
            cmd.Parameters.AddWithValue("@KullaniciAdi", textBox4.Text);
            cmd.Parameters.AddWithValue("@Sifre", textBox5.Text);
            cmd.Parameters.AddWithValue("@Mail", textBox6.Text);
            cmd.Parameters.AddWithValue("@Telefon", maskedTextBox2.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            maskedTextBox2.Clear();
        }

        private void Kullanıcılar_Load(object sender, EventArgs e)
        {

        }
    }
}
