using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeProjesi
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Siparisler go = new Siparisler();
            go.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Urunler go = new Urunler();
            go.Show();
            this.Hide();
        }
    }
}
