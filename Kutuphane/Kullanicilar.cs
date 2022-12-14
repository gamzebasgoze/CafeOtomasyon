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
    public partial class Kullanicilar : Form
    {
        SqlConnection con = new SqlConnection
            ("Server=10.22.0.23; Database=M06; Integrated Security=true;");

        public Kullanicilar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd=new SqlCommand("select * from Calisanlar where KullaniciAd=@KullaniciAd and Sifre=@Sifre", con);
            cmd.Parameters.AddWithValue("@KullaniciAd", textBox1.Text);
            cmd.Parameters.AddWithValue("@Sifre", textBox2.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Giriş Başarılı","Başarılı",MessageBoxButtons.OK ,MessageBoxIcon.Information);
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
    }
}
